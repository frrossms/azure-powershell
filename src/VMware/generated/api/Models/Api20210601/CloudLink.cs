// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>A cloud link resource</summary>
    public partial class CloudLink :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.ICloudLink,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.ICloudLinkInternal,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.Resource();

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.IResourceInternal)__resource).Id; }

        /// <summary>Identifier of the other private cloud participating in the link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public string LinkedCloud { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.ICloudLinkPropertiesInternal)Property).LinkedCloud; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.ICloudLinkPropertiesInternal)Property).LinkedCloud = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.ICloudLinkProperties Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.ICloudLinkInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.CloudLinkProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.CloudLinkStatus? Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.ICloudLinkInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.ICloudLinkPropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.ICloudLinkPropertiesInternal)Property).Status = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.ICloudLinkProperties _property;

        /// <summary>The properties of a cloud link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.ICloudLinkProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.CloudLinkProperties()); set => this._property = value; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/").Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/").Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>The state of the cloud link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.CloudLinkStatus? Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.ICloudLinkPropertiesInternal)Property).Status; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="CloudLink" /> instance.</summary>
        public CloudLink()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// A cloud link resource
    public partial interface ICloudLink :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.IResource
    {
        /// <summary>Identifier of the other private cloud participating in the link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Identifier of the other private cloud participating in the link.",
        SerializedName = @"linkedCloud",
        PossibleTypes = new [] { typeof(string) })]
        string LinkedCloud { get; set; }
        /// <summary>The state of the cloud link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The state of the cloud link.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.CloudLinkStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.CloudLinkStatus? Status { get;  }

    }
    /// A cloud link resource
    internal partial interface ICloudLinkInternal :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.IResourceInternal
    {
        /// <summary>Identifier of the other private cloud participating in the link.</summary>
        string LinkedCloud { get; set; }
        /// <summary>The properties of a cloud link.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20210601.ICloudLinkProperties Property { get; set; }
        /// <summary>The state of the cloud link.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.CloudLinkStatus? Status { get; set; }

    }
}