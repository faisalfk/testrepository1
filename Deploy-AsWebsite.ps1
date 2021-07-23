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
	Write-Host "Deploying Web Project to $DestinationComputerName @ $TargetFolder FROM $SourceFolder"

   $website = Invoke-Command -ComputerName $DestinationComputerName -ScriptBlock {
        Get-Website | Where-Object { $_.Name -eq "$using:WebsiteName" -and $_.State -eq "Started" }  
    }

    If($website) {
        Write-Host "Shutdown Website $DestinationComputerName Website: $WebsiteName"
        Invoke-Command -ComputerName $DestinationComputerName -ScriptBlock { 
            $using:website | Stop-Website
        }
        
        Write-Host "Website $WebsiteName Shutdown successful. Checking the state of its Application Pool"

        $appPoolState = Invoke-Command -ComputerName $DestinationComputerName -ScriptBlock { 
            $using:website | Get-WebAppPoolState
        }
        
        if($appPoolState.Value -eq "Started") {
            Write-Host "Stopping Website Application Pool $DestinationComputerName Website: $WebsiteName"
            Invoke-Command -ComputerName $DestinationComputerName -ScriptBlock { 
                 $using:website | Stop-WebAppPool
            }
		}
    }



}
end {

}