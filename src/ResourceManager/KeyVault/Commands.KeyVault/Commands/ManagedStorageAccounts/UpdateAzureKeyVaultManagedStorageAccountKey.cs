﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.KeyVault.Models;
using System.Globalization;
using System.Management.Automation;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet( VerbsData.Update, CmdletNoun.AzureKeyVaultManagedStorageAccountKey,
        SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType( typeof( PSKeyVaultManagedStorageAccount ) )]
    public class UpdateAzureKeyVaultManagedStorageAccountKey : KeyVaultCmdletBase
    {
        #region Input Parameter Definitions
        [Parameter( Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment." )]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        [Parameter( Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Key Vault managed storage account name. Cmdlet constructs the FQDN of a managed storage account name from vault name, currently " +
                          "selected environment and manged storage account name." )]
        [ValidateNotNullOrEmpty]
        [Alias( Constants.StorageAccountName, Constants.Name )]
        public string AccountName { get; set; }

        [Parameter( Mandatory = true,
            Position = 2,
            HelpMessage = "Name of storage account key to regenerate and make active." )]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        /// <summary>
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter( Mandatory = false, HelpMessage = "Do not ask for confirmation." )]
        public SwitchParameter Force { get; set; }

        [ Parameter( Mandatory = false,
            HelpMessage = "Cmdlet does not return an object by default. If this switch is specified, cmdlet returns the managed storage account." )]
        public SwitchParameter PassThru { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            PSKeyVaultManagedStorageAccount managedManagedStorageAccount = null;
            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    KeyVaultProperties.Resources.RegenerateManagedStorageAccountKeyWarning,
                    AccountName,
                    KeyName ),
                string.Format(
                    CultureInfo.InvariantCulture,
                    KeyVaultProperties.Resources.RegenerateManagedStorageAccountKeyWhatIfMessage,
                    KeyName ),
                AccountName,
               () => { managedManagedStorageAccount = DataServiceClient.RegenerateManagedStorageAccountKey( VaultName, AccountName, KeyName ); } );

            if( PassThru )
            {
                WriteObject( managedManagedStorageAccount );
            }
        }
    }
}
