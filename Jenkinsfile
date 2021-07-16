#!/bin/groovy
import groovy.transform.Field

@Field def indexofEnv
@Field def branches_array
@Field def environments_array
@Field def servers_array
@Field def db_credentialid_array
@Field def notification_emails_array
@Field def target_servers
pipeline {
	agent any

	environment {
		solution_path="${WORKSPACE}"
		project_path="${solution_path}\\MVCTestApp"
        project_publish_folder="${project_path}\\bin\\publish"
		build_properties_file="${solution_path}\\Jenkins.properties"
		MSBUILD = "C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Professional\\MSBuild\\Current\\Bin\\MSBuild.exe"
		MSDEPLOY = "C:\\Program Files\\IIS\\Microsoft Web Deploy V3\\msdeploy.exe"
    }

	stages{

		stage('Load Build Properties') {
			steps {
				script {
                    def build_properties = readFile(file: "${build_properties_file}")
                    
					properties([
						[$class: 'EnvInjectJobProperty', info: [loadFilesFromMaster: false, propertiesContent: "${build_properties}"], keepBuildVariables: true, keepJenkinsSystemVariables: true, on: true]
					])
					
				}
			}
		}
		stage('Prepare') {
			steps {
				script {
def getCurrentBranch () {
    return sh (
        script: 'git rev-parse --abbrev-ref HEAD',
        returnStdout: true
    ).trim()
}
					branches_array = branches.split(':')
					def branchName = getCurrentBranch()
					indexofEnv = branches_array.findIndexOf { it == branchName.trim().toLowerCase() }
					echo "Branch Index: ${indexofEnv}"
					
					environments_array = environments.split(':')
					echo "Environment: ${environments_array[indexofEnv]}"
					servers_array = servers.split(':') 
					db_credentialid_array = db_credentialid.split(':')
					notification_emails_array = notification_emails.split(':')
					target_servers = servers_array[indexofEnv].split(',')
				}
			}
		}


		}
		
}

