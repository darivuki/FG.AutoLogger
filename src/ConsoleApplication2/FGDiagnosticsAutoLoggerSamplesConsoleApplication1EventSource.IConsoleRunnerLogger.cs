/*******************************************************************************************
*  This class is autogenerated from the class ConsoleRunnerLogger
*  Do not directly update this class as changes will be lost on rebuild.
*******************************************************************************************/
using System;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;

namespace Ce.Labs.Samples
{
	internal sealed partial class FGDiagnosticsAutoLoggerSamplesConsoleApplication1EventSource
	{

		private const int RunnerCreatedEventId = 2001;

		[Event(RunnerCreatedEventId, Level = EventLevel.LogAlways, Message = "Runner Created", Keywords = Keywords.ConsoleRunner)]
		public void RunnerCreated(
			bool autogenerated, 
			string machineName)
		{
			WriteEvent(
				RunnerCreatedEventId, 
				autogenerated, 
				machineName);
		}


		private const int RunnerDestroyedEventId = 2002;

		[Event(RunnerDestroyedEventId, Level = EventLevel.LogAlways, Message = "Runner Destroyed", Keywords = Keywords.ConsoleRunner)]
		public void RunnerDestroyed(
			bool autogenerated, 
			string machineName)
		{
			WriteEvent(
				RunnerDestroyedEventId, 
				autogenerated, 
				machineName);
		}


		private const int WaitingForKeyPressEventId = 2003;

		[Event(WaitingForKeyPressEventId, Level = EventLevel.LogAlways, Message = "Waiting For Key Press", Keywords = Keywords.ConsoleRunner)]
		public void WaitingForKeyPress(
			bool autogenerated, 
			string machineName)
		{
			WriteEvent(
				WaitingForKeyPressEventId, 
				autogenerated, 
				machineName);
		}


		private const int KeyPressedEventId = 2004;

		[Event(KeyPressedEventId, Level = EventLevel.LogAlways, Message = "Key Pressed {2}", Keywords = Keywords.ConsoleRunner)]
		private void KeyPressed(
			bool autogenerated, 
			string machineName, 
			string key)
		{
			WriteEvent(
				KeyPressedEventId, 
				autogenerated, 
				machineName, 
				key);
		}

		[NonEvent]
		public void KeyPressed(
			bool autogenerated, 
			string machineName, 
			System.ConsoleKey key)
		{
			if (this.IsEnabled())
			{
				KeyPressed(
					autogenerated, 
					Environment.MachineName, 
					key.ToString());
			}
		}


		private const int UnsupportedKeyErrorEventId = 2005;

		[Event(UnsupportedKeyErrorEventId, Level = EventLevel.LogAlways, Message = "{2}", Keywords = Keywords.ConsoleRunner | Keywords.Error)]
		private void UnsupportedKeyError(
			bool autogenerated, 
			string machineName, 
			string message, 
			string source, 
			string exceptionTypeName, 
			string exception)
		{
			WriteEvent(
				UnsupportedKeyErrorEventId, 
				autogenerated, 
				machineName, 
				message, 
				source, 
				exceptionTypeName, 
				exception);
		}

		[NonEvent]
		public void UnsupportedKeyError(
			bool autogenerated, 
			string machineName, 
			System.Exception ex)
		{
			if (this.IsEnabled())
			{
				UnsupportedKeyError(
					autogenerated, 
					Environment.MachineName, 
					ex.Message, 
					ex.Source, 
					ex.GetType().FullName, 
					ex.AsJson());
			}
		}


		private const int StartLoopEventId = 2006;

		[Event(StartLoopEventId, Level = EventLevel.LogAlways, Message = "Start Loop", Keywords = Keywords.ConsoleRunner, Opcode = EventOpcode.Start)]
		public void StartLoop(
			bool autogenerated, 
			string machineName)
		{
			WriteEvent(
				StartLoopEventId, 
				autogenerated, 
				machineName);
		}


		private const int StopLoopEventId = 2007;

		[Event(StopLoopEventId, Level = EventLevel.LogAlways, Message = "Stop Loop", Keywords = Keywords.ConsoleRunner, Opcode = EventOpcode.Stop)]
		public void StopLoop(
			bool autogenerated, 
			string machineName)
		{
			WriteEvent(
				StopLoopEventId, 
				autogenerated, 
				machineName);
		}


		private const int RandomIntsGeneratedEventId = 2008;

		[Event(RandomIntsGeneratedEventId, Level = EventLevel.LogAlways, Message = "Random Ints Generated {2}", Keywords = Keywords.ConsoleRunner)]
		private void RandomIntsGenerated(
			bool autogenerated, 
			string machineName, 
			string values)
		{
			WriteEvent(
				RandomIntsGeneratedEventId, 
				autogenerated, 
				machineName, 
				values);
		}

		[NonEvent]
		public void RandomIntsGenerated(
			bool autogenerated, 
			string machineName, 
			int[] values)
		{
			if (this.IsEnabled())
			{
				RandomIntsGenerated(
					autogenerated, 
					Environment.MachineName, 
					values.ToString());
			}
		}


	}
}