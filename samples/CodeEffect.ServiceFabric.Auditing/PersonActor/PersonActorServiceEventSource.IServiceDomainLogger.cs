/*******************************************************************************************
*  This class is autogenerated from the class ServiceDomainLogger
*  Do not directly update this class as changes will be lost on rebuild.
*******************************************************************************************/
using System;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;

namespace PersonActor
{
	internal sealed partial class PersonActorServiceEventSource
	{

		private const int PersonGeneratedEventId = 201;

		[Event(PersonGeneratedEventId, Level = EventLevel.LogAlways, Message = "Person Generated {11} {12}", Keywords = Keywords.ServiceDomain)]
		private void PersonGenerated(
			string actorType, 
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
				PersonGeneratedEventId, 
				actorType, 
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
		public void PersonGenerated(
			Microsoft.ServiceFabric.Actors.Runtime.ActorService actorService, 
			FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext context, 
			string name, 
			string title)
		{
			if (this.IsEnabled())
			{
				PersonGenerated(
					actorService.ActorTypeInformation.ImplementationType.ToString(), 
					actorService.Context.CodePackageActivationContext.ApplicationTypeName, 
					actorService.Context.CodePackageActivationContext.ApplicationName, 
					actorService.Context.ServiceTypeName, 
					actorService.Context.ServiceName.ToString(), 
					actorService.Context.PartitionId, 
					actorService.Context.ReplicaId, 
					actorService.Context.NodeContext.NodeName, 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["correlationId"], 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["userId"], 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["requestUri"], 
					name, 
					title);
			}
		}


		private const int StartRunAsyncLoopEventId = 402;

		[Event(StartRunAsyncLoopEventId, Level = EventLevel.LogAlways, Message = "Start Run Async Loop", Keywords = Keywords.ServiceDomain, Opcode = EventOpcode.Start)]
		private void StartRunAsyncLoop(
			string actorType, 
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
				StartRunAsyncLoopEventId, 
				actorType, 
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
		public void StartRunAsyncLoop(
			Microsoft.ServiceFabric.Actors.Runtime.ActorService actorService, 
			FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext context)
		{
			if (this.IsEnabled())
			{
				StartRunAsyncLoop(
					actorService.ActorTypeInformation.ImplementationType.ToString(), 
					actorService.Context.CodePackageActivationContext.ApplicationTypeName, 
					actorService.Context.CodePackageActivationContext.ApplicationName, 
					actorService.Context.ServiceTypeName, 
					actorService.Context.ServiceName.ToString(), 
					actorService.Context.PartitionId, 
					actorService.Context.ReplicaId, 
					actorService.Context.NodeContext.NodeName, 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["correlationId"], 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["userId"], 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["requestUri"]);
			}
		}


		private const int StopRunAsyncLoopEventId = 603;

		[Event(StopRunAsyncLoopEventId, Level = EventLevel.LogAlways, Message = "Stop Run Async Loop", Keywords = Keywords.ServiceDomain, Opcode = EventOpcode.Stop)]
		private void StopRunAsyncLoop(
			string actorType, 
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
				StopRunAsyncLoopEventId, 
				actorType, 
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
		public void StopRunAsyncLoop(
			Microsoft.ServiceFabric.Actors.Runtime.ActorService actorService, 
			FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext context)
		{
			if (this.IsEnabled())
			{
				StopRunAsyncLoop(
					actorService.ActorTypeInformation.ImplementationType.ToString(), 
					actorService.Context.CodePackageActivationContext.ApplicationTypeName, 
					actorService.Context.CodePackageActivationContext.ApplicationName, 
					actorService.Context.ServiceTypeName, 
					actorService.Context.ServiceName.ToString(), 
					actorService.Context.PartitionId, 
					actorService.Context.ReplicaId, 
					actorService.Context.NodeContext.NodeName, 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["correlationId"], 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["userId"], 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["requestUri"]);
			}
		}


		private const int RunAsyncLoopFailedEventId = 804;

		[Event(RunAsyncLoopFailedEventId, Level = EventLevel.LogAlways, Message = "{11}", Keywords = Keywords.ServiceDomain)]
		private void RunAsyncLoopFailed(
			string actorType, 
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
			string message, 
			string source, 
			string exceptionTypeName, 
			string exception)
		{
			WriteEvent(
				RunAsyncLoopFailedEventId, 
				actorType, 
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
				message, 
				source, 
				exceptionTypeName, 
				exception);
		}

		[NonEvent]
		public void RunAsyncLoopFailed(
			Microsoft.ServiceFabric.Actors.Runtime.ActorService actorService, 
			FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext context, 
			System.Exception ex)
		{
			if (this.IsEnabled())
			{
				RunAsyncLoopFailed(
					actorService.ActorTypeInformation.ImplementationType.ToString(), 
					actorService.Context.CodePackageActivationContext.ApplicationTypeName, 
					actorService.Context.CodePackageActivationContext.ApplicationName, 
					actorService.Context.ServiceTypeName, 
					actorService.Context.ServiceName.ToString(), 
					actorService.Context.PartitionId, 
					actorService.Context.ReplicaId, 
					actorService.Context.NodeContext.NodeName, 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["correlationId"], 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["userId"], 
					FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestContext.Current?["requestUri"], 
					ex.Message, 
					ex.Source, 
					ex.GetType().FullName, 
					ex.AsJson());
			}
		}


	}
}