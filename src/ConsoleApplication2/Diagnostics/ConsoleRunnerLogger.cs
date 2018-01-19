/*******************************************************************************************
*  This class is autogenerated from the class ConsoleRunnerLogger
*  Do not directly update this class as changes will be lost on rebuild.
*******************************************************************************************/
using System;
using System.Collections.Generic;
using ConsoleApplication1.Loggers;


namespace ConsoleApplication1.Diagnostics
{
	internal sealed class ConsoleRunnerLogger : IConsoleRunnerLogger
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


		

		public ConsoleRunnerLogger(
			)
		{
			
		}

		public void RunnerCreated(
			)
		{
			Sample.Current.RunnerCreated(
				
			);
    
		}


		public void RunnerDestroyed(
			)
		{
			Sample.Current.RunnerDestroyed(
				
			);
    
		}


		public void WaitingForKeyPress(
			)
		{
			Sample.Current.WaitingForKeyPress(
				
			);
    
		}


		public void KeyPressed(
			System.ConsoleKey key)
		{
			Sample.Current.KeyPressed(
				key
			);
    
		}


		public void UnsupportedKeyError(
			System.Exception ex)
		{
			Sample.Current.UnsupportedKeyError(
				ex
			);
    
		}


		public void StartLoop(
			)
		{
			Sample.Current.StartLoop(
				
			);
    
		}


		public void StopLoop(
			)
		{
			Sample.Current.StopLoop(
				
			);
    
		}


		public void RandomIntsGenerated(
			int[] values)
		{
			Sample.Current.RandomIntsGenerated(
				values
			);
    
		}


	}
}