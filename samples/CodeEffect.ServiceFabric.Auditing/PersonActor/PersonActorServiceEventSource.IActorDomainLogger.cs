/*******************************************************************************************
*  This class is autogenerated from the class ActorDomainLogger
*  Do not directly update this class as changes will be lost on rebuild.
*******************************************************************************************/
using System;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;

namespace PersonActor
{
	internal sealed partial class PersonActorServiceEventSource
	{

		private const int PersonActivatedEventId = 101;

		[Event(PersonActivatedEventId, Level = EventLevel.LogAlways, Message = "Person Activated {12} {13}", Keywords = Keywords.ActorDomain)]
		private void PersonActivated(
			string actorType, 
			string actorId, 
			string applicationTypeName, 
			string applicationName, 
			string serviceTypeName, 
			string serviceName, 
			Guid partitionId, 
			long replicaOrInstanceId, 
			string nodeName, 
			string correlationId, 
			string userId, 
			string requestUri, 
			string name, 
			string title)
		{
			WriteEvent(
				PersonActivatedEventId, 
				actorType, 
				actorId, 
				applicationTypeName, 
				applicationName, 
				serviceTypeName, 
				serviceName, 
				partitionId, 
				replicaOrInstanceId, 
				nodeName, 
				correlationId, 
				userId, 
				requestUri, 
				name, 
				title);
		}

		[NonEvent]
		public void PersonActivated(
			Microsoft.ServiceFabric.Actors.Runtime.Actor actor, 
			FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext context, 
			string name, 
			string title)
		{
			if (this.IsEnabled())
			{
				PersonActivated(
					actor.GetType().ToString(), 
					actor.Id.ToString(), 
					actor.ActorService.Context.CodePackageActivationContext.ApplicationTypeName, 
					actor.ActorService.Context.CodePackageActivationContext.ApplicationName, 
					actor.ActorService.Context.ServiceTypeName, 
					actor.ActorService.Context.ServiceName.ToString(), 
					actor.ActorService.Context.PartitionId, 
					actor.ActorService.Context.ReplicaId, 
					actor.ActorService.Context.NodeContext.NodeName, 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["correlationId"], 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["userId"], 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["requestUri"], 
					name, 
					title);
			}
		}


		private const int PersonLoadedEventId = 202;

		[Event(PersonLoadedEventId, Level = EventLevel.LogAlways, Message = "Person Loaded", Keywords = Keywords.ActorDomain)]
		private void PersonLoaded(
			string actorType, 
			string actorId, 
			string applicationTypeName, 
			string applicationName, 
			string serviceTypeName, 
			string serviceName, 
			Guid partitionId, 
			long replicaOrInstanceId, 
			string nodeName, 
			string correlationId, 
			string userId, 
			string requestUri)
		{
			WriteEvent(
				PersonLoadedEventId, 
				actorType, 
				actorId, 
				applicationTypeName, 
				applicationName, 
				serviceTypeName, 
				serviceName, 
				partitionId, 
				replicaOrInstanceId, 
				nodeName, 
				correlationId, 
				userId, 
				requestUri);
		}

		[NonEvent]
		public void PersonLoaded(
			Microsoft.ServiceFabric.Actors.Runtime.Actor actor, 
			FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext context)
		{
			if (this.IsEnabled())
			{
				PersonLoaded(
					actor.GetType().ToString(), 
					actor.Id.ToString(), 
					actor.ActorService.Context.CodePackageActivationContext.ApplicationTypeName, 
					actor.ActorService.Context.CodePackageActivationContext.ApplicationName, 
					actor.ActorService.Context.ServiceTypeName, 
					actor.ActorService.Context.ServiceName.ToString(), 
					actor.ActorService.Context.PartitionId, 
					actor.ActorService.Context.ReplicaId, 
					actor.ActorService.Context.NodeContext.NodeName, 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["correlationId"], 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["userId"], 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["requestUri"]);
			}
		}


		private const int TitleSetEventId = 303;

		[Event(TitleSetEventId, Level = EventLevel.LogAlways, Message = "Title Set {12}", Keywords = Keywords.ActorDomain)]
		private void TitleSet(
			string actorType, 
			string actorId, 
			string applicationTypeName, 
			string applicationName, 
			string serviceTypeName, 
			string serviceName, 
			Guid partitionId, 
			long replicaOrInstanceId, 
			string nodeName, 
			string correlationId, 
			string userId, 
			string requestUri, 
			string title)
		{
			WriteEvent(
				TitleSetEventId, 
				actorType, 
				actorId, 
				applicationTypeName, 
				applicationName, 
				serviceTypeName, 
				serviceName, 
				partitionId, 
				replicaOrInstanceId, 
				nodeName, 
				correlationId, 
				userId, 
				requestUri, 
				title);
		}

		[NonEvent]
		public void TitleSet(
			Microsoft.ServiceFabric.Actors.Runtime.Actor actor, 
			FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext context, 
			string title)
		{
			if (this.IsEnabled())
			{
				TitleSet(
					actor.GetType().ToString(), 
					actor.Id.ToString(), 
					actor.ActorService.Context.CodePackageActivationContext.ApplicationTypeName, 
					actor.ActorService.Context.CodePackageActivationContext.ApplicationName, 
					actor.ActorService.Context.ServiceTypeName, 
					actor.ActorService.Context.ServiceName.ToString(), 
					actor.ActorService.Context.PartitionId, 
					actor.ActorService.Context.ReplicaId, 
					actor.ActorService.Context.NodeContext.NodeName, 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["correlationId"], 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["userId"], 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["requestUri"], 
					title);
			}
		}


	}
}