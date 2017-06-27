using System;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FG.Diagnostics.AutoLogger.Generator.Templates;
using FG.Diagnostics.AutoLogger.Generator.Utils;
using FG.Diagnostics.AutoLogger.Model;

namespace FG.Diagnostics.AutoLogger.Generator.Renderers
{
    public class LoggerImplementationEventMethodRenderer : BaseWithLogging, ILoggerImplementationEventRenderer
    {
        public string RenderMethodArgument(EventArgumentModel model)
        {
            var output = LoggerImplementationEventMethodTemplate.Template_METHOD_ARGUMENT_DECLARATION;
            output = output.Replace(LoggerImplementationEventMethodTemplate.Template_ARGUMENT_NAME, model.Name);
            output = output.Replace(LoggerImplementationEventMethodTemplate.Template_ARGUMENT_CLR_TYPE, model.CLRType);

            return output;
        }

        public string Render(Project project, ProjectItem<LoggerModel> loggerProjectItem, EventModel model)
        {
            if (loggerProjectItem.ItemType != ProjectItemType.LoggerImplementation)
            {
                LogError($"{loggerProjectItem.Name} should be of ItemType {nameof(ProjectItemType.LoggerImplementation)} set but found {loggerProjectItem.ItemType}");
                return "";
            }

            var loggerModel = loggerProjectItem.Content;
            if (loggerModel == null)
            {
                LogError($"{loggerProjectItem?.Name ?? nameof(loggerProjectItem)} should have content of type {typeof(LoggerModel).Name}, but found {loggerProjectItem?.GetType().Name ?? "null"}");
                return "";
            }

            var eventSourceModel = loggerModel.EventSource;
            if (eventSourceModel == null)
            {
                LogError($"{loggerProjectItem?.Name ?? nameof(loggerProjectItem)} should have content of type {typeof(LoggerModel).Name} with property EventSource set, but found {loggerModel.EventSource?.Name ?? "null"}");
                return "";
            }

            var eventName = model.Name;

            if ((model.ReturnType == "System.IDisposable") && (model.Name.StartsWith("Start")))
            {
                eventName = model.Name.Substring("Start".Length);
            }
            /*
            else if (model.CorrelatesTo?.ReturnType == "System.IDisposable" && (model.CorrelatesTo?.Name.StartsWith("Start") ?? false))
            {
                return "";
            }
            */


            if (model.OpCode == EventOpcode.Start)
            {
                if ((model.ReturnType == "System.IDisposable") && (model.Name.StartsWith("Start")))
                {
                    return RenderStartScopedOperation(project, loggerProjectItem, eventSourceModel, model);
                }

                return RenderStartOperation(model);
            }
            else if (model.OpCode == EventOpcode.Stop)
            {
                if (model.CorrelatesTo?.ReturnType == "System.IDisposable" && (model.CorrelatesTo?.Name.StartsWith("Start") ?? false))
                {
                    return RenderStopScopedOperation(model);
                }

                return RenderStopOperation(model);
            }

            return RenderMethod(project, loggerProjectItem, eventSourceModel, model);

        }

        private string RenderMethod(Project project, ProjectItem<LoggerModel> loggerProjectItem, EventSourceModel eventSourceModel, EventModel model)
        {
            var eventName = model.Name;

            var output = LoggerImplementationEventMethodTemplate.Template_LOGGER_METHOD;
            output = output.Replace(LoggerImplementationEventMethodTemplate.Variable_LOGGER_METHOD_NAME, eventName);
            output = output.Replace(LoggerImplementationEventMethodTemplate.Variable_EVENTSOURCE_CLASS_NAME, eventSourceModel.ClassName);
            output = output.Replace(LoggerImplementationEventMethodTemplate.Variable_LOGGER_METHOD_RETURNTYPE, model.ReturnType ?? "void");

            var methodArguments = new EventArgumentsListBuilder(
                RenderMethodArgument, LoggerImplementationEventMethodTemplate.Template_LOGGER_IMPLICIT_ARGUMENTS_METHOD_DECLARATION_DELIMITER);
            foreach (var argument in model.GetAllNonImplicitArguments())
            {
                methodArguments.Append(argument);
            }
            output = output.Replace(LoggerImplementationEventMethodTemplate.Variable_LOGGER_METHOD_ARGUMENTS, methodArguments.ToString());

            var methodImplementation = new StringBuilder();
            var renderers = new ILoggerImplementationMethodRenderer[]
            {
                new LoggerImplementationMethodCallEventSourceEventRenderer(),
            }.Union(project.GetExtensions<ILoggerImplementationMethodRenderer>()).ToArray();
            foreach (var renderer in renderers)
            {
                PassAlongLoggers(renderer as IWithLogging);
                methodImplementation.Append(renderer.Render(project, loggerProjectItem, model));
            }
            output = output.Replace(LoggerImplementationEventMethodTemplate.Variable_LOGGER_METHOD_IMPLEMENTATION, methodImplementation.ToString());

            return output;
        }

        private string RenderStopOperation(EventModel model)
        {
            throw new NotImplementedException();
        }

        private string RenderStopScopedOperation(EventModel model)
        {
            return "";
        }

        private string RenderStartOperation(EventModel model)
        {
            throw new NotImplementedException();
        }

        private string RenderStartScopedOperation(Project project, ProjectItem<LoggerModel> loggerProjectItem, EventSourceModel eventSourceModel, EventModel model)
        {
            var operationName = GetEventOperationName(model);
            var eventName = model.Name.Substring("Start".Length);

            var output = LoggerImplementationEventMethodTemplate.Template_SCOPED_LOGGER_METHOD;
            output = output.Replace(LoggerImplementationEventMethodTemplate.Variable_LOGGER_METHOD_NAME, eventName);
            output = output.Replace(LoggerImplementationEventMethodTemplate.Variable_EVENTSOURCE_CLASS_NAME, eventSourceModel.ClassName);
            output = output.Replace(LoggerImplementationEventMethodTemplate.Variable_LOGGER_METHOD_RETURNTYPE, model.ReturnType ?? "void");

            var methodArguments = new EventArgumentsListBuilder(
                RenderMethodArgument, LoggerImplementationEventMethodTemplate.Template_LOGGER_IMPLICIT_ARGUMENTS_METHOD_DECLARATION_DELIMITER);
            foreach (var argument in model.GetAllNonImplicitArguments())
            {
                methodArguments.Append(argument);
            }
            output = output.Replace(LoggerImplementationEventMethodTemplate.Variable_LOGGER_METHOD_ARGUMENTS, methodArguments.ToString());

            var methodImplementations = new StringBuilder();
            var renderers = new ILoggerImplementationMethodRenderer[]
            {
                new LoggerImplementationMethodCallEventSourceEventRenderer(),
            }.Union(project.GetExtensions<ILoggerImplementationMethodRenderer>()).ToArray();
            foreach (var renderer in renderers)
            {
                PassAlongLoggers(renderer as IWithLogging);
                var startOutput = renderer.Render(project, loggerProjectItem, model);
                var stopOutput = renderer.Render(project, loggerProjectItem, model.CorrelatesTo);

                var methodScopeWrapperImplementation = LoggerImplementationEventMethodTemplate.Template_SCOPED_LOGGER_METHOD_WRAPPER;
                methodScopeWrapperImplementation = methodScopeWrapperImplementation.Replace(LoggerImplementationEventMethodTemplate.Variable_LOGGER_METHOD_SCOPED_START_IMPLEMENTATION, startOutput);
                methodScopeWrapperImplementation = methodScopeWrapperImplementation.Replace(LoggerImplementationEventMethodTemplate.Variable_LOGGER_METHOD_SCOPED_STOP_IMPLEMENTATION, stopOutput);

                methodImplementations.Append(methodScopeWrapperImplementation);
            }
            output = output.Replace(LoggerImplementationEventMethodTemplate.Variable_SCOPED_LOGGER_METHODS, methodImplementations.ToString());

            return output;
        }

        private readonly Regex _eventOperationNameRegex = new Regex("start|stop", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        protected string GetEventOperationName(EventModel model)
        {
            var eventOperationName = _eventOperationNameRegex.Replace(model.Name, "");
            eventOperationName = $"{eventOperationName.Substring(0, 1).ToLowerInvariant()}{eventOperationName.Substring(1)}";
            return eventOperationName;
        }

        public EventArgumentModel GetRequestNameArgument(EventModel model)
        {
            var hasRequestNameArgument = false;
            EventArgumentModel requestNameArgument = null;
            foreach (var eventArgumentModel in model.GetAllArgumentsExpanded())
            {
                if (eventArgumentModel.Name.Matches("*request*", StringComparison.InvariantCultureIgnoreCase, useWildcards: true))
                {
                    if (hasRequestNameArgument)
                    {
                        LogWarning($"Event {model.Name} has multiple potential request name arguments");
                    }
                    requestNameArgument = eventArgumentModel;
                    hasRequestNameArgument = true;
                }
            }

            return requestNameArgument;
        }

    }
}