// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Sql.Properties;
using Microsoft.Azure.Commands.Sql.Replication.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Rest.Azure;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Replication.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure SQL Database Secondary and Replication Link
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlDatabaseSecondary",
        ConfirmImpact = ConfirmImpact.Low, SupportsShouldProcess = true, DefaultParameterSetName = DtuDatabaseParameterSet)]
    public class NewAzureSqlDatabaseSecondary : AzureSqlDatabaseSecondaryCmdletBase
    {
        private const string DtuDatabaseParameterSet = "DtuBasedDatabase";
        private const string VcoreDatabaseParameterSet = "VcoreBasedDatabase";

        /// <summary>
        /// Gets or sets the name of the Azure SQL Database to act as primary.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database to act as primary.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the service objective to assign to the secondary.
        /// </summary>
        [Parameter(ParameterSetName = DtuDatabaseParameterSet, Mandatory = false,
            HelpMessage = "The name of the service objective to assign to the secondary.")]
        [ValidateNotNullOrEmpty]
        public string SecondaryServiceObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Elastic Pool to put the secondary in.
        /// </summary>
        [Parameter(ParameterSetName = DtuDatabaseParameterSet, Mandatory = false,
            HelpMessage = "The name of the Elastic Pool to put the secondary in.")]
        [ValidateNotNullOrEmpty]
        public string SecondaryElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets the tags to associate with the Azure SQL Database Replication Link
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Azure SQL Database Replication Link")]
        [Alias("Tag")]
        public Hashtable Tags { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group of the secondary.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the resource group to create secondary in.")]
        [ValidateNotNullOrEmpty]
        public string PartnerResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure SQL Server of the secondary.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the Azure SQL Server to create secondary in.")]
        [ValidateNotNullOrEmpty]
        public string PartnerServerName { get; set; }

        /// <summary>
        /// Gets or sets the read intent of the secondary (ReadOnly is not yet supported).
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The read intent of the secondary (Non-Readable secondary is not supported anymore).")]
        [ValidateNotNullOrEmpty]
        public AllowConnections AllowConnections { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Gets or sets the compute generation of the database copy
        /// </summary>
        [Parameter(ParameterSetName = VcoreDatabaseParameterSet, Mandatory = true,
            HelpMessage = "The compute generation of teh Azure Sql Database secondary.")]
        [Alias("Family")]
        [PSArgumentCompleter("Gen4", "Gen5")]
        [ValidateNotNullOrEmpty]
        public string SecondaryComputeGeneration { get; set; }

        /// <summary>
        /// Gets or sets the Vcore numbers of the database copy
        /// </summary>
        [Parameter(ParameterSetName = VcoreDatabaseParameterSet, Mandatory = true,
            HelpMessage = "The Vcore numbers of the Azure Sql Database secondary.")]
        [Alias("Capacity")]
        [ValidateNotNullOrEmpty]
        public int SecondaryVCore { get; set; }

        /// <summary>
        /// Gets or sets the license type for the Azure Sql database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The license type for the Azure Sql database.")]
        [PSArgumentCompleter(
            Management.Sql.Models.DatabaseLicenseType.LicenseIncluded,
            Management.Sql.Models.DatabaseLicenseType.BasePrice)]
        public string LicenseType { get; set; }

        /// <summary>
        /// Overriding to add warning message
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureReplicationLinkModel> GetEntity()
        {
            // We try to get the database.  Since this is a create secondary database operation, we don't want the secondary database to already exist
            try
            {
                ModelAdapter.GetDatabase(this.PartnerResourceGroupName, this.PartnerServerName, this.DatabaseName);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no database with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The database already exists
            throw new PSArgumentException(
                string.Format(Resources.DatabaseNameExists, this.DatabaseName, this.PartnerServerName),
                "DatabaseName");
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureReplicationLinkModel> ApplyUserInputToModel(IEnumerable<AzureReplicationLinkModel> model)
        {
            string location = ModelAdapter.GetServerLocation(this.PartnerResourceGroupName, this.PartnerServerName);
            List<Model.AzureReplicationLinkModel> newEntity = new List<AzureReplicationLinkModel>();
            Database.Model.AzureSqlDatabaseModel primaryDb = ModelAdapter.GetDatabase(ResourceGroupName, ServerName, DatabaseName);
            AzureReplicationLinkModel linkModel = new AzureReplicationLinkModel()
            {
                PartnerLocation = location,
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                DatabaseName = this.DatabaseName,
                PartnerResourceGroupName = this.PartnerResourceGroupName,
                PartnerServerName = this.PartnerServerName,
                SecondaryElasticPoolName = this.SecondaryElasticPoolName,
                AllowConnections = this.AllowConnections,
                Tags = TagsConversionHelper.CreateTagDictionary(Tags, validate: true),
                LicenseType = LicenseType
            };

            if(ParameterSetName == DtuDatabaseParameterSet)
            {
                if (!string.IsNullOrWhiteSpace(SecondaryServiceObjectiveName))
                {
                    linkModel.SkuName = SecondaryServiceObjectiveName;
                }
                else if(string.IsNullOrWhiteSpace(SecondaryElasticPoolName))
                {
                    linkModel.SkuName = primaryDb.CurrentServiceObjectiveName;
                    linkModel.Edition = primaryDb.Edition;
                    linkModel.Capacity = primaryDb.Capacity;
                    linkModel.Family = primaryDb.Family;
                }
            }
            else
            {
                linkModel.SkuName = AzureSqlDatabaseAdapter.GetDatabaseSkuName(primaryDb.Edition);
                linkModel.Edition = primaryDb.Edition;
                linkModel.Capacity = SecondaryVCore;
                linkModel.Family = SecondaryComputeGeneration;
            }

            newEntity.Add(linkModel);
            return newEntity;
        }

        /// <summary>
        /// Create the new secondary and replication link to the primary
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureReplicationLinkModel> PersistChanges(IEnumerable<AzureReplicationLinkModel> entity)
        {
            return new List<AzureReplicationLinkModel>()
            {
                ModelAdapter.CreateLinkWithNewSdk(entity.First().PartnerResourceGroupName, entity.First().PartnerServerName, entity.First())
            };
        }
    }
}
