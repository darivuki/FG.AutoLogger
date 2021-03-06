/*******************************************************************************************
*  This class is autogenerated from the class CommunicationLogger
*  Do not directly update this class as changes will be lost on rebuild.
*******************************************************************************************/
using System;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;

namespace TitleService
{
	internal sealed partial class TitleActorServiceEventSource
	{

		private const int StartRecieveServiceMessageEventId = 1001;

		[Event(StartRecieveServiceMessageEventId, Level = EventLevel.LogAlways, Message = "Start Recieve Service Message {7} {8} {9} {10} {11} {12}", Keywords = Keywords.Communication, Opcode = EventOpcode.Start, Task = Tasks.RecieveServiceMessage)]
		private void StartRecieveServiceMessage(
			string serviceName, 
			string serviceTypeName, 
			long replicaOrInstanceId, 
			Guid partitionId, 
			string applicationName, 
			string applicationTypeName, 
			string nodeName, 
			string requestUri, 
			string serviceMethodName, 
			int InterfaceId, 
			int MethodId, 
			string userId, 
			string correlationId)
		{
			WriteEvent(
				StartRecieveServiceMessageEventId, 
				serviceName, 
				serviceTypeName, 
				replicaOrInstanceId, 
				partitionId, 
				applicationName, 
				applicationTypeName, 
				nodeName, 
				requestUri, 
				serviceMethodName, 
				InterfaceId, 
				MethodId, 
				userId, 
				correlationId);
		}

		[NonEvent]
		public void StartRecieveServiceMessage(
			System.Fabric.StatefulServiceContext context, 
			System.Uri requestUri, 
			string serviceMethodName, 
			Microsoft.ServiceFabric.Services.Remoting.ServiceRemotingMessageHeaders serviceMessageHeaders, 
			FG.ServiceFabric.Services.Remoting.FabricTransport.CustomServiceRequestHeader customServiceRequestHeader)
		{
			if (this.IsEnabled())
			{
				StartRecieveServiceMessage(
					context.ServiceName.ToString(), 
					context.ServiceTypeName, 
					context.ReplicaOrInstanceId, 
					context.PartitionId, 
					context.CodePackageActivationContext.ApplicationName, 
					context.CodePackageActivationContext.ApplicationTypeName, 
					context.NodeContext.NodeName, 
					requestUri.ToString(), 
					serviceMethodName, 
					(serviceMessageHeaders?.InterfaceId ?? 0), 
					(serviceMessageHeaders?.MethodId ?? 0), 
					customServiceRequestHeader?.GetHeader("userId"), 
					customServiceRequestHeader?.GetHeader("correlationId"));
			}
		}


		private const int StopRecieveServiceMessageEventId = 2002;

		[Event(StopRecieveServiceMessageEventId, Level = EventLevel.LogAlways, Message = "Stop Recieve Service Message {7} {8} {9} {10} {11} {12}", Keywords = Keywords.Communication, Opcode = EventOpcode.Stop, Task = Tasks.RecieveServiceMessage)]
		private void StopRecieveServiceMessage(
			string serviceName, 
			string serviceTypeName, 
			long replicaOrInstanceId, 
			Guid partitionId, 
			string applicationName, 
			string applicationTypeName, 
			string nodeName, 
			string requestUri, 
			string serviceMethodName, 
			int InterfaceId, 
			int MethodId, 
			string userId, 
			string correlationId)
		{
			WriteEvent(
				StopRecieveServiceMessageEventId, 
				serviceName, 
				serviceTypeName, 
				replicaOrInstanceId, 
				partitionId, 
				applicationName, 
				applicationTypeName, 
				nodeName, 
				requestUri, 
				serviceMethodName, 
				InterfaceId, 
				MethodId, 
				userId, 
				correlationId);
		}

		[NonEvent]
		public void StopRecieveServiceMessage(
			System.Fabric.StatefulServiceContext context, 
			System.Uri requestUri, 
			string serviceMethodName, 
			Microsoft.ServiceFabric.Services.Remoting.ServiceRemotingMessageHeaders serviceMessageHeaders, 
			FG.ServiceFabric.Services.Remoting.FabricTransport.CustomServiceRequestHeader customServiceRequestHeader)
		{
			if (this.IsEnabled())
			{
				StopRecieveServiceMessage(
					context.ServiceName.ToString(), 
					context.ServiceTypeName, 
					context.ReplicaOrInstanceId, 
					context.PartitionId, 
					context.CodePackageActivationContext.ApplicationName, 
					context.CodePackageActivationContext.ApplicationTypeName, 
					context.NodeContext.NodeName, 
					requestUri.ToString(), 
					serviceMethodName, 
					(serviceMessageHeaders?.InterfaceId ?? 0), 
					(serviceMessageHeaders?.MethodId ?? 0), 
					customServiceRequestHeader?.GetHeader("userId"), 
					customServiceRequestHeader?.GetHeader("correlationId"));
			}
		}


		private const int RecieveServiceMessageFailedEventId = 3003;

		[Event(RecieveServiceMessageFailedEventId, Level = EventLevel.LogAlways, Message = "{13}", Keywords = Keywords.Communication)]
		private void RecieveServiceMessageFailed(
			string serviceName, 
			string serviceTypeName, 
			long replicaOrInstanceId, 
			Guid partitionId, 
			string applicationName, 
			string applicationTypeName, 
			string nodeName, 
			string requestUri, 
			string serviceMethodName, 
			int InterfaceId, 
			int MethodId, 
			string userId, 
			string correlationId, 
			string message, 
			string source, 
			string exceptionTypeName, 
			string exception)
		{
			WriteEvent(
				RecieveServiceMessageFailedEventId, 
				serviceName, 
				serviceTypeName, 
				replicaOrInstanceId, 
				partitionId, 
				applicationName, 
				applicationTypeName, 
				nodeName, 
				requestUri, 
				serviceMethodName, 
				InterfaceId, 
				MethodId, 
				userId, 
				correlationId, 
				message, 
				source, 
				exceptionTypeName, 
				exception);
		}

		[NonEvent]
		public void RecieveServiceMessageFailed(
			System.Fabric.StatefulServiceContext context, 
			System.Uri requestUri, 
			string serviceMethodName, 
			Microsoft.ServiceFabric.Services.Remoting.ServiceRemotingMessageHeaders serviceMessageHeaders, 
			FG.ServiceFabric.Services.Remoting.FabricTransport.CustomServiceRequestHeader customServiceRequestHeader, 
			System.Exception ex)
		{
			if (this.IsEnabled())
			{
				RecieveServiceMessageFailed(
					context.ServiceName.ToString(), 
					context.ServiceTypeName, 
					context.ReplicaOrInstanceId, 
					context.PartitionId, 
					context.CodePackageActivationContext.ApplicationName, 
					context.CodePackageActivationContext.ApplicationTypeName, 
					context.NodeContext.NodeName, 
					requestUri.ToString(), 
					serviceMethodName, 
					(serviceMessageHeaders?.InterfaceId ?? 0), 
					(serviceMessageHeaders?.MethodId ?? 0), 
					customServiceRequestHeader?.GetHeader("userId"), 
					customServiceRequestHeader?.GetHeader("correlationId"), 
					ex.Message, 
					ex.Source, 
					ex.GetType().FullName, 
					ex.AsJson());
			}
		}


		private const int FailedToGetServiceMethodNameEventId = 4004;

		[Event(FailedToGetServiceMethodNameEventId, Level = EventLevel.LogAlways, Message = "{10}", Keywords = Keywords.Communication)]
		private void FailedToGetServiceMethodName(
			string serviceName, 
			string serviceTypeName, 
			long replicaOrInstanceId, 
			Guid partitionId, 
			string applicationName, 
			string applicationTypeName, 
			string nodeName, 
			string requestUri, 
			int interfaceId, 
			int methodId, 
			string message, 
			string source, 
			string exceptionTypeName, 
			string exception)
		{
			WriteEvent(
				FailedToGetServiceMethodNameEventId, 
				serviceName, 
				serviceTypeName, 
				replicaOrInstanceId, 
				partitionId, 
				applicationName, 
				applicationTypeName, 
				nodeName, 
				requestUri, 
				interfaceId, 
				methodId, 
				message, 
				source, 
				exceptionTypeName, 
				exception);
		}

		[NonEvent]
		public void FailedToGetServiceMethodName(
			System.Fabric.StatefulServiceContext context, 
			System.Uri requestUri, 
			int interfaceId, 
			int methodId, 
			System.Exception ex)
		{
			if (this.IsEnabled())
			{
				FailedToGetServiceMethodName(
					context.ServiceName.ToString(), 
					context.ServiceTypeName, 
					context.ReplicaOrInstanceId, 
					context.PartitionId, 
					context.CodePackageActivationContext.ApplicationName, 
					context.CodePackageActivationContext.ApplicationTypeName, 
					context.NodeContext.NodeName, 
					requestUri.ToString(), 
					interfaceId, 
					methodId, 
					ex.Message, 
					ex.Source, 
					ex.GetType().FullName, 
					ex.AsJson());
			}
		}


		private const int StartRequestContextEventId = 5005;

		[Event(StartRequestContextEventId, Level = EventLevel.LogAlways, Message = "Start Request Context {7}", Keywords = Keywords.Communication, Opcode = EventOpcode.Start)]
		private void StartRequestContext(
			string serviceName, 
			string serviceTypeName, 
			long replicaOrInstanceId, 
			Guid partitionId, 
			string applicationName, 
			string applicationTypeName, 
			string nodeName, 
			string headers)
		{
			WriteEvent(
				StartRequestContextEventId, 
				serviceName, 
				serviceTypeName, 
				replicaOrInstanceId, 
				partitionId, 
				applicationName, 
				applicationTypeName, 
				nodeName, 
				headers);
		}

		[NonEvent]
		public void StartRequestContext(
			System.Fabric.StatefulServiceContext context, 
			System.Collections.Generic.IEnumerable<FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestHeader> headers)
		{
			if (this.IsEnabled())
			{
				StartRequestContext(
					context.ServiceName.ToString(), 
					context.ServiceTypeName, 
					context.ReplicaOrInstanceId, 
					context.PartitionId, 
					context.CodePackageActivationContext.ApplicationName, 
					context.CodePackageActivationContext.ApplicationTypeName, 
					context.NodeContext.NodeName, 
					headers.ToString());
			}
		}


		private const int StopRequestContextEventId = 6006;

		[Event(StopRequestContextEventId, Level = EventLevel.LogAlways, Message = "Stop Request Context {7}", Keywords = Keywords.Communication, Opcode = EventOpcode.Stop)]
		private void StopRequestContext(
			string serviceName, 
			string serviceTypeName, 
			long replicaOrInstanceId, 
			Guid partitionId, 
			string applicationName, 
			string applicationTypeName, 
			string nodeName, 
			string headers)
		{
			WriteEvent(
				StopRequestContextEventId, 
				serviceName, 
				serviceTypeName, 
				replicaOrInstanceId, 
				partitionId, 
				applicationName, 
				applicationTypeName, 
				nodeName, 
				headers);
		}

		[NonEvent]
		public void StopRequestContext(
			System.Fabric.StatefulServiceContext context, 
			System.Collections.Generic.IEnumerable<FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestHeader> headers)
		{
			if (this.IsEnabled())
			{
				StopRequestContext(
					context.ServiceName.ToString(), 
					context.ServiceTypeName, 
					context.ReplicaOrInstanceId, 
					context.PartitionId, 
					context.CodePackageActivationContext.ApplicationName, 
					context.CodePackageActivationContext.ApplicationTypeName, 
					context.NodeContext.NodeName, 
					headers.ToString());
			}
		}


		private const int FailedRequestContextEventId = 7007;

		[Event(FailedRequestContextEventId, Level = EventLevel.LogAlways, Message = "{8}", Keywords = Keywords.Communication)]
		private void FailedRequestContext(
			string serviceName, 
			string serviceTypeName, 
			long replicaOrInstanceId, 
			Guid partitionId, 
			string applicationName, 
			string applicationTypeName, 
			string nodeName, 
			string headers, 
			string message, 
			string source, 
			string exceptionTypeName, 
			string exception)
		{
			WriteEvent(
				FailedRequestContextEventId, 
				serviceName, 
				serviceTypeName, 
				replicaOrInstanceId, 
				partitionId, 
				applicationName, 
				applicationTypeName, 
				nodeName, 
				headers, 
				message, 
				source, 
				exceptionTypeName, 
				exception);
		}

		[NonEvent]
		public void FailedRequestContext(
			System.Fabric.StatefulServiceContext context, 
			System.Collections.Generic.IEnumerable<FG.ServiceFabric.Services.Remoting.FabricTransport.ServiceRequestHeader> headers, 
			System.Exception exception)
		{
			if (this.IsEnabled())
			{
				FailedRequestContext(
					context.ServiceName.ToString(), 
					context.ServiceTypeName, 
					context.ReplicaOrInstanceId, 
					context.PartitionId, 
					context.CodePackageActivationContext.ApplicationName, 
					context.CodePackageActivationContext.ApplicationTypeName, 
					context.NodeContext.NodeName, 
					headers.ToString(), 
					exception.Message, 
					exception.Source, 
					exception.GetType().FullName, 
					exception.AsJson());
			}
		}


		private const int FailedToReadCustomServiceMessageHeaderEventId = 8008;

		[Event(FailedToReadCustomServiceMessageHeaderEventId, Level = EventLevel.LogAlways, Message = "{9}", Keywords = Keywords.Communication)]
		private void FailedToReadCustomServiceMessageHeader(
			string serviceName, 
			string serviceTypeName, 
			long replicaOrInstanceId, 
			Guid partitionId, 
			string applicationName, 
			string applicationTypeName, 
			string nodeName, 
			int InterfaceId, 
			int MethodId, 
			string message, 
			string source, 
			string exceptionTypeName, 
			string exception)
		{
			WriteEvent(
				FailedToReadCustomServiceMessageHeaderEventId, 
				serviceName, 
				serviceTypeName, 
				replicaOrInstanceId, 
				partitionId, 
				applicationName, 
				applicationTypeName, 
				nodeName, 
				InterfaceId, 
				MethodId, 
				message, 
				source, 
				exceptionTypeName, 
				exception);
		}

		[NonEvent]
		public void FailedToReadCustomServiceMessageHeader(
			System.Fabric.StatefulServiceContext context, 
			Microsoft.ServiceFabric.Services.Remoting.ServiceRemotingMessageHeaders serviceRemotingMessageHeaders, 
			System.Exception ex)
		{
			if (this.IsEnabled())
			{
				FailedToReadCustomServiceMessageHeader(
					context.ServiceName.ToString(), 
					context.ServiceTypeName, 
					context.ReplicaOrInstanceId, 
					context.PartitionId, 
					context.CodePackageActivationContext.ApplicationName, 
					context.CodePackageActivationContext.ApplicationTypeName, 
					context.NodeContext.NodeName, 
					(serviceRemotingMessageHeaders?.InterfaceId ?? 0), 
					(serviceRemotingMessageHeaders?.MethodId ?? 0), 
					ex.Message, 
					ex.Source, 
					ex.GetType().FullName, 
					ex.AsJson());
			}
		}


		private const int EnumeratingPartitionsEventId = 9009;

		[Event(EnumeratingPartitionsEventId, Level = EventLevel.LogAlways, Message = "Enumerating Partitions {7}", Keywords = Keywords.Communication)]
		private void EnumeratingPartitions(
			string serviceName, 
			string serviceTypeName, 
			long replicaOrInstanceId, 
			Guid partitionId, 
			string applicationName, 
			string applicationTypeName, 
			string nodeName, 
			string serviceUri)
		{
			WriteEvent(
				EnumeratingPartitionsEventId, 
				serviceName, 
				serviceTypeName, 
				replicaOrInstanceId, 
				partitionId, 
				applicationName, 
				applicationTypeName, 
				nodeName, 
				serviceUri);
		}

		[NonEvent]
		public void EnumeratingPartitions(
			System.Fabric.StatefulServiceContext context, 
			System.Uri serviceUri)
		{
			if (this.IsEnabled())
			{
				EnumeratingPartitions(
					context.ServiceName.ToString(), 
					context.ServiceTypeName, 
					context.ReplicaOrInstanceId, 
					context.PartitionId, 
					context.CodePackageActivationContext.ApplicationName, 
					context.CodePackageActivationContext.ApplicationTypeName, 
					context.NodeContext.NodeName, 
					serviceUri.ToString());
			}
		}


		private const int FailedToEnumeratePartitionsEventId = 10010;

		[Event(FailedToEnumeratePartitionsEventId, Level = EventLevel.LogAlways, Message = "{8}", Keywords = Keywords.Communication)]
		private void FailedToEnumeratePartitions(
			string serviceName, 
			string serviceTypeName, 
			long replicaOrInstanceId, 
			Guid partitionId, 
			string applicationName, 
			string applicationTypeName, 
			string nodeName, 
			string serviceUri, 
			string message, 
			string source, 
			string exceptionTypeName, 
			string exception)
		{
			WriteEvent(
				FailedToEnumeratePartitionsEventId, 
				serviceName, 
				serviceTypeName, 
				replicaOrInstanceId, 
				partitionId, 
				applicationName, 
				applicationTypeName, 
				nodeName, 
				serviceUri, 
				message, 
				source, 
				exceptionTypeName, 
				exception);
		}

		[NonEvent]
		public void FailedToEnumeratePartitions(
			System.Fabric.StatefulServiceContext context, 
			System.Uri serviceUri, 
			System.Exception ex)
		{
			if (this.IsEnabled())
			{
				FailedToEnumeratePartitions(
					context.ServiceName.ToString(), 
					context.ServiceTypeName, 
					context.ReplicaOrInstanceId, 
					context.PartitionId, 
					context.CodePackageActivationContext.ApplicationName, 
					context.CodePackageActivationContext.ApplicationTypeName, 
					context.NodeContext.NodeName, 
					serviceUri.ToString(), 
					ex.Message, 
					ex.Source, 
					ex.GetType().FullName, 
					ex.AsJson());
			}
		}


		private const int EnumeratedExistingPartitionsEventId = 11011;

		[Event(EnumeratedExistingPartitionsEventId, Level = EventLevel.LogAlways, Message = "Enumerated Existing Partitions {7} {8}", Keywords = Keywords.Communication)]
		private void EnumeratedExistingPartitions(
			string serviceName, 
			string serviceTypeName, 
			long replicaOrInstanceId, 
			Guid partitionId, 
			string applicationName, 
			string applicationTypeName, 
			string nodeName, 
			string serviceUri, 
			string partitions)
		{
			WriteEvent(
				EnumeratedExistingPartitionsEventId, 
				serviceName, 
				serviceTypeName, 
				replicaOrInstanceId, 
				partitionId, 
				applicationName, 
				applicationTypeName, 
				nodeName, 
				serviceUri, 
				partitions);
		}

		[NonEvent]
		public void EnumeratedExistingPartitions(
			System.Fabric.StatefulServiceContext context, 
			System.Uri serviceUri, 
			System.Collections.Generic.IEnumerable<System.Fabric.ServicePartitionInformation> partitions)
		{
			if (this.IsEnabled())
			{
				EnumeratedExistingPartitions(
					context.ServiceName.ToString(), 
					context.ServiceTypeName, 
					context.ReplicaOrInstanceId, 
					context.PartitionId, 
					context.CodePackageActivationContext.ApplicationName, 
					context.CodePackageActivationContext.ApplicationTypeName, 
					context.NodeContext.NodeName, 
					serviceUri.ToString(), 
					partitions.ToString());
			}
		}


		private const int EnumeratedAndCachedPartitionsEventId = 12012;

		[Event(EnumeratedAndCachedPartitionsEventId, Level = EventLevel.LogAlways, Message = "Enumerated And Cached Partitions {7} {8}", Keywords = Keywords.Communication)]
		private void EnumeratedAndCachedPartitions(
			string serviceName, 
			string serviceTypeName, 
			long replicaOrInstanceId, 
			Guid partitionId, 
			string applicationName, 
			string applicationTypeName, 
			string nodeName, 
			string serviceUri, 
			string partitions)
		{
			WriteEvent(
				EnumeratedAndCachedPartitionsEventId, 
				serviceName, 
				serviceTypeName, 
				replicaOrInstanceId, 
				partitionId, 
				applicationName, 
				applicationTypeName, 
				nodeName, 
				serviceUri, 
				partitions);
		}

		[NonEvent]
		public void EnumeratedAndCachedPartitions(
			System.Fabric.StatefulServiceContext context, 
			System.Uri serviceUri, 
			System.Collections.Generic.IEnumerable<System.Fabric.ServicePartitionInformation> partitions)
		{
			if (this.IsEnabled())
			{
				EnumeratedAndCachedPartitions(
					context.ServiceName.ToString(), 
					context.ServiceTypeName, 
					context.ReplicaOrInstanceId, 
					context.PartitionId, 
					context.CodePackageActivationContext.ApplicationName, 
					context.CodePackageActivationContext.ApplicationTypeName, 
					context.NodeContext.NodeName, 
					serviceUri.ToString(), 
					partitions.ToString());
			}
		}


		private const int StartCallServiceEventId = 13013;

		[Event(StartCallServiceEventId, Level = EventLevel.LogAlways, Message = "Start Call Service {7} {8} {9} {10} {11} {12}", Keywords = Keywords.Communication, Opcode = EventOpcode.Start, Task = Tasks.CallService)]
		private void StartCallService(
			string serviceName, 
			string serviceTypeName, 
			long replicaOrInstanceId, 
			Guid partitionId, 
			string applicationName, 
			string applicationTypeName, 
			string nodeName, 
			string requestUri, 
			string serviceMethodName, 
			int InterfaceId, 
			int MethodId, 
			string userId, 
			string correlationId)
		{
			WriteEvent(
				StartCallServiceEventId, 
				serviceName, 
				serviceTypeName, 
				replicaOrInstanceId, 
				partitionId, 
				applicationName, 
				applicationTypeName, 
				nodeName, 
				requestUri, 
				serviceMethodName, 
				InterfaceId, 
				MethodId, 
				userId, 
				correlationId);
		}

		[NonEvent]
		public void StartCallService(
			System.Fabric.StatefulServiceContext context, 
			System.Uri requestUri, 
			string serviceMethodName, 
			Microsoft.ServiceFabric.Services.Remoting.ServiceRemotingMessageHeaders serviceMessageHeaders, 
			FG.ServiceFabric.Services.Remoting.FabricTransport.CustomServiceRequestHeader customServiceRequestHeader)
		{
			if (this.IsEnabled())
			{
				StartCallService(
					context.ServiceName.ToString(), 
					context.ServiceTypeName, 
					context.ReplicaOrInstanceId, 
					context.PartitionId, 
					context.CodePackageActivationContext.ApplicationName, 
					context.CodePackageActivationContext.ApplicationTypeName, 
					context.NodeContext.NodeName, 
					requestUri.ToString(), 
					serviceMethodName, 
					(serviceMessageHeaders?.InterfaceId ?? 0), 
					(serviceMessageHeaders?.MethodId ?? 0), 
					customServiceRequestHeader?.GetHeader("userId"), 
					customServiceRequestHeader?.GetHeader("correlationId"));
			}
		}


		private const int StopCallServiceEventId = 14014;

		[Event(StopCallServiceEventId, Level = EventLevel.LogAlways, Message = "Stop Call Service {7} {8} {9} {10} {11} {12}", Keywords = Keywords.Communication, Opcode = EventOpcode.Stop, Task = Tasks.CallService)]
		private void StopCallService(
			string serviceName, 
			string serviceTypeName, 
			long replicaOrInstanceId, 
			Guid partitionId, 
			string applicationName, 
			string applicationTypeName, 
			string nodeName, 
			string requestUri, 
			string serviceMethodName, 
			int InterfaceId, 
			int MethodId, 
			string userId, 
			string correlationId)
		{
			WriteEvent(
				StopCallServiceEventId, 
				serviceName, 
				serviceTypeName, 
				replicaOrInstanceId, 
				partitionId, 
				applicationName, 
				applicationTypeName, 
				nodeName, 
				requestUri, 
				serviceMethodName, 
				InterfaceId, 
				MethodId, 
				userId, 
				correlationId);
		}

		[NonEvent]
		public void StopCallService(
			System.Fabric.StatefulServiceContext context, 
			System.Uri requestUri, 
			string serviceMethodName, 
			Microsoft.ServiceFabric.Services.Remoting.ServiceRemotingMessageHeaders serviceMessageHeaders, 
			FG.ServiceFabric.Services.Remoting.FabricTransport.CustomServiceRequestHeader customServiceRequestHeader)
		{
			if (this.IsEnabled())
			{
				StopCallService(
					context.ServiceName.ToString(), 
					context.ServiceTypeName, 
					context.ReplicaOrInstanceId, 
					context.PartitionId, 
					context.CodePackageActivationContext.ApplicationName, 
					context.CodePackageActivationContext.ApplicationTypeName, 
					context.NodeContext.NodeName, 
					requestUri.ToString(), 
					serviceMethodName, 
					(serviceMessageHeaders?.InterfaceId ?? 0), 
					(serviceMessageHeaders?.MethodId ?? 0), 
					customServiceRequestHeader?.GetHeader("userId"), 
					customServiceRequestHeader?.GetHeader("correlationId"));
			}
		}


		private const int CallServiceFailedEventId = 15015;

		[Event(CallServiceFailedEventId, Level = EventLevel.LogAlways, Message = "{13}", Keywords = Keywords.Communication)]
		private void CallServiceFailed(
			string serviceName, 
			string serviceTypeName, 
			long replicaOrInstanceId, 
			Guid partitionId, 
			string applicationName, 
			string applicationTypeName, 
			string nodeName, 
			string requestUri, 
			string serviceMethodName, 
			int InterfaceId, 
			int MethodId, 
			string userId, 
			string correlationId, 
			string message, 
			string source, 
			string exceptionTypeName, 
			string exception)
		{
			WriteEvent(
				CallServiceFailedEventId, 
				serviceName, 
				serviceTypeName, 
				replicaOrInstanceId, 
				partitionId, 
				applicationName, 
				applicationTypeName, 
				nodeName, 
				requestUri, 
				serviceMethodName, 
				InterfaceId, 
				MethodId, 
				userId, 
				correlationId, 
				message, 
				source, 
				exceptionTypeName, 
				exception);
		}

		[NonEvent]
		public void CallServiceFailed(
			System.Fabric.StatefulServiceContext context, 
			System.Uri requestUri, 
			string serviceMethodName, 
			Microsoft.ServiceFabric.Services.Remoting.ServiceRemotingMessageHeaders serviceMessageHeaders, 
			FG.ServiceFabric.Services.Remoting.FabricTransport.CustomServiceRequestHeader customServiceRequestHeader, 
			System.Exception ex)
		{
			if (this.IsEnabled())
			{
				CallServiceFailed(
					context.ServiceName.ToString(), 
					context.ServiceTypeName, 
					context.ReplicaOrInstanceId, 
					context.PartitionId, 
					context.CodePackageActivationContext.ApplicationName, 
					context.CodePackageActivationContext.ApplicationTypeName, 
					context.NodeContext.NodeName, 
					requestUri.ToString(), 
					serviceMethodName, 
					(serviceMessageHeaders?.InterfaceId ?? 0), 
					(serviceMessageHeaders?.MethodId ?? 0), 
					customServiceRequestHeader?.GetHeader("userId"), 
					customServiceRequestHeader?.GetHeader("correlationId"), 
					ex.Message, 
					ex.Source, 
					ex.GetType().FullName, 
					ex.AsJson());
			}
		}


		private const int ServiceClientFailedEventId = 16016;

		[Event(ServiceClientFailedEventId, Level = EventLevel.LogAlways, Message = "{10}", Keywords = Keywords.Communication)]
		private void ServiceClientFailed(
			string serviceName, 
			string serviceTypeName, 
			long replicaOrInstanceId, 
			Guid partitionId, 
			string applicationName, 
			string applicationTypeName, 
			string nodeName, 
			string requestUri, 
			string userId, 
			string correlationId, 
			string message, 
			string source, 
			string exceptionTypeName, 
			string exception)
		{
			WriteEvent(
				ServiceClientFailedEventId, 
				serviceName, 
				serviceTypeName, 
				replicaOrInstanceId, 
				partitionId, 
				applicationName, 
				applicationTypeName, 
				nodeName, 
				requestUri, 
				userId, 
				correlationId, 
				message, 
				source, 
				exceptionTypeName, 
				exception);
		}

		[NonEvent]
		public void ServiceClientFailed(
			System.Fabric.StatefulServiceContext context, 
			System.Uri requestUri, 
			FG.ServiceFabric.Services.Remoting.FabricTransport.CustomServiceRequestHeader customServiceRequestHeader, 
			System.Exception ex)
		{
			if (this.IsEnabled())
			{
				ServiceClientFailed(
					context.ServiceName.ToString(), 
					context.ServiceTypeName, 
					context.ReplicaOrInstanceId, 
					context.PartitionId, 
					context.CodePackageActivationContext.ApplicationName, 
					context.CodePackageActivationContext.ApplicationTypeName, 
					context.NodeContext.NodeName, 
					requestUri.ToString(), 
					customServiceRequestHeader?.GetHeader("userId"), 
					customServiceRequestHeader?.GetHeader("correlationId"), 
					ex.Message, 
					ex.Source, 
					ex.GetType().FullName, 
					ex.AsJson());
			}
		}


	}
}