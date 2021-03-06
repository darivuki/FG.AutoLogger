﻿using System;
using System.Collections.Generic;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Communication.Client;
using Microsoft.ServiceFabric.Services.Remoting.Builder;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace CodeEffect.ServiceFabric.Services.Remoting.FabricTransport.Client
{
    public class FabricTransportServiceRemotingClientFactory : IServiceRemotingClientFactory, ICommunicationClientFactory<IServiceRemotingClient>
    {
        private readonly ICommunicationClientFactory<IServiceRemotingClient> _innerClientFactory;
        private readonly IServiceClientLogger _logger;
        private readonly MethodDispatcherBase _serviceMethodDispatcher;

        public FabricTransportServiceRemotingClientFactory(
            ICommunicationClientFactory<IServiceRemotingClient> innerClientFactory,
            IServiceClientLogger logger,
            MethodDispatcherBase serviceMethodDispatcher
        )
        {
            _innerClientFactory = innerClientFactory;
            _logger = logger;
            _serviceMethodDispatcher = serviceMethodDispatcher;
            _innerClientFactory.ClientConnected += OnClientConnected;
            _innerClientFactory.ClientDisconnected += OnClientDisconnected;
        }


        public async Task<IServiceRemotingClient> GetClientAsync(Uri serviceUri, ServicePartitionKey partitionKey, TargetReplicaSelector targetReplicaSelector, string listenerName,
            OperationRetrySettings retrySettings, CancellationToken cancellationToken)
        {
            var client = await _innerClientFactory.GetClientAsync(serviceUri, partitionKey, targetReplicaSelector, listenerName, retrySettings, cancellationToken);
            return new FabricTransportServiceRemotingClient(client, serviceUri, _logger, _serviceMethodDispatcher);
        }

        public async Task<IServiceRemotingClient> GetClientAsync(ResolvedServicePartition previousRsp, TargetReplicaSelector targetReplicaSelector, string listenerName, OperationRetrySettings retrySettings,
            CancellationToken cancellationToken)
        {
            var client = await _innerClientFactory.GetClientAsync(previousRsp, targetReplicaSelector, listenerName, retrySettings, cancellationToken);
            return new FabricTransportServiceRemotingClient(client, previousRsp.ServiceName, _logger, _serviceMethodDispatcher);
        }

        public Task<OperationRetryControl> ReportOperationExceptionAsync(IServiceRemotingClient client, ExceptionInformation exceptionInformation, OperationRetrySettings retrySettings,
            CancellationToken cancellationToken)
        {
            _logger.ServiceClientFailed(new Uri(client.Endpoint.Address), ServiceRequestContext.Current?.Headers.GetCustomHeader(), exceptionInformation.Exception);
            return _innerClientFactory.ReportOperationExceptionAsync(client, exceptionInformation, retrySettings, cancellationToken);
        }

        private void OnClientConnected(object sender, CommunicationClientEventArgs<IServiceRemotingClient> e)
        {
            this.ClientConnected?.Invoke((object)this, new CommunicationClientEventArgs<IServiceRemotingClient>()
            {
                Client = e.Client
            });
        }

        private void OnClientDisconnected(object sender, CommunicationClientEventArgs<IServiceRemotingClient> e)
        {
            this.ClientDisconnected?.Invoke((object)this, new CommunicationClientEventArgs<IServiceRemotingClient>()
            {
                Client = e.Client
            });
        }

        public event EventHandler<CommunicationClientEventArgs<IServiceRemotingClient>> ClientConnected;
        public event EventHandler<CommunicationClientEventArgs<IServiceRemotingClient>> ClientDisconnected;
    }
}