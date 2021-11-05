// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701
{
    using Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.PowerShell;

    /// <summary>Describes the properties of a Shared Image Gallery.</summary>
    [System.ComponentModel.TypeConverter(typeof(GalleryPropertiesTypeConverter))]
    public partial class GalleryProperties
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.GalleryProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new GalleryProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.GalleryProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new GalleryProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="GalleryProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.GalleryProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal GalleryProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).Identifier = (Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryIdentifier) content.GetValueForProperty("Identifier",((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).Identifier, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.GalleryIdentifierTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SharingProfile = (Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.ISharingProfile) content.GetValueForProperty("SharingProfile",((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SharingProfile, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.SharingProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SoftDeletePolicy = (Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.ISoftDeletePolicy) content.GetValueForProperty("SoftDeletePolicy",((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SoftDeletePolicy, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.SoftDeletePolicyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SharingProfileGroup = (Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.ISharingProfileGroup[]) content.GetValueForProperty("SharingProfileGroup",((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SharingProfileGroup, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.ISharingProfileGroup>(__y, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.SharingProfileGroupTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).IdentifierUniqueName = (string) content.GetValueForProperty("IdentifierUniqueName",((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).IdentifierUniqueName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SharingProfilePermission = (Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.GallerySharingPermissionTypes?) content.GetValueForProperty("SharingProfilePermission",((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SharingProfilePermission, Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.GallerySharingPermissionTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SoftDeletePolicyIsSoftDeleteEnabled = (bool?) content.GetValueForProperty("SoftDeletePolicyIsSoftDeleteEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SoftDeletePolicyIsSoftDeleteEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.GalleryProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal GalleryProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).Identifier = (Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryIdentifier) content.GetValueForProperty("Identifier",((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).Identifier, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.GalleryIdentifierTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SharingProfile = (Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.ISharingProfile) content.GetValueForProperty("SharingProfile",((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SharingProfile, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.SharingProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SoftDeletePolicy = (Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.ISoftDeletePolicy) content.GetValueForProperty("SoftDeletePolicy",((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SoftDeletePolicy, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.SoftDeletePolicyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SharingProfileGroup = (Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.ISharingProfileGroup[]) content.GetValueForProperty("SharingProfileGroup",((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SharingProfileGroup, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.ISharingProfileGroup>(__y, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.SharingProfileGroupTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).IdentifierUniqueName = (string) content.GetValueForProperty("IdentifierUniqueName",((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).IdentifierUniqueName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SharingProfilePermission = (Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.GallerySharingPermissionTypes?) content.GetValueForProperty("SharingProfilePermission",((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SharingProfilePermission, Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.GallerySharingPermissionTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SoftDeletePolicyIsSoftDeleteEnabled = (bool?) content.GetValueForProperty("SoftDeletePolicyIsSoftDeleteEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryPropertiesInternal)this).SoftDeletePolicyIsSoftDeleteEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Describes the properties of a Shared Image Gallery.
    [System.ComponentModel.TypeConverter(typeof(GalleryPropertiesTypeConverter))]
    public partial interface IGalleryProperties

    {

    }
}