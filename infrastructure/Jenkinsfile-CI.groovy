pipeline {
    agent {
        dockerfile {
            filename 'infrastructure/docker/Dockerfile.build'
        }
    } 
    environment{
        HOME = '/tmp'
    }
    stages {
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
