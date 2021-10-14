// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Extensions;

    /// <summary>The available skus operation response.</summary>
    public partial class AvailableSkusResult :
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IAvailableSkusResult,
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IAvailableSkusResultInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.ISkuInformation[] Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IAvailableSkusResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Link for the next set of skus.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataBox.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataBox.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.ISkuInformation[] _value;

        /// <summary>List of available skus.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataBox.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataBox.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.ISkuInformation[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="AvailableSkusResult" /> instance.</summary>
        public AvailableSkusResult()
        {

        }
    }
    /// The available skus operation response.
    public partial interface IAvailableSkusResult :
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.IJsonSerializable
    {
        /// <summary>Link for the next set of skus.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Link for the next set of skus.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>List of available skus.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of available skus.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.ISkuInformation) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.ISkuInformation[] Value { get;  }

    }
    /// The available skus operation response.
    internal partial interface IAvailableSkusResultInternal

    {
        /// <summary>Link for the next set of skus.</summary>
        string NextLink { get; set; }
        /// <summary>List of available skus.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.ISkuInformation[] Value { get; set; }

    }
}