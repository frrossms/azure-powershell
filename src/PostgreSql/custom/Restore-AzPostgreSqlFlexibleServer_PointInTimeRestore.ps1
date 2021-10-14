
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Restore a PostgreSQL flexible server from an existing backup
.Description
Restore a PostgreSQL flexible server from an existing backup
#>
function Restore-AzPostgreSqlFlexibleServer_PointInTimeRestore {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20210601.IServerAutoGenerated])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Description('Restore a server from an existing backup')]
    param(
        [Parameter(Mandatory, HelpMessage = 'The name of the server.')]
        [Alias('ServerName')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Path')]
        [System.String]
        ${Name},

        [Parameter(Mandatory, HelpMessage = 'The name of the resource group that contains the resource, You can obtain this value from the Azure Resource Manager API or the portal.')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Path')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(HelpMessage='The subscription ID that identifies an Azure subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage = 'The point in time to restore from (ISO8601 format), e.g., 2017-04-26T02:10:00+08:00.')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Body')]
        [System.DateTime]
        ${RestorePointInTime},

        [Parameter(HelpMessage = 'Availability zone into which to provision the resource.')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Body')]
        [System.String]
        ${Zone},

        [Parameter(HelpMessage = 'The location the resource resides in.')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Body')]
        [System.String]
        ${Location},

        [Parameter(Mandatory, HelpMessage = 'The name of the source server.')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Path')]
        [System.String]
        ${SourceServerName},

        [Parameter(HelpMessage = 'The id of an existing Subnet the private access server will created to. Please note that the subnet will be delegated to Microsoft.DBforPostgreSQL/flexibleServers. After delegation, this subnet cannot be used for any other type of Azure resources.')]
        [System.String]
        ${Subnet},

        [Parameter(HelpMessage = 'The id of an existing private dns zone. You can use the
        private dns zone from same resource group, different resource group, or
        different subscription.')]
        [System.String]
        ${PrivateDnsZone},

        [Parameter(HelpMessage = 'The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Azure')]
        [System.Management.Automation.PSObject]
        ${DefaultProfile},

        [Parameter(HelpMessage = 'Run the command as a job.')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${AsJob},

        [Parameter(DontShow, HelpMessage = 'Wait for .NET debugger to attach.')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline.
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline.
        ${HttpPipelinePrepend},

        [Parameter(HelpMessage = 'Run the command asynchronously.')]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use.
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call.
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy.
        ${ProxyUseDefaultCredentials}
    )   

    process {
        try {
            $PSBoundParameters.CreateMode = [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.CreateMode]::PointInTimeRestore

            $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $PSBoundParameters.ResourceGroupName -Name $PSBoundParameters.SourceServerName
            $null = $PSBoundParameters.Remove('SourceServerName')
            $PSBoundParameters.PointInTimeUtc = $PSBoundParameters["RestorePointInTime"]
            $null = $PSBoundParameters.Remove('RestorePointInTime')

            $PSBoundParameters.SourceServerResourceId = $server.Id

            $LocationParts = ForEach($part in $server.Location.Split(" ")){$part.ToLower()}
            $PSBoundParameters.Location = $LocationParts -Join ""

            if ($PSBoundParameters.ContainsKey('Zone')) {
                $PSBoundParameters.AvailabilityZone = $PSBoundParameters.Zone
                $null = $PSBoundParameters.Remove('Zone')
            }
            else {
                $PSBoundParameters.AvailabilityZone = $server.AvailabilityZone
            }
            
            if ($PSBoundParameters.ContainsKey('Subnet')){
                $VnetId = [string]::Join("/",$PSBoundParameters.Subnet.split("/")[0..8])
                $SubnetModel = Get-AzVirtualNetworkSubnetConfig -ResourceId $PSBoundParameters.Subnet
                $Delegations = Get-AzDelegation -Subnet $SubnetModel
                if ($null -ne $Delegations){ # Valid but incorrect delegation
                    $Delegations | ForEach-Object {if ($PSItem.ServiceName -ne $DELEGATION_SERVICE_NAME) {
                        $Msg = "Can not use subnet with existing delegations other than {0}" -f $DELEGATION_SERVICE_NAME
                        throw $Msg
                    }}
                }
                $PSBoundParameters.NetworkDelegatedSubnetResourceId = $PSBoundParameters.Subnet
                $null = $PSBoundParameters.Remove('Subnet')
            }

            if ($PSBoundParameters.ContainsKey('PrivateDnsZone')){
                if ([string]::IsNullOrEmpty($VnetId)){
                    $VnetId = [string]::Join("/",$server.NetworkDelegatedSubnetResourceId.split("/")[0..8])
                }
                $ZoneName = $PSBoundParameters["PrivateDnsZone"].split("/")[-1]
                $DnsResourceGroup = $PSBoundParameters["PrivateDnsZone"].split("/")[4]
                $Links = Get-AzPrivateDnsVirtualNetworkLink -ZoneName $ZoneName -ResourceGroupName $DnsResourceGroup
                $LinkedFlag = $false
                foreach($Link in $Links){
                    if ($Link.VirtualNetworkId -eq $VnetId){
                        $LinkedFlag = $true
                        break
                    }
                }
                if (!$LinkedFlag){
                    New-AzPrivateDnsVirtualNetworkLink -ZoneName $ZoneName -ResourceGroupName $DnsResourceGroup -Name $PSBoundParameters["Name"] -VirtualNetworkId $VnetId
                }
                $PSBoundParameters.NetworkPrivateDnsZoneArmResourceId = $PSBoundParameters.PrivateDnsZone
                $null = $PSBoundParameters.Remove('PrivateDnsZone')

            }

            Az.PostgreSql.internal\New-AzPostgreSqlFlexibleServer @PSBoundParameters
        } catch {
            throw
        }
    }
}


