/*******************************************************************************************
*  This class is autogenerated from the class DefaultEventSource.eventsource.json
*  Do not directly update this class as changes will be lost on rebuild.
*******************************************************************************************/
using System;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;

namespace StatelessRunnerService
{
	[EventSource(Name = "StatelessRunnerService-Default")]
	internal sealed partial class DefaultEventSource : EventSource
	{
		public static readonly DefaultEventSource Current = new DefaultEventSource();

		static DefaultEventSource()
		{
			// A workaround for the problem where ETW activities do not 
			// get tracked until Tasks infrastructure is initialized.
			// This problem will be fixed in .NET Framework 4.6.2.
			Task.Run(() => { });
		}

		// Instance constructor is private to enforce singleton semantics
		private DefaultEventSource() : base() { }

		#region Keywords
		// Event keywords can be used to categorize events. 
		// Each keyword is a bit flag. A single event can be 
		// associated with multiple keywords (via EventAttribute.Keywords property).
		// Keywords must be defined as a public class named 'Keywords' 
		// inside EventSource that uses them.
		public static class Keywords
		{
			public const EventKeywords StatelessRunnerService = (EventKeywords)0x1L;

		}
		#endregion Keywords

		#region Events



		#endregion Events
	}


	internal static class DefaultEventSourceHelpers
	{

            public static long GetReplicaOrInstanceId(this System.Fabric.ServiceContext context)
            {
                var stateless = context as System.Fabric.StatelessServiceContext;
                if (stateless != null)
                {
                    return stateless.InstanceId;
                }

                var stateful = context as System.Fabric.StatefulServiceContext;
                if (stateful != null)
                {
                    return stateful.ReplicaId;
                }

                throw new NotSupportedException("Context type not supported.");
            }


	}

}