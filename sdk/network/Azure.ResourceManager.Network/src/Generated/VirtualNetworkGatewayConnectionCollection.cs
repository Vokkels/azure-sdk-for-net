// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    /// <summary> A class representing collection of VirtualNetworkGatewayConnection and their operations over its parent. </summary>
    public partial class VirtualNetworkGatewayConnectionCollection : ArmCollection, IEnumerable<VirtualNetworkGatewayConnection>, IAsyncEnumerable<VirtualNetworkGatewayConnection>
    {
        private readonly ClientDiagnostics _virtualNetworkGatewayConnectionClientDiagnostics;
        private readonly VirtualNetworkGatewayConnectionsRestOperations _virtualNetworkGatewayConnectionRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualNetworkGatewayConnectionCollection"/> class for mocking. </summary>
        protected VirtualNetworkGatewayConnectionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualNetworkGatewayConnectionCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal VirtualNetworkGatewayConnectionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _virtualNetworkGatewayConnectionClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", VirtualNetworkGatewayConnection.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(VirtualNetworkGatewayConnection.ResourceType, out string virtualNetworkGatewayConnectionApiVersion);
            _virtualNetworkGatewayConnectionRestClient = new VirtualNetworkGatewayConnectionsRestOperations(_virtualNetworkGatewayConnectionClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, virtualNetworkGatewayConnectionApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a virtual network gateway connection in the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/connections/{virtualNetworkGatewayConnectionName}
        /// Operation Id: VirtualNetworkGatewayConnections_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="virtualNetworkGatewayConnectionName"> The name of the virtual network gateway connection. </param>
        /// <param name="parameters"> Parameters supplied to the create or update virtual network gateway connection operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkGatewayConnectionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkGatewayConnectionName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<VirtualNetworkGatewayConnection>> CreateOrUpdateAsync(bool waitForCompletion, string virtualNetworkGatewayConnectionName, VirtualNetworkGatewayConnectionData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkGatewayConnectionName, nameof(virtualNetworkGatewayConnectionName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _virtualNetworkGatewayConnectionClientDiagnostics.CreateScope("VirtualNetworkGatewayConnectionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualNetworkGatewayConnectionRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualNetworkGatewayConnectionName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<VirtualNetworkGatewayConnection>(new VirtualNetworkGatewayConnectionOperationSource(Client), _virtualNetworkGatewayConnectionClientDiagnostics, Pipeline, _virtualNetworkGatewayConnectionRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, virtualNetworkGatewayConnectionName, parameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates a virtual network gateway connection in the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/connections/{virtualNetworkGatewayConnectionName}
        /// Operation Id: VirtualNetworkGatewayConnections_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="virtualNetworkGatewayConnectionName"> The name of the virtual network gateway connection. </param>
        /// <param name="parameters"> Parameters supplied to the create or update virtual network gateway connection operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkGatewayConnectionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkGatewayConnectionName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<VirtualNetworkGatewayConnection> CreateOrUpdate(bool waitForCompletion, string virtualNetworkGatewayConnectionName, VirtualNetworkGatewayConnectionData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkGatewayConnectionName, nameof(virtualNetworkGatewayConnectionName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _virtualNetworkGatewayConnectionClientDiagnostics.CreateScope("VirtualNetworkGatewayConnectionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualNetworkGatewayConnectionRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, virtualNetworkGatewayConnectionName, parameters, cancellationToken);
                var operation = new NetworkArmOperation<VirtualNetworkGatewayConnection>(new VirtualNetworkGatewayConnectionOperationSource(Client), _virtualNetworkGatewayConnectionClientDiagnostics, Pipeline, _virtualNetworkGatewayConnectionRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, virtualNetworkGatewayConnectionName, parameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified virtual network gateway connection by resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/connections/{virtualNetworkGatewayConnectionName}
        /// Operation Id: VirtualNetworkGatewayConnections_Get
        /// </summary>
        /// <param name="virtualNetworkGatewayConnectionName"> The name of the virtual network gateway connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkGatewayConnectionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkGatewayConnectionName"/> is null. </exception>
        public async virtual Task<Response<VirtualNetworkGatewayConnection>> GetAsync(string virtualNetworkGatewayConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkGatewayConnectionName, nameof(virtualNetworkGatewayConnectionName));

            using var scope = _virtualNetworkGatewayConnectionClientDiagnostics.CreateScope("VirtualNetworkGatewayConnectionCollection.Get");
            scope.Start();
            try
            {
                var response = await _virtualNetworkGatewayConnectionRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualNetworkGatewayConnectionName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _virtualNetworkGatewayConnectionClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new VirtualNetworkGatewayConnection(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified virtual network gateway connection by resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/connections/{virtualNetworkGatewayConnectionName}
        /// Operation Id: VirtualNetworkGatewayConnections_Get
        /// </summary>
        /// <param name="virtualNetworkGatewayConnectionName"> The name of the virtual network gateway connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkGatewayConnectionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkGatewayConnectionName"/> is null. </exception>
        public virtual Response<VirtualNetworkGatewayConnection> Get(string virtualNetworkGatewayConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkGatewayConnectionName, nameof(virtualNetworkGatewayConnectionName));

            using var scope = _virtualNetworkGatewayConnectionClientDiagnostics.CreateScope("VirtualNetworkGatewayConnectionCollection.Get");
            scope.Start();
            try
            {
                var response = _virtualNetworkGatewayConnectionRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, virtualNetworkGatewayConnectionName, cancellationToken);
                if (response.Value == null)
                    throw _virtualNetworkGatewayConnectionClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualNetworkGatewayConnection(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The List VirtualNetworkGatewayConnections operation retrieves all the virtual network gateways connections created.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/connections
        /// Operation Id: VirtualNetworkGatewayConnections_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualNetworkGatewayConnection" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualNetworkGatewayConnection> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualNetworkGatewayConnection>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualNetworkGatewayConnectionClientDiagnostics.CreateScope("VirtualNetworkGatewayConnectionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualNetworkGatewayConnectionRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualNetworkGatewayConnection(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VirtualNetworkGatewayConnection>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualNetworkGatewayConnectionClientDiagnostics.CreateScope("VirtualNetworkGatewayConnectionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualNetworkGatewayConnectionRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualNetworkGatewayConnection(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// The List VirtualNetworkGatewayConnections operation retrieves all the virtual network gateways connections created.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/connections
        /// Operation Id: VirtualNetworkGatewayConnections_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualNetworkGatewayConnection" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualNetworkGatewayConnection> GetAll(CancellationToken cancellationToken = default)
        {
            Page<VirtualNetworkGatewayConnection> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualNetworkGatewayConnectionClientDiagnostics.CreateScope("VirtualNetworkGatewayConnectionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualNetworkGatewayConnectionRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualNetworkGatewayConnection(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VirtualNetworkGatewayConnection> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualNetworkGatewayConnectionClientDiagnostics.CreateScope("VirtualNetworkGatewayConnectionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualNetworkGatewayConnectionRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualNetworkGatewayConnection(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/connections/{virtualNetworkGatewayConnectionName}
        /// Operation Id: VirtualNetworkGatewayConnections_Get
        /// </summary>
        /// <param name="virtualNetworkGatewayConnectionName"> The name of the virtual network gateway connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkGatewayConnectionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkGatewayConnectionName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string virtualNetworkGatewayConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkGatewayConnectionName, nameof(virtualNetworkGatewayConnectionName));

            using var scope = _virtualNetworkGatewayConnectionClientDiagnostics.CreateScope("VirtualNetworkGatewayConnectionCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(virtualNetworkGatewayConnectionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/connections/{virtualNetworkGatewayConnectionName}
        /// Operation Id: VirtualNetworkGatewayConnections_Get
        /// </summary>
        /// <param name="virtualNetworkGatewayConnectionName"> The name of the virtual network gateway connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkGatewayConnectionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkGatewayConnectionName"/> is null. </exception>
        public virtual Response<bool> Exists(string virtualNetworkGatewayConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkGatewayConnectionName, nameof(virtualNetworkGatewayConnectionName));

            using var scope = _virtualNetworkGatewayConnectionClientDiagnostics.CreateScope("VirtualNetworkGatewayConnectionCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(virtualNetworkGatewayConnectionName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/connections/{virtualNetworkGatewayConnectionName}
        /// Operation Id: VirtualNetworkGatewayConnections_Get
        /// </summary>
        /// <param name="virtualNetworkGatewayConnectionName"> The name of the virtual network gateway connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkGatewayConnectionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkGatewayConnectionName"/> is null. </exception>
        public async virtual Task<Response<VirtualNetworkGatewayConnection>> GetIfExistsAsync(string virtualNetworkGatewayConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkGatewayConnectionName, nameof(virtualNetworkGatewayConnectionName));

            using var scope = _virtualNetworkGatewayConnectionClientDiagnostics.CreateScope("VirtualNetworkGatewayConnectionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _virtualNetworkGatewayConnectionRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualNetworkGatewayConnectionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<VirtualNetworkGatewayConnection>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualNetworkGatewayConnection(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/connections/{virtualNetworkGatewayConnectionName}
        /// Operation Id: VirtualNetworkGatewayConnections_Get
        /// </summary>
        /// <param name="virtualNetworkGatewayConnectionName"> The name of the virtual network gateway connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualNetworkGatewayConnectionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkGatewayConnectionName"/> is null. </exception>
        public virtual Response<VirtualNetworkGatewayConnection> GetIfExists(string virtualNetworkGatewayConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualNetworkGatewayConnectionName, nameof(virtualNetworkGatewayConnectionName));

            using var scope = _virtualNetworkGatewayConnectionClientDiagnostics.CreateScope("VirtualNetworkGatewayConnectionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _virtualNetworkGatewayConnectionRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, virtualNetworkGatewayConnectionName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<VirtualNetworkGatewayConnection>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualNetworkGatewayConnection(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<VirtualNetworkGatewayConnection> IEnumerable<VirtualNetworkGatewayConnection>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<VirtualNetworkGatewayConnection> IAsyncEnumerable<VirtualNetworkGatewayConnection>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
