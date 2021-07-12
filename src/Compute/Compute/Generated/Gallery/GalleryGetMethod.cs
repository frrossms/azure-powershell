//
// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.
//

// Warning: This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Gallery", DefaultParameterSetName = "DefaultParameter")]
    [OutputType(typeof(PSGallery))]
    public partial class GetAzureRmGallery : ComputeAutomationBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName;
                string galleryName;
                switch (this.ParameterSetName)
                {
                    case "ResourceIdParameter":
                        resourceGroupName = GetResourceGroupName(this.ResourceId);
                        galleryName = GetResourceName(this.ResourceId, "Microsoft.Compute/galleries");
                        break;
                    case "SharedGalleryParameterSet":
                        SharedGalleryGet();
                        return;
                    default:
                        resourceGroupName = this.ResourceGroupName;
                        galleryName = this.Name;
                        break;
                }

                if (ShouldGetByName(resourceGroupName, galleryName))
                {
                    var result = GalleriesClient.Get(resourceGroupName, galleryName, this.Select);
                    var psObject = new PSGallery();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<Gallery, PSGallery>(result, psObject);
                    WriteObject(psObject);
                }
                else if (ShouldListByResourceGroup(resourceGroupName, galleryName))
                {
                    var result = GalleriesClient.ListByResourceGroup(resourceGroupName);
                    var resultList = result.ToList();
                    var nextPageLink = result.NextPageLink;
                    while (!string.IsNullOrEmpty(nextPageLink))
                    {
                        var pageResult = GalleriesClient.ListByResourceGroupNext(nextPageLink);
                        foreach (var pageItem in pageResult)
                        {
                            resultList.Add(pageItem);
                        }
                        nextPageLink = pageResult.NextPageLink;
                    }
                    var psObject = new List<PSGalleryList>();
                    foreach (var r in resultList)
                    {
                        psObject.Add(ComputeAutomationAutoMapperProfile.Mapper.Map<Gallery, PSGalleryList>(r));
                    }
                    WriteObject(TopLevelWildcardFilter(resourceGroupName, galleryName, psObject), true);
                }
                else
                {
                    var result = GalleriesClient.List();
                    var resultList = result.ToList();
                    var nextPageLink = result.NextPageLink;
                    while (!string.IsNullOrEmpty(nextPageLink))
                    {
                        var pageResult = GalleriesClient.ListNext(nextPageLink);
                        foreach (var pageItem in pageResult)
                        {
                            resultList.Add(pageItem);
                        }
                        nextPageLink = pageResult.NextPageLink;
                    }
                    var psObject = new List<PSGalleryList>();
                    foreach (var r in resultList)
                    {
                        psObject.Add(ComputeAutomationAutoMapperProfile.Mapper.Map<Gallery, PSGalleryList>(r));
                    }
                    WriteObject(TopLevelWildcardFilter(resourceGroupName, galleryName, psObject), true);
                }
            });
        }

        public void SharedGalleryGet()
        {
            if (this.IsParameterBound(c => c.GalleryUniqueName))
            {
                SharedGallery result = SharedGalleriesClient.Get(this.Location, this.GalleryUniqueName);
                var psObject = new PSSharedGallery();
                ComputeAutomationAutoMapperProfile.Mapper.Map<SharedGallery, PSSharedGallery>(result, psObject);
                WriteObject(psObject);
            }
            else
            {
                Rest.Azure.IPage<SharedGallery> result = new Page<SharedGallery>();

                if (this.IsParameterBound(c => c.Scope) && this.Scope != "subscription")
                {
                    result = SharedGalleriesClient.List(this.Location, this.Scope);
                }
                else
                {
                    result = SharedGalleriesClient.List(this.Location);
                }

                var resultList = result.ToList();
                var nextPageLink = result.NextPageLink;
                while (!string.IsNullOrEmpty(nextPageLink))
                {
                    var pageResult = SharedGalleriesClient.ListNext(nextPageLink);
                    foreach (var pageItem in pageResult)
                    {
                        resultList.Add(pageItem);
                    }
                    nextPageLink = pageResult.NextPageLink;
                }
                var psObject = new List<PSSharedGalleryList>();
                foreach (var r in resultList)
                {
                    psObject.Add(ComputeAutomationAutoMapperProfile.Mapper.Map<SharedGallery, PSSharedGalleryList>(r));
                }
                WriteObject(psObject);
            }
        }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 0,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Alias("GalleryName")]
        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 1,
            ValueFromPipelineByPropertyName = true)]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = "ResourceIdParameter",
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        public string ResourceId { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = "SharedGalleryParameterSet",
           HelpMessage = "The unique name of the Shared Image Gallery.")]
        public string GalleryUniqueName { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = "SharedGalleryParameterSet",
           HelpMessage = "Specifies galleries shared to subscription or tenant.")]
        [PSArgumentCompleter("subscription", "tenant")]
        public string Scope { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = "SharedGalleryParameterSet")]
        [LocationCompleter("Microsoft.Compute/Galleries")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }
        
        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = "DefaultParameter",
           HelpMessage = "The select expression to apply on the operation.")]
        [PSArgumentCompleter("Permissions")]
        public string Select { get; set; }
    }
}
