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
					echo "Loading build properties"
                    def build_properties = readFile(file: "${build_properties_file}")

				}
			}
		}
		stage('Cleanup Previous Build') {
			steps {
				dir(project_publish_folder) {
					deleteDir()
				}
			}
		}
		stage('Build') {
			steps {
				dir(project_path) {
					script {
                        echo "Build"
                        bat "\"${MSBUILD}\" /t:package C:\\temp\\TestProjects\\MVC\\testrepository1\\MVCTestApp\\MVCTestApp.csproj"
					}
				}
			}
		}
		stage('Deploy') {
			steps {
				dir(project_path) {
					script {
                        echo "Deploy"
                        bat "\"${MSDEPLOY}\" -verb:sync -source:contentPath=C:\\temp\\TestProjects\\MVC\\testrepository1\\MVCTestApp\\obj\\Debug\\Package\\PackageTmp -dest:contentPath=C:\\inetpub\\wwwroot\\MVCTestApp"
					}
				}
			}
		}
}
}