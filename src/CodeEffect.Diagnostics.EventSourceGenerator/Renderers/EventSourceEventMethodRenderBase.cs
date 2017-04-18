using CodeEffect.Diagnostics.EventSourceGenerator.Builders;
using CodeEffect.Diagnostics.EventSourceGenerator.Model;

namespace CodeEffect.Diagnostics.EventSourceGenerator.Renderers
{
    public class EventSourceEventMethodRenderBase : EventMethodBaseRenderer
    {
        protected string Render(EventModel model)
        {
            var outputEventMethod = Template.Template_EVENT_METHOD;
            outputEventMethod = outputEventMethod.Replace(Template.Variable_EVENT_NAME, model.Name);
            outputEventMethod = outputEventMethod.Replace(Template.Variable_EVENT_ID, model.Id.ToString());
            outputEventMethod = outputEventMethod.Replace(Template.Variable_EVENT_LEVEL, model.Level.ToString());

            var keywords = new ListBuilder("", " | ", "");
            foreach (var keyword in model.Keywords ?? new KeywordModel[] { })
            {
                keywords.Append($"Keywords.{keyword.Name}");
            }
            var keywordsDeclaration = (keywords.Length > 0) ? $", Keywords = {keywords}" : "";
            outputEventMethod = outputEventMethod.Replace(Template.Variable_EVENT_KEYWORDS_DECLARATION, keywordsDeclaration);

            var eventMethodArgumentsDeclarationBuilder = new EventArgumentsListBuilder(
                (arg) => RenderMethodArgument(arg), Template.Template_EVENT_METHOD_ARGUMENT_DELIMITER);
            var writeEventMethodCallArgument = new EventArgumentsListBuilder(
                (arg) => RenderWriteEventMethodCallArgument(arg), Template.Template_EVENT_METHOD_CALL_ARGUMENT_DELIMITER);

            foreach (var argument in model.GetAllArgumentsExpanded())
            {
                eventMethodArgumentsDeclarationBuilder.Append(argument);
                writeEventMethodCallArgument.Append(argument);
            }

            outputEventMethod = outputEventMethod.Replace(Template.Variable_EVENT_METHOD_ACCESS, model.HasComplexArguments ? "private" : "public");
            outputEventMethod = outputEventMethod.Replace(Template.Variable_EVENT_METHOD_ARGUMENTS, eventMethodArgumentsDeclarationBuilder.ToString());
            outputEventMethod = outputEventMethod.Replace(Template.Variable_WRITEEVENT_CALL_ARGUMENTS, writeEventMethodCallArgument.ToString());

            outputEventMethod = outputEventMethod.Replace(Template.Variable_EVENT_MESSAGE_FORMATTER, model.MessageFormatter);

            return outputEventMethod;
        }

    }
}