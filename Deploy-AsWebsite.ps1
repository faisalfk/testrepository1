<#
.SYNOPSIS
Deploys web project for ActimizeScreening Solution
#>
[CmdletBinding()]
param (
    [Parameter(Mandatory=$true)]
    [string]
    $SourceFolder,
    [Parameter(Mandatory=$true)]
    [string]
    $DestinationComputerName,
    [Parameter(Mandatory=$true)]
    [string]
    $TargetFolder
)
begin {
    $WebsiteName = $env:website_name
}
process {
	Write-Host "Deploying Web Project to $DestinationComputerName @ $TargetFolder"
}
end {

}