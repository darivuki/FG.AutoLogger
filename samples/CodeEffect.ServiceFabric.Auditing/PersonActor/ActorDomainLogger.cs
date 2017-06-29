/*******************************************************************************************
*  This class is autogenerated from the class ActorDomainLogger
*  Do not directly update this class as changes will be lost on rebuild.
*******************************************************************************************/
using System;
using System.Collections.Generic;
using PersonActor.Diagnostics;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;


namespace PersonActor
{
	internal sealed class ActorDomainLogger : IActorDomainLogger
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


		private readonly Microsoft.ServiceFabric.Actors.Runtime.Actor _actor;
		private readonly FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext _context;
		private readonly Microsoft.ApplicationInsights.TelemetryClient _telemetryClient;

		public ActorDomainLogger(
			Microsoft.ServiceFabric.Actors.Runtime.Actor actor,
			FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext context)
		{
			_actor = actor;
			_context = context;
			
            _telemetryClient = new Microsoft.ApplicationInsights.TelemetryClient();
            _telemetryClient.Context.User.Id = Environment.UserName;
            _telemetryClient.Context.Session.Id = Guid.NewGuid().ToString();
            _telemetryClient.Context.Device.OperatingSystem = Environment.OSVersion.ToString();

		}

		public void PersonActivated(
			string name,
			string title)
		{
			PersonActorServiceEventSource.Current.PersonActivated(
				_actor, 
				_context, 
				name, 
				title
			);
			_telemetryClient.TrackEvent(
	            nameof(PersonActivated),
	            new System.Collections.Generic.Dictionary<string, string>()
	            {
	                {"ActorType", _actor.GetType().ToString()},
                    {"ActorId", _actor.Id.ToString()},
                    {"ApplicationTypeName", _actor.ActorService.Context.CodePackageActivationContext.ApplicationTypeName},
                    {"ApplicationName", _actor.ActorService.Context.CodePackageActivationContext.ApplicationName},
                    {"ServiceTypeName", _actor.ActorService.Context.ServiceTypeName},
                    {"ServiceName", _actor.ActorService.Context.ServiceName.ToString()},
                    {"PartitionId", _actor.ActorService.Context.PartitionId.ToString()},
                    {"ReplicaOrInstanceId", _actor.ActorService.Context.ReplicaId.ToString()},
                    {"NodeName", _actor.ActorService.Context.NodeContext.NodeName},
                    {"CorrelationId", FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["correlationId"]},
                    {"UserId", FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["userId"]},
                    {"RequestUri", FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["requestUri"]},
                    {"Name", name},
                    {"Title", title}
	            });
    
		}



		public void PersonLoaded(
			)
		{
			PersonActorServiceEventSource.Current.PersonLoaded(
				_actor, 
				_context
			);
			_telemetryClient.TrackEvent(
	            nameof(PersonLoaded),
	            new System.Collections.Generic.Dictionary<string, string>()
	            {
	                {"ActorType", _actor.GetType().ToString()},
                    {"ActorId", _actor.Id.ToString()},
                    {"ApplicationTypeName", _actor.ActorService.Context.CodePackageActivationContext.ApplicationTypeName},
                    {"ApplicationName", _actor.ActorService.Context.CodePackageActivationContext.ApplicationName},
                    {"ServiceTypeName", _actor.ActorService.Context.ServiceTypeName},
                    {"ServiceName", _actor.ActorService.Context.ServiceName.ToString()},
                    {"PartitionId", _actor.ActorService.Context.PartitionId.ToString()},
                    {"ReplicaOrInstanceId", _actor.ActorService.Context.ReplicaId.ToString()},
                    {"NodeName", _actor.ActorService.Context.NodeContext.NodeName},
                    {"CorrelationId", FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["correlationId"]},
                    {"UserId", FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["userId"]},
                    {"RequestUri", FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["requestUri"]}
	            });
    
		}



		public void TitleSet(
			string title)
		{
			PersonActorServiceEventSource.Current.TitleSet(
				_actor, 
				_context, 
				title
			);
			_telemetryClient.TrackEvent(
	            nameof(TitleSet),
	            new System.Collections.Generic.Dictionary<string, string>()
	            {
	                {"ActorType", _actor.GetType().ToString()},
                    {"ActorId", _actor.Id.ToString()},
                    {"ApplicationTypeName", _actor.ActorService.Context.CodePackageActivationContext.ApplicationTypeName},
                    {"ApplicationName", _actor.ActorService.Context.CodePackageActivationContext.ApplicationName},
                    {"ServiceTypeName", _actor.ActorService.Context.ServiceTypeName},
                    {"ServiceName", _actor.ActorService.Context.ServiceName.ToString()},
                    {"PartitionId", _actor.ActorService.Context.PartitionId.ToString()},
                    {"ReplicaOrInstanceId", _actor.ActorService.Context.ReplicaId.ToString()},
                    {"NodeName", _actor.ActorService.Context.NodeContext.NodeName},
                    {"CorrelationId", FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["correlationId"]},
                    {"UserId", FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["userId"]},
                    {"RequestUri", FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["requestUri"]},
                    {"Title", title}
	            });
    
		}



	}
}
