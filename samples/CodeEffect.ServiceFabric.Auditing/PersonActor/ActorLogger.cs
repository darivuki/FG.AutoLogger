/*******************************************************************************************
*  This class is autogenerated from the class ActorLogger
*  Do not directly update this class as changes will be lost on rebuild.
*******************************************************************************************/
using System;
using PersonActor.Diagnostics;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using CodeEffect.Diagnostics.EventSourceGenerator.AI;


namespace PersonActor
{
	internal sealed class ActorLogger : IActorLogger
	{
		private readonly FG.ServiceFabric.Diagnostics.ActorOrActorServiceDescription _actor;
		private readonly Microsoft.ApplicationInsights.TelemetryClient _telemetryClient;

		public ActorLogger(
			FG.ServiceFabric.Diagnostics.ActorOrActorServiceDescription actor)
		{
			_actor = actor;
			
            _telemetryClient = new Microsoft.ApplicationInsights.TelemetryClient();
            _telemetryClient.Context.User.Id = Environment.UserName;
            _telemetryClient.Context.Session.Id = Guid.NewGuid().ToString();
            _telemetryClient.Context.Device.OperatingSystem = Environment.OSVersion.ToString();

		}

		public void StartActorActive(
			bool firstActivation)
		{
			PersonActorServiceEventSource.Current.StartActorActive(
				_actor, 
				firstActivation
			);

			var actorActiveOperationHolder = _telemetryClient.StartOperation<RequestTelemetry>("actorActive");
	       actorActiveOperationHolder.Telemetry.Properties.Add("ActorType", _actor.ActorType.ToString());
			actorActiveOperationHolder.Telemetry.Properties.Add("ActorId", _actor.ActorId.ToString());
			actorActiveOperationHolder.Telemetry.Properties.Add("ApplicationTypeName", _actor.ApplicationTypeName);
			actorActiveOperationHolder.Telemetry.Properties.Add("ApplicationName", _actor.ApplicationName);
			actorActiveOperationHolder.Telemetry.Properties.Add("ServiceTypeName", _actor.ServiceTypeName);
			actorActiveOperationHolder.Telemetry.Properties.Add("ServiceName", _actor.ToString());
			actorActiveOperationHolder.Telemetry.Properties.Add("PartitionId", _actor.PartitionId.ToString());
			actorActiveOperationHolder.Telemetry.Properties.Add("ReplicaOrInstanceId", _actor.ReplicaOrInstanceId.ToString());
			actorActiveOperationHolder.Telemetry.Properties.Add("NodeName", _actor.NodeName);
			actorActiveOperationHolder.Telemetry.Properties.Add("FirstActivation", firstActivation.ToString());
	       OperationHolder.StartOperation(actorActiveOperationHolder);
    
		}



		public void StopActorActive(
			)
		{
			PersonActorServiceEventSource.Current.StopActorActive(
				_actor
			);
	        var actorActiveOperationHolder = OperationHolder.StopOperation();
			_telemetryClient.StopOperation(actorActiveOperationHolder);
			actorActiveOperationHolder.Dispose();
    
		}



		public System.IDisposable ReadState(
			string stateName)
		{
			PersonActorServiceEventSource.Current.StartReadState(
				_actor, 
				stateName
			);

			var readStateOperationHolder = _telemetryClient.StartOperation<RequestTelemetry>("readState");
			readStateOperationHolder.Telemetry.Properties.Add("ActorType", _actor.ActorType.ToString());
			readStateOperationHolder.Telemetry.Properties.Add("ActorId", _actor.ActorId.ToString());
			readStateOperationHolder.Telemetry.Properties.Add("ApplicationTypeName", _actor.ApplicationTypeName);
			readStateOperationHolder.Telemetry.Properties.Add("ApplicationName", _actor.ApplicationName);
			readStateOperationHolder.Telemetry.Properties.Add("ServiceTypeName", _actor.ServiceTypeName);
			readStateOperationHolder.Telemetry.Properties.Add("ServiceName", _actor.ToString());
			readStateOperationHolder.Telemetry.Properties.Add("PartitionId", _actor.PartitionId.ToString());
			readStateOperationHolder.Telemetry.Properties.Add("ReplicaOrInstanceId", _actor.ReplicaOrInstanceId.ToString());
			readStateOperationHolder.Telemetry.Properties.Add("NodeName", _actor.NodeName);
			readStateOperationHolder.Telemetry.Properties.Add("StateName", stateName);
			return new ScopeWrapper<RequestTelemetry>(_telemetryClient, readStateOperationHolder, () => StopReadState(stateName));
    
		}



		public void StopReadState(
			string stateName)
		{
			PersonActorServiceEventSource.Current.StopReadState(
				_actor, 
				stateName
			);
    
		}



		public System.IDisposable WriteState(
			string stateName)
		{
			PersonActorServiceEventSource.Current.StartWriteState(
				_actor, 
				stateName
			);

			var writeStateOperationHolder = _telemetryClient.StartOperation<RequestTelemetry>("writeState");
			writeStateOperationHolder.Telemetry.Properties.Add("ActorType", _actor.ActorType.ToString());
			writeStateOperationHolder.Telemetry.Properties.Add("ActorId", _actor.ActorId.ToString());
			writeStateOperationHolder.Telemetry.Properties.Add("ApplicationTypeName", _actor.ApplicationTypeName);
			writeStateOperationHolder.Telemetry.Properties.Add("ApplicationName", _actor.ApplicationName);
			writeStateOperationHolder.Telemetry.Properties.Add("ServiceTypeName", _actor.ServiceTypeName);
			writeStateOperationHolder.Telemetry.Properties.Add("ServiceName", _actor.ToString());
			writeStateOperationHolder.Telemetry.Properties.Add("PartitionId", _actor.PartitionId.ToString());
			writeStateOperationHolder.Telemetry.Properties.Add("ReplicaOrInstanceId", _actor.ReplicaOrInstanceId.ToString());
			writeStateOperationHolder.Telemetry.Properties.Add("NodeName", _actor.NodeName);
			writeStateOperationHolder.Telemetry.Properties.Add("StateName", stateName);
			return new ScopeWrapper<RequestTelemetry>(_telemetryClient, writeStateOperationHolder, () => StopWriteState(stateName));
    
		}



		public void StopWriteState(
			string stateName)
		{
			PersonActorServiceEventSource.Current.StopWriteState(
				_actor, 
				stateName
			);
    
		}



		public void ActorHostInitializationFailed(
			System.Exception ex)
		{
			PersonActorServiceEventSource.Current.ActorHostInitializationFailed(
				_actor, 
				ex
			);
			_telemetryClient.TrackException(
	            ex,
	            new System.Collections.Generic.Dictionary<string, string>()
	            {
                    { "Name", "ActorHostInitializationFailed" },
	                {"ActorType", _actor.ActorType.ToString()},
                    {"ActorId", _actor.ActorId.ToString()},
                    {"ApplicationTypeName", _actor.ApplicationTypeName},
                    {"ApplicationName", _actor.ApplicationName},
                    {"ServiceTypeName", _actor.ServiceTypeName},
                    {"ServiceName", _actor.ToString()},
                    {"PartitionId", _actor.PartitionId.ToString()},
                    {"ReplicaOrInstanceId", _actor.ReplicaOrInstanceId.ToString()},
                    {"NodeName", _actor.NodeName},
                    {"Message", ex.Message},
                    {"Source", ex.Source},
                    {"ExceptionTypeName", ex.GetType().FullName},
                    {"Exception", ex.AsJson()}
	            });
    
		}



	}
}
