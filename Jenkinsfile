pipeline {
    agent any
        tools {
            nodejs '19.8.1'
        }
    stages {
        stage('build') {
            steps {
                sh 'npm version'
                sh 'npm i'
                sh 'ls'
                sh 'npm run build'
                sh 'ls'
            }
        }
    }
}
