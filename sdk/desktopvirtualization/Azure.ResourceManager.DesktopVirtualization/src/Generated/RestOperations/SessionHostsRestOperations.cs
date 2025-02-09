// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.DesktopVirtualization.Models;

namespace Azure.ResourceManager.DesktopVirtualization
{
    internal partial class SessionHostsRestOperations
    {
        private readonly string _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of SessionHostsRestOperations. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public SessionHostsRestOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2021-07-12";
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _userAgent = Core.HttpMessageUtilities.GetUserAgentName(this, applicationId);
        }

        internal HttpMessage CreateGetRequest(string subscriptionId, string resourceGroupName, string hostPoolName, string sessionHostName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.DesktopVirtualization/hostPools/", false);
            uri.AppendPath(hostPoolName, true);
            uri.AppendPath("/sessionHosts/", false);
            uri.AppendPath(sessionHostName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("SDKUserAgent", _userAgent);
            return message;
        }

        /// <summary> Get a session host. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="hostPoolName"> The name of the host pool within the specified resource group. </param>
        /// <param name="sessionHostName"> The name of the session host within the specified host pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="hostPoolName"/> or <paramref name="sessionHostName"/> is null. </exception>
        public async Task<Response<SessionHostData>> GetAsync(string subscriptionId, string resourceGroupName, string hostPoolName, string sessionHostName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (hostPoolName == null)
            {
                throw new ArgumentNullException(nameof(hostPoolName));
            }
            if (sessionHostName == null)
            {
                throw new ArgumentNullException(nameof(sessionHostName));
            }

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, hostPoolName, sessionHostName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SessionHostData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SessionHostData.DeserializeSessionHostData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((SessionHostData)null, message.Response);
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Get a session host. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="hostPoolName"> The name of the host pool within the specified resource group. </param>
        /// <param name="sessionHostName"> The name of the session host within the specified host pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="hostPoolName"/> or <paramref name="sessionHostName"/> is null. </exception>
        public Response<SessionHostData> Get(string subscriptionId, string resourceGroupName, string hostPoolName, string sessionHostName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (hostPoolName == null)
            {
                throw new ArgumentNullException(nameof(hostPoolName));
            }
            if (sessionHostName == null)
            {
                throw new ArgumentNullException(nameof(sessionHostName));
            }

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, hostPoolName, sessionHostName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SessionHostData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SessionHostData.DeserializeSessionHostData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((SessionHostData)null, message.Response);
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteRequest(string subscriptionId, string resourceGroupName, string hostPoolName, string sessionHostName, bool? force)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.DesktopVirtualization/hostPools/", false);
            uri.AppendPath(hostPoolName, true);
            uri.AppendPath("/sessionHosts/", false);
            uri.AppendPath(sessionHostName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (force != null)
            {
                uri.AppendQuery("force", force.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("SDKUserAgent", _userAgent);
            return message;
        }

        /// <summary> Remove a SessionHost. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="hostPoolName"> The name of the host pool within the specified resource group. </param>
        /// <param name="sessionHostName"> The name of the session host within the specified host pool. </param>
        /// <param name="force"> Force flag to force sessionHost deletion even when userSession exists. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="hostPoolName"/> or <paramref name="sessionHostName"/> is null. </exception>
        public async Task<Response> DeleteAsync(string subscriptionId, string resourceGroupName, string hostPoolName, string sessionHostName, bool? force = null, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (hostPoolName == null)
            {
                throw new ArgumentNullException(nameof(hostPoolName));
            }
            if (sessionHostName == null)
            {
                throw new ArgumentNullException(nameof(sessionHostName));
            }

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, hostPoolName, sessionHostName, force);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Remove a SessionHost. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="hostPoolName"> The name of the host pool within the specified resource group. </param>
        /// <param name="sessionHostName"> The name of the session host within the specified host pool. </param>
        /// <param name="force"> Force flag to force sessionHost deletion even when userSession exists. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="hostPoolName"/> or <paramref name="sessionHostName"/> is null. </exception>
        public Response Delete(string subscriptionId, string resourceGroupName, string hostPoolName, string sessionHostName, bool? force = null, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (hostPoolName == null)
            {
                throw new ArgumentNullException(nameof(hostPoolName));
            }
            if (sessionHostName == null)
            {
                throw new ArgumentNullException(nameof(sessionHostName));
            }

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, hostPoolName, sessionHostName, force);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateUpdateRequest(string subscriptionId, string resourceGroupName, string hostPoolName, string sessionHostName, SessionHostUpdateOptions options)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.DesktopVirtualization/hostPools/", false);
            uri.AppendPath(hostPoolName, true);
            uri.AppendPath("/sessionHosts/", false);
            uri.AppendPath(sessionHostName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (options != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(options);
                request.Content = content;
            }
            message.SetProperty("SDKUserAgent", _userAgent);
            return message;
        }

        /// <summary> Update a session host. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="hostPoolName"> The name of the host pool within the specified resource group. </param>
        /// <param name="sessionHostName"> The name of the session host within the specified host pool. </param>
        /// <param name="options"> Object containing SessionHost definitions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="hostPoolName"/> or <paramref name="sessionHostName"/> is null. </exception>
        public async Task<Response<SessionHostData>> UpdateAsync(string subscriptionId, string resourceGroupName, string hostPoolName, string sessionHostName, SessionHostUpdateOptions options = null, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (hostPoolName == null)
            {
                throw new ArgumentNullException(nameof(hostPoolName));
            }
            if (sessionHostName == null)
            {
                throw new ArgumentNullException(nameof(sessionHostName));
            }

            using var message = CreateUpdateRequest(subscriptionId, resourceGroupName, hostPoolName, sessionHostName, options);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SessionHostData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SessionHostData.DeserializeSessionHostData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Update a session host. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="hostPoolName"> The name of the host pool within the specified resource group. </param>
        /// <param name="sessionHostName"> The name of the session host within the specified host pool. </param>
        /// <param name="options"> Object containing SessionHost definitions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="hostPoolName"/> or <paramref name="sessionHostName"/> is null. </exception>
        public Response<SessionHostData> Update(string subscriptionId, string resourceGroupName, string hostPoolName, string sessionHostName, SessionHostUpdateOptions options = null, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (hostPoolName == null)
            {
                throw new ArgumentNullException(nameof(hostPoolName));
            }
            if (sessionHostName == null)
            {
                throw new ArgumentNullException(nameof(sessionHostName));
            }

            using var message = CreateUpdateRequest(subscriptionId, resourceGroupName, hostPoolName, sessionHostName, options);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SessionHostData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SessionHostData.DeserializeSessionHostData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListRequest(string subscriptionId, string resourceGroupName, string hostPoolName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.DesktopVirtualization/hostPools/", false);
            uri.AppendPath(hostPoolName, true);
            uri.AppendPath("/sessionHosts", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("SDKUserAgent", _userAgent);
            return message;
        }

        /// <summary> List sessionHosts. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="hostPoolName"> The name of the host pool within the specified resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="hostPoolName"/> is null. </exception>
        public async Task<Response<SessionHostList>> ListAsync(string subscriptionId, string resourceGroupName, string hostPoolName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (hostPoolName == null)
            {
                throw new ArgumentNullException(nameof(hostPoolName));
            }

            using var message = CreateListRequest(subscriptionId, resourceGroupName, hostPoolName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SessionHostList value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SessionHostList.DeserializeSessionHostList(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> List sessionHosts. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="hostPoolName"> The name of the host pool within the specified resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="hostPoolName"/> is null. </exception>
        public Response<SessionHostList> List(string subscriptionId, string resourceGroupName, string hostPoolName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (hostPoolName == null)
            {
                throw new ArgumentNullException(nameof(hostPoolName));
            }

            using var message = CreateListRequest(subscriptionId, resourceGroupName, hostPoolName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SessionHostList value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SessionHostList.DeserializeSessionHostList(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListNextPageRequest(string nextLink, string subscriptionId, string resourceGroupName, string hostPoolName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("SDKUserAgent", _userAgent);
            return message;
        }

        /// <summary> List sessionHosts. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="hostPoolName"> The name of the host pool within the specified resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="hostPoolName"/> is null. </exception>
        public async Task<Response<SessionHostList>> ListNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string hostPoolName, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (hostPoolName == null)
            {
                throw new ArgumentNullException(nameof(hostPoolName));
            }

            using var message = CreateListNextPageRequest(nextLink, subscriptionId, resourceGroupName, hostPoolName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SessionHostList value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SessionHostList.DeserializeSessionHostList(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> List sessionHosts. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="hostPoolName"> The name of the host pool within the specified resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="hostPoolName"/> is null. </exception>
        public Response<SessionHostList> ListNextPage(string nextLink, string subscriptionId, string resourceGroupName, string hostPoolName, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (hostPoolName == null)
            {
                throw new ArgumentNullException(nameof(hostPoolName));
            }

            using var message = CreateListNextPageRequest(nextLink, subscriptionId, resourceGroupName, hostPoolName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SessionHostList value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SessionHostList.DeserializeSessionHostList(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
