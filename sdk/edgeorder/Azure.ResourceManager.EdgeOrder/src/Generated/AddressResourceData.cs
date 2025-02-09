// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.EdgeOrder.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.EdgeOrder
{
    /// <summary> A class representing the AddressResource data model. </summary>
    public partial class AddressResourceData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of AddressResourceData. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="contactDetails"> Contact details for the address. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="contactDetails"/> is null. </exception>
        public AddressResourceData(AzureLocation location, ContactDetails contactDetails) : base(location)
        {
            if (contactDetails == null)
            {
                throw new ArgumentNullException(nameof(contactDetails));
            }

            ContactDetails = contactDetails;
        }

        /// <summary> Initializes a new instance of AddressResourceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="shippingAddress"> Shipping details for the address. </param>
        /// <param name="contactDetails"> Contact details for the address. </param>
        /// <param name="addressValidationStatus"> Status of address validation. </param>
        internal AddressResourceData(ResourceIdentifier id, string name, ResourceType type, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ShippingAddress shippingAddress, ContactDetails contactDetails, AddressValidationStatus? addressValidationStatus) : base(id, name, type, systemData, tags, location)
        {
            ShippingAddress = shippingAddress;
            ContactDetails = contactDetails;
            AddressValidationStatus = addressValidationStatus;
        }

        /// <summary> Shipping details for the address. </summary>
        public ShippingAddress ShippingAddress { get; set; }
        /// <summary> Contact details for the address. </summary>
        public ContactDetails ContactDetails { get; set; }
        /// <summary> Status of address validation. </summary>
        public AddressValidationStatus? AddressValidationStatus { get; }
    }
}
