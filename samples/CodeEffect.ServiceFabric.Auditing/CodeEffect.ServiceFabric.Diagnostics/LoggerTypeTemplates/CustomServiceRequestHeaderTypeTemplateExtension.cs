﻿using FG.Diagnostics.AutoLogger.Model;
using FG.ServiceFabric.Services.Remoting.FabricTransport;

namespace CodeEffect.ServiceFabric.Diagnostics.LoggerTypeTemplates
{
    public class CustomServiceRequestHeaderTypeTemplateExtension : BaseTemplateExtension<CustomServiceRequestHeader>
    {
        private string Definition = @"{
                  ""Name"": ""CustomServiceRequestHeader"",
                  ""CLRType"": ""FG.ServiceFabric.Services.Remoting.FabricTransport.CustomServiceRequestHeader"",
                  ""Arguments"": [
                    {
                      ""Name"": ""userId"",
                      ""Type"": ""string"",
                      ""Assignment"": ""$this?.GetHeader(\""userId\"")""
                    },
                    {
                      ""Name"": ""correlationId"",
                      ""Type"": ""string"",
                      ""Assignment"": ""$this?.GetHeader(\""correlationId\"")""
                    }
                  ]
                }";
                
        protected override string GetDefinition()
        {
            return Definition;
        }
    }
}