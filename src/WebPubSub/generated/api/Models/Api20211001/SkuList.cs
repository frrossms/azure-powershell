// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Runtime.Extensions;

    /// <summary>The list skus operation response</summary>
    public partial class SkuList :
        Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.ISkuList,
        Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.ISkuListInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.ISkuListInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.ISku[] Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.ISkuListInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>
        /// The URL the client should use to fetch the next page (per server side paging).
        /// It's null for now, added for future use.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Origin(Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.ISku[] _value;

        /// <summary>The list of skus available for the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Origin(Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.ISku[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="SkuList" /> instance.</summary>
        public SkuList()
        {

        }
    }
    /// The list skus operation response
    public partial interface ISkuList :
        Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The URL the client should use to fetch the next page (per server side paging).
        /// It's null for now, added for future use.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The URL the client should use to fetch the next page (per server side paging).
        It's null for now, added for future use.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>The list of skus available for the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The list of skus available for the resource.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.ISku) })]
        Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.ISku[] Value { get;  }

    }
    /// The list skus operation response
    internal partial interface ISkuListInternal

    {
        /// <summary>
        /// The URL the client should use to fetch the next page (per server side paging).
        /// It's null for now, added for future use.
        /// </summary>
        string NextLink { get; set; }
        /// <summary>The list of skus available for the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.ISku[] Value { get; set; }

    }
}