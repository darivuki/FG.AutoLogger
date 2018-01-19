/*******************************************************************************************
*  This class is autogenerated from the class DependencyLogger
*  Do not directly update this class as changes will be lost on rebuild.
*******************************************************************************************/
using System;
using System.Collections.Generic;
using ConsoleApplication1.Loggers;


namespace ConsoleApplication1.Diagnostics
{
	internal sealed class DependencyLogger : IDependencyLogger
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


		private readonly int _processId;
		private readonly string _machineName;
		private readonly string _requestName;

		public DependencyLogger(
			int processId,
			string machineName,
			string requestName)
		{
			_processId = processId;
			_machineName = machineName;
			_requestName = requestName;
		}


        public System.IDisposable CallExternalComponent(
			System.Uri requestName,
			string content)
		{
		    return new ScopeWrapper(new IDisposable[]
		    {

                ScopeWrapperWithAction.Wrap(() =>
		        {
			Sample.Current.StartCallExternalComponent(
				_processId, 
				_machineName, 
				requestName, 
				content
			);
    
		            return new ScopeWrapperWithAction(() =>
		            {
			Sample.Current.StopCallExternalComponent(
				_processId, 
				_machineName, 
				requestName, 
				content
			);
    
		            });
		        }),


		    });
		}




        public System.IDisposable RecieveMessage(
			string message)
		{
		    return new ScopeWrapper(new IDisposable[]
		    {

                ScopeWrapperWithAction.Wrap(() =>
		        {
			Sample.Current.StartRecieveMessage(
				_processId, 
				_machineName, 
				_requestName, 
				message
			);
    
		            return new ScopeWrapperWithAction(() =>
		            {
			Sample.Current.StopRecieveMessage(
				_processId, 
				_machineName, 
				_requestName, 
				message
			);
    
		            });
		        }),


		    });
		}



	}
}