<#
.SYNOPSIS
Deploys web project for ActimizeScreening Solution
#>
[CmdletBinding()]
param (
    [Parameter(Mandatory=$true)]
    [string]
    [ValidateScript({ Test-Path -Path $_ -PathType Container })]
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