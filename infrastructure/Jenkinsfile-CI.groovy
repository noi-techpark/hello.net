pipeline {
    agent {
        dockerfile {
            filename 'infrastructure/docker/Dockerfile'
        }
    } 
    stages {
        stage('Configure') {
            steps {
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet build'
            }
        }
        stage('Test') {
            steps {
                sh 'dotnet test /p:CollectCoverage=true'
            }
            
        }
    }
}
