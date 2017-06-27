using System.Collections.Generic;
using FG.Diagnostics.AutoLogger.Generator.Utils;
using FG.Diagnostics.AutoLogger.Model;

namespace FG.Diagnostics.AutoLogger.Generator.Builders
{
    public class ProjectDefaultEventSourceBuilder : BaseWithLogging, IProjectBuilder
    {
        public void Build(Project model)
        {
            AddDefaultEventSource(model);
        }

        private void AddDefaultEventSource(Project project)
        {
            var defaultEventSourceProjectItem = project.ProjectItems.GetDefaultEventSourceProjectItem();
            if (defaultEventSourceProjectItem != null)
            {
                var defaultEventSource = new EventSourceModel()
                {
                    Namespace = defaultEventSourceProjectItem.RootNamespace,
                    Name = "DefaultEventSource",
                    ProviderName = $"{defaultEventSourceProjectItem.RootNamespace.Replace('.', '-')}-Default",
                    ClassName = "DefaultEventSource",
                    TypeTemplates = new TypeTemplateModel[]
                    {
                        new TypeTemplateModel()
                        {
                            Name = "Exception",
                            CLRType = "System.Exception",
                            Arguments = new EventArgumentModel[]
                            {
                                new EventArgumentModel("message", "string", "$this.Message"),
                                new EventArgumentModel("source", "string", "$this.Source"),
                                new EventArgumentModel("exceptionTypeName", "string", "$this.GetType().FullName"),
                                new EventArgumentModel("exception", "string", "$this.AsJson()"),
                            }
                        }
                    }
                };
                var eventSourceLoggers = new List<LoggerModel>();
                var startId = 1000;
                foreach (var logger in project.Loggers)
                {
                    eventSourceLoggers.Add(new LoggerModel()
                    {
                        Name = logger.Name,
                        StartId = startId,
                        ImplicitArguments = new EventArgumentModel[]
                        {
                            new EventArgumentModel() { Name = "autogenerated", Type = "bool"},
                            new EventArgumentModel() { Name = "machineName", Type = "string", Assignment = "Environment.MachineName"}, 
                        }
                    });
                    startId += 1000;
                }
                defaultEventSource.Loggers = eventSourceLoggers.ToArray();

                // TODO: Move this to a renderer
                var sourceFileName = System.IO.Path.GetFileName(defaultEventSourceProjectItem.Name);
                var implementationFileName = $"{System.IO.Path.GetFileNameWithoutExtension(defaultEventSourceProjectItem.Name)}.cs";
                var fileRelativePath = defaultEventSourceProjectItem.Name.RemoveFromStart(project.ProjectBasePath + System.IO.Path.DirectorySeparatorChar).Replace(sourceFileName, implementationFileName);

                defaultEventSource.Include = fileRelativePath;
                defaultEventSource.SourceFilePath = defaultEventSourceProjectItem.Include;

                defaultEventSourceProjectItem.Content = defaultEventSource;
                //var newProjectItem = new ProjectItem(
                //    type: ProjectItemType.DefaultGeneratedEventSourceDefinition,
                //    name: defaultEventSourceProjectItem.Name,
                //    content: jsonFile,
                //    include: defaultEventSourceProjectItem.Include)
                //{
                //    RootNamespace = defaultEventSourceProjectItem.RootNamespace
                //};

                //project.AddProjectItem(newProjectItem);                
            }
        }

    }
}