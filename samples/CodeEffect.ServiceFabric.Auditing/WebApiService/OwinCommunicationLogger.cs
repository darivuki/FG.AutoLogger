/*******************************************************************************************
*  This class is autogenerated from the class OwinCommunicationLogger
*  Do not directly update this class as changes will be lost on rebuild.
*******************************************************************************************/
using System;
using System.Collections.Generic;
using WebApiService.Diagnostics;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using System.Runtime.Remoting.Messaging;


namespace WebApiService
{
	internal sealed class OwinCommunicationLogger : IOwinCommunicationLogger
	{
	    private sealed class ScopeWrapper : IDisposable
        {
            private readonly IEnumerable<IDisposable> _disposables;

            public ScopeWrapper(IEnumerable<IDisposable> disposables)
            {
                _disposables = disposables;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            private void Dispose(bool disposing)
            {
                if (disposing)
                {
                    foreach (var disposable in _disposables)
                    {
                        disposable.Dispose();
                    }
                }
            }
        }

	    private sealed class ScopeWrapperWithAction : IDisposable
        {
            private readonly Action _onStop;

            internal static IDisposable Wrap(Func<IDisposable> wrap)
            {
                return wrap();
            }

            public ScopeWrapperWithAction(Action onStop)
            {
                _onStop = onStop;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            private void Dispose(bool disposing)
            {
                if (disposing)
                {
                    _onStop?.Invoke();
                }
            }
        }


		private readonly System.Fabric.StatelessServiceContext _context;
		private readonly Microsoft.ApplicationInsights.TelemetryClient _telemetryClient;

        public sealed class OperationHolder
        {
            public static void StartOperation(IOperationHolder<RequestTelemetry> aiOperationHolder)
            {
                OperationHolder.Current = new OperationHolder() {AIOperationHolder = aiOperationHolder};
            }

            public static IOperationHolder<RequestTelemetry> StopOperation()
            {
                var aiOperationHolder = OperationHolder.Current.AIOperationHolder;
                OperationHolder.Current = null;

                return aiOperationHolder;
            }

            private IOperationHolder<RequestTelemetry> AIOperationHolder { get; set; }

            private static readonly string ContextKey = Guid.NewGuid().ToString();

            public static OperationHolder Current
            {
                get { return (OperationHolder)CallContext.LogicalGetData(ContextKey); }
                internal set
                {
                    if (value == null)
                    {
                        CallContext.FreeNamedDataSlot(ContextKey);
                    }
                    else
                    {
                        CallContext.LogicalSetData(ContextKey, value);
                    }
                }
            }
        }

		public OwinCommunicationLogger(
			System.Fabric.StatelessServiceContext context)
		{
			_context = context;
			
            _telemetryClient = new Microsoft.ApplicationInsights.TelemetryClient();
            _telemetryClient.Context.User.Id = Environment.UserName;
            _telemetryClient.Context.Session.Id = Guid.NewGuid().ToString();
            _telemetryClient.Context.Device.OperatingSystem = Environment.OSVersion.ToString();

		}

		public void AbortingWebServer(
			)
		{
			WebApiServiceEventSource.Current.AbortingWebServer(
				_context
			);
			_telemetryClient.TrackEvent(
	            nameof(AbortingWebServer),
	            new System.Collections.Generic.Dictionary<string, string>()
	            {
	                {"ServiceName", _context.ServiceName.ToString()},
                    {"ServiceTypeName", _context.ServiceTypeName},
                    {"ReplicaOrInstanceId", _context.InstanceId.ToString()},
                    {"PartitionId", _context.PartitionId.ToString()},
                    {"ApplicationName", _context.CodePackageActivationContext.ApplicationName},
                    {"ApplicationTypeName", _context.CodePackageActivationContext.ApplicationTypeName},
                    {"NodeName", _context.NodeContext.NodeName}
	            });
    
		}



		public void ClosingWebServer(
			)
		{
			WebApiServiceEventSource.Current.ClosingWebServer(
				_context
			);
			_telemetryClient.TrackEvent(
	            nameof(ClosingWebServer),
	            new System.Collections.Generic.Dictionary<string, string>()
	            {
	                {"ServiceName", _context.ServiceName.ToString()},
                    {"ServiceTypeName", _context.ServiceTypeName},
                    {"ReplicaOrInstanceId", _context.InstanceId.ToString()},
                    {"PartitionId", _context.PartitionId.ToString()},
                    {"ApplicationName", _context.CodePackageActivationContext.ApplicationName},
                    {"ApplicationTypeName", _context.CodePackageActivationContext.ApplicationTypeName},
                    {"NodeName", _context.NodeContext.NodeName}
	            });
    
		}



		public void StartingWebServer(
			string listeningAddress)
		{
			WebApiServiceEventSource.Current.StartingWebServer(
				_context, 
				listeningAddress
			);
			_telemetryClient.TrackEvent(
	            nameof(StartingWebServer),
	            new System.Collections.Generic.Dictionary<string, string>()
	            {
	                {"ServiceName", _context.ServiceName.ToString()},
                    {"ServiceTypeName", _context.ServiceTypeName},
                    {"ReplicaOrInstanceId", _context.InstanceId.ToString()},
                    {"PartitionId", _context.PartitionId.ToString()},
                    {"ApplicationName", _context.CodePackageActivationContext.ApplicationName},
                    {"ApplicationTypeName", _context.CodePackageActivationContext.ApplicationTypeName},
                    {"NodeName", _context.NodeContext.NodeName},
                    {"ListeningAddress", listeningAddress}
	            });
    
		}



		public void ListeningOn(
			string publishAddress)
		{
			WebApiServiceEventSource.Current.ListeningOn(
				_context, 
				publishAddress
			);
			_telemetryClient.TrackEvent(
	            nameof(ListeningOn),
	            new System.Collections.Generic.Dictionary<string, string>()
	            {
	                {"ServiceName", _context.ServiceName.ToString()},
                    {"ServiceTypeName", _context.ServiceTypeName},
                    {"ReplicaOrInstanceId", _context.InstanceId.ToString()},
                    {"PartitionId", _context.PartitionId.ToString()},
                    {"ApplicationName", _context.CodePackageActivationContext.ApplicationName},
                    {"ApplicationTypeName", _context.CodePackageActivationContext.ApplicationTypeName},
                    {"NodeName", _context.NodeContext.NodeName},
                    {"PublishAddress", publishAddress}
	            });
    
		}



		public void WebServerFailed(
			System.Exception ex)
		{
			WebApiServiceEventSource.Current.WebServerFailed(
				_context, 
				ex
			);
			_telemetryClient.TrackException(
	            ex,
	            new System.Collections.Generic.Dictionary<string, string>()
	            {
                    { "Name", "WebServerFailed" },
	                {"ServiceName", _context.ServiceName.ToString()},
                    {"ServiceTypeName", _context.ServiceTypeName},
                    {"ReplicaOrInstanceId", _context.InstanceId.ToString()},
                    {"PartitionId", _context.PartitionId.ToString()},
                    {"ApplicationName", _context.CodePackageActivationContext.ApplicationName},
                    {"ApplicationTypeName", _context.CodePackageActivationContext.ApplicationTypeName},
                    {"NodeName", _context.NodeContext.NodeName},
                    {"Message", ex.Message},
                    {"Source", ex.Source},
                    {"ExceptionTypeName", ex.GetType().FullName},
                    {"Exception", ex.AsJson()}
	            });
    
		}



	}
}
