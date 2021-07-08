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
    }

	stages{
		stage('Load Build Properties') {
			steps {
				script {
					echo "Loading build properties"
				}
			}
		}
		stage('Prepare') {
			steps {
				script {
					echo "Preparing build properties"
					echo it
				}
			}
		}
		stage('Cleanup Previous Build') {
			steps {
				dir(web_project_publish_folder) {
					deleteDir()
				}
				dir(service_project_publish_folder) {
					deleteDir()
				}
			}
		}
		stage('Build') {
			steps {
				dir(web_project_path) {
					script {
						echo "Deploying Web Project"
					}
				}
				dir(service_project_path) {
					script {
					echo "Deploying Service"
					}
				}
			}
		}

}
}