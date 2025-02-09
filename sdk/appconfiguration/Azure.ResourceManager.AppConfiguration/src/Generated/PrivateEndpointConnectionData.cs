// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager.AppConfiguration.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.AppConfiguration
{
    /// <summary> A class representing the PrivateEndpointConnection data model. </summary>
    public partial class PrivateEndpointConnectionData : ResourceData
    {
        /// <summary> Initializes a new instance of PrivateEndpointConnectionData. </summary>
        public PrivateEndpointConnectionData()
        {
        }

        /// <summary> Initializes a new instance of PrivateEndpointConnectionData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> The provisioning status of the private endpoint connection. </param>
        /// <param name="privateEndpoint"> The resource of private endpoint. </param>
        /// <param name="privateLinkServiceConnectionState"> A collection of information about the state of the connection between service consumer and provider. </param>
        internal PrivateEndpointConnectionData(ResourceIdentifier id, string name, ResourceType type, SystemData systemData, ProvisioningState? provisioningState, WritableSubResource privateEndpoint, PrivateLinkServiceConnectionState privateLinkServiceConnectionState) : base(id, name, type, systemData)
        {
            ProvisioningState = provisioningState;
            PrivateEndpoint = privateEndpoint;
            PrivateLinkServiceConnectionState = privateLinkServiceConnectionState;
        }

        /// <summary> The provisioning status of the private endpoint connection. </summary>
        public ProvisioningState? ProvisioningState { get; }
        /// <summary> The resource of private endpoint. </summary>
        internal WritableSubResource PrivateEndpoint { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier PrivateEndpointId
        {
            get => PrivateEndpoint is null ? default : PrivateEndpoint.Id;
            set
            {
                if (PrivateEndpoint is null)
                    PrivateEndpoint = new WritableSubResource();
                PrivateEndpoint.Id = value;
            }
        }

        /// <summary> A collection of information about the state of the connection between service consumer and provider. </summary>
        public PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; set; }
    }
}
