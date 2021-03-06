﻿using FG.Diagnostics.AutoLogger.Model;
using FG.ServiceFabric.Services.Remoting.FabricTransport;

namespace CodeEffect.ServiceFabric.Diagnostics.LoggerTypeTemplates
{
    public class ServiceRemotingMessageHeadersTypeTemplateExtension : BaseTemplateExtension<CustomServiceRequestHeader>
    {
        private string Definition = @"{
                  ""Name"": ""ServiceRemotingMessageHeaders"",
                  ""CLRType"": ""Microsoft.ServiceFabric.Services.Remoting.ServiceRemotingMessageHeaders"",
                  ""Arguments"": [
                    {
                      ""Name"": ""InterfaceId"",
                      ""Type"": ""int"",
                      ""Assignment"": ""($this?.InterfaceId ?? 0)""
                    },
                    {
                      ""Name"": ""MethodId"",
                      ""Type"": ""int"",
                      ""Assignment"": ""($this?.MethodId ?? 0)""
                    }
                  ]
                }";

        protected override string GetDefinition()
        {
            return Definition;
        }
    }
}