﻿using System;
using System.Collections.Generic;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Common;
using FG.ServiceFabric.Services.Remoting.Runtime.Client;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using PersonActor.Interfaces;
using WebApiService.Diagnostics;

namespace WebApiService.Controllers
{
    [ServiceRequestActionFilter]
	public class ValuesController : ApiController, ILoggableController
    {
        private readonly object _lock = new object();

		private readonly IWebApiLogger _logger;
		private readonly ICommunicationLogger _servicesCommunicationLogger;

        private static PartitionHelper _partitionHelper;

	    private readonly ServiceRequestContextWrapperX _contextScope;        

        public ValuesController(StatelessServiceContext context)
        {
            _contextScope = new ServiceRequestContextWrapperX(correlationId: Guid.NewGuid().ToString(), userId: "mainframe64/Kapten_rödskägg");

            _logger = new WebApiLogger(context);
            _servicesCommunicationLogger = new CommunicationLogger(context);

            _logger.ActivatingController(_contextScope.CorrelationId, _contextScope.UserId);            
		}

        private PartitionHelper GetOrCreatePartitionHelper()
        {
            if (_partitionHelper != null)
            {
                return _partitionHelper;
            }

            lock (_lock)
            {
                if (_partitionHelper == null)
                {
                    _partitionHelper = new PartitionHelper();
                }
                return _partitionHelper;
            }
        }


        public IDisposable RequestLoggingContext { get; set; }

        public IWebApiLogger Logger => _logger;

        protected override void Dispose(bool disposing)
	    {
	        base.Dispose(disposing);

            _contextScope.Dispose();

        }

	    // GET api/values 
		public async Task<IDictionary<string, IDictionary<string, Person>>> Get()
		{
            var serviceUri = new Uri($"{FabricRuntime.GetActivationContext().ApplicationName}/PersonActorService");
            var allPersons = new Dictionary<string, IDictionary<string, Person>>();

            var partitionKeys = await GetOrCreatePartitionHelper().GetInt64Partitions(serviceUri, _servicesCommunicationLogger);
            foreach (var partitionKey in partitionKeys)
            {
                var actorProxyFactory = new FG.ServiceFabric.Actors.Client.ActorProxyFactory(_servicesCommunicationLogger);
                var proxy = actorProxyFactory.CreateActorServiceProxy<IPersonActorService>(
                    serviceUri,
                    partitionKey.LowKey);

                var persons = await proxy.GetPersons(CancellationToken.None);
                allPersons.Add(partitionKey.LowKey.ToString(), persons);
            }

            return allPersons;
		}

		// GET api/values/5 
		public async Task<Person> Get(string id)
		{
			//var actorProxyFactory = new ActorProxyFactory(client =>
			//	new FabricTransportServiceRemotingClientFactory(
			//		new Microsoft.ServiceFabric.Services.Remoting.FabricTransport.Client.FabricTransportServiceRemotingClientFactory(callbackClient: client),
			//		GetRequestHeaders(true)));
			var actorProxyFactory = new ActorProxyFactory();

			var proxy = actorProxyFactory.CreateActorProxy<IPersonActor>(
				new Uri($"fabric:/{FabricRuntime.GetActivationContext().ApplicationName}/PersonActorService"),
				new ActorId(id));

			var person = await proxy.GetPersonAsync(CancellationToken.None);

			return person;

		}
    }
}