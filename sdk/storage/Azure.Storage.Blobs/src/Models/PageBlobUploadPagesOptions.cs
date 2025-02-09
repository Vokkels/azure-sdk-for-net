﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for uploading pages.
    /// </summary>
    public class PageBlobUploadPagesOptions
    {
        /// <summary>
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the upload of this Append Blob.
        /// </summary>
        public PageBlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        ///// <summary>
        ///// Optional <see cref="UploadTransactionalHashingOptions"/> for using transactional
        ///// hashing on uploads.
        ///// </summary>
        // TODO #27253
        //public UploadTransactionalHashingOptions TransactionalHashingOptions { get; set; }
    }
}
