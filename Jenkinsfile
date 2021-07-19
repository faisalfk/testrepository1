#!/bin/groovy
import groovy.transform.Field

@Field def indexofEnv
@Field def branches_array
@Field def environments_array
@Field def servers_array
@Field def deployment_folders
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
					branches_array = branches.split('\\*')
					indexofEnv = branches_array.findIndexOf { it == BRANCH_NAME.trim().toLowerCase() }
					echo "Branch Index: ${indexofEnv}"
					
					environments_array = environments.split('\\*')
					echo "Environment: ${environments_array[indexofEnv]}"

					servers_array = servers.split('\\*') 
					deployment_folders = deployment_folder.split('\\*') 
					db_credentialid_array = db_credentialid.split('\\*')
					notification_emails_array = notification_emails.split('\\*')

					target_servers = servers_array[indexofEnv].split(',')
					
					echo "Target Server: ${target_servers}"
					echo "Deployment Folder: ${deployment_folders[indexofEnv]}"
					echo "DB Credential ID: ${db_credentialid_array[indexofEnv]}"
				}
			}
		}
		stage('Build') {
			steps {
				dir(project_path) {
					script {
                        			echo "Building ${project_path}"
                        			bat "\"${MSBUILD}\" /t:package C:\\temp\\TestProjects\\MVC\\testrepository1\\MVCTestApp\\MVCTestApp.csproj"
					}
				}
			}
		}
		stage('Deploy') {
			steps {
				dir(project_path) {
					script {
                        			bat "\"${MSDEPLOY}\" -verb:sync -source:contentPath=C:\\temp\\TestProjects\\MVC\\testrepository1\\MVCTestApp\\obj\\Debug\\Package\\PackageTmp -dest:contentPath=C:\\inetpub\\wwwroot\\MVCTestApp"
					}
				}
			}
		}

		}
		
}

