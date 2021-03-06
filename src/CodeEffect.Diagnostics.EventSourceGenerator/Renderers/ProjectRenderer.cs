using System;
using System.Collections.Generic;
using System.Linq;
using FG.Diagnostics.AutoLogger.Generator.Utils;
using FG.Diagnostics.AutoLogger.Model;

namespace FG.Diagnostics.AutoLogger.Generator.Renderers
{
    public class ProjectRenderer : BaseEtwRendererWithLogging, IProjectRenderer
    {
        public bool SaveChanges { get; set; }

        public void Render(Project model)
        {
            AddGeneratedOutputsToProject(model, this.SaveChanges);
        }

        private void AddGeneratedOutputsToProject(Project model, bool saveChanges = true)
        {
            var projectFilePath = model.ProjectFilePath;
            var includes = model.ProjectItems.Where(p => p.ItemType != ProjectItemType.Reference && p.ItemType != ProjectItemType.ProjectReference && p.ItemType != ProjectItemType.Unknown);

            LogMessage($"Loading projectfile {projectFilePath} to include new files");

            var updatedProjectFile = false;
            var loadedFromProjectCollection = false;

            var project = new FG.Utils.BuildTools.ProjectTool(projectFilePath, null);
            LogMessage($"Loaded project {projectFilePath} from XML to {project.Name}, {(project.IsCpsDocument ? "as CPS project" : "as classic project")}");


            var projectFiles = project.ScanFilesInProjectFolder();
            var existingItems = new List<FG.Utils.BuildTools.FileReference>();
            existingItems.AddRange(projectFiles.Where(item => item.Properties.ContainsKey("AutoGenerated")));

            // Add or check that it already exists
            foreach (var include in includes)
            {
                var includeName = model.GetIncludeName(include);
                var filePath = include.Name;
                var isAutogeneratedType = include.ItemType.IsAutogeneratedType();
                try
                {
                    var matchingItem = projectFiles.FirstOrDefault(item => item.Name.Matches($"{includeName}", StringComparison.InvariantCultureIgnoreCase));

                    var metadata = include.ItemType.Name();
                    IDictionary<string, string> properties = new Dictionary<string, string>();
                    if (include.ItemType == ProjectItemType.DefaultGeneratedEventSourceDefinition)
                    {
                        var hash = include.Output.ToMD5().ToHex();
                        properties = new Dictionary<string, string>
                        {
                            {"AutoGenerated", metadata},
                            {"Hash", hash}
                        };
                    }
                    else if(isAutogeneratedType)
                    {
                        properties = new Dictionary<string, string>
                        {
                            {"AutoGen", "true"},
                            {"AutoGenerated", metadata},
                            {"DependentUpon", include.DependentUpon.Include.RemoveCommonPrefix(includeName, System.IO.Path.DirectorySeparatorChar)},
                        };
                    }

                    var fileType = System.IO.Path.GetExtension(include.Include);
                    var includeType = (include.ItemType == ProjectItemType.DefaultGeneratedEventSourceDefinition || 
                        include.ItemType == ProjectItemType.ProjectSummary) ? "None" : fileType == ".cs" ? "Compile" : "Content";

                    if (matchingItem == null || !FG.Utils.BuildTools.DictionaryExtensions.AreEquivalent(matchingItem.Properties, properties))
                    {
                        //var metadata = Enum.GetName(typeof(ProjectItemType), include.ItemType);
                        updatedProjectFile = true;
                        var addedItems = new List<string>();
                        project.AddFileToProject(filePath, includeType, properties);
                        addedItems.Add(includeName);

                        foreach (var addedItem in addedItems)
                        {
                            LogMessage($"Including project item {addedItem}");
                            existingItems.RemoveAll(fr => fr.Name == addedItem);
                        }
                    }
                    else
                    {
                        LogMessage($"Matched existing project item {matchingItem.Name}");
                        existingItems.Remove(matchingItem);
                    }
                }
                catch (Exception ex)
                {
                    LogError($"Failed to include/add {includeName} - {ex.Message}\n{ex}");
                }
            }
            // Check if we should remove the AutoGenerated DefaultEventSource.eventsource
            var autoGeneratedDefaultEventSource = existingItems.FirstOrDefault(
                existingItem => existingItem.Properties.ContainsKey("AutoGenerated") && existingItem.Properties["AutoGenerated"] == "DefaultEventSource");
            if (autoGeneratedDefaultEventSource != null)
            {
                if (autoGeneratedDefaultEventSource.Name != "DefaultEventSource.cs")
                {
                    updatedProjectFile = true;
                    LogMessage($"Updating Project Metadata for {autoGeneratedDefaultEventSource.Name} as it has been changed from it's original state");
                    var properties = autoGeneratedDefaultEventSource.Properties;
                    if (properties.ContainsKey("AutoGenerated")) properties.Remove("AutoGenerated");
                    project.AddFileToProject(autoGeneratedDefaultEventSource.Name, autoGeneratedDefaultEventSource.IncludeType, properties);
                    existingItems.Remove(autoGeneratedDefaultEventSource);
                }
                else
                {
                    var hash = autoGeneratedDefaultEventSource.Properties.ContainsKey("Hash") ? autoGeneratedDefaultEventSource.Properties["Hash"] : "";

                    var filePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(projectFilePath), autoGeneratedDefaultEventSource.Name);
                    var fileContent = System.IO.File.ReadAllText(filePath);

                    var hashCheck = StringMatchExtensions.ToHex(StringMatchExtensions.ToMD5(fileContent));

                    if (hash != hashCheck)
                    {
                        updatedProjectFile = true;
                        LogMessage($"Updating Project Metadata for {autoGeneratedDefaultEventSource.Name} as it's content been changed from it's original state");
                        var properties = autoGeneratedDefaultEventSource.Properties;
                        if (properties.ContainsKey("AutoGenerated")) properties.Remove("AutoGenerated");
                        project.AddFileToProject(autoGeneratedDefaultEventSource.Name, autoGeneratedDefaultEventSource.IncludeType, properties);
                        existingItems.Remove(autoGeneratedDefaultEventSource);
                    }
                }
            }

            // Remove old items that are no longer referenced
            foreach (var existingItem in existingItems)
            {
                LogMessage($"Removing existing project item {existingItem.Name}");
            }
            if (existingItems.Count > 0)
            {
                updatedProjectFile = true;
                foreach (var fileReference in existingItems)
                {
                    project.RemoveFileFromProject(fileReference.Path);
                }
            }

            if (!updatedProjectFile)
            {
                LogMessage($"Igoring to save project file {projectFilePath} - no changes performed");
            }
            else
            {
                if (saveChanges)
                {
                    LogMessage($"Saving project file {projectFilePath}");
                    project.Save();
                }
                else
                {
                    LogMessage($"Project file {projectFilePath} changed");
                    var rawXml = System.IO.File.ReadAllText(project.FilePath);

                    LogMessage(rawXml);
                }
            }
        }
    }
}