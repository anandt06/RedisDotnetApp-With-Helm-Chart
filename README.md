# RedisDotnetApp-With-Helm-Chart

This application is a dotnet application which is connecting to redis db in kubernete cluster

A helm chart of the application is also attached as zip in the same folder which can be use to run the app in kubernetes

Also build the application tag and push the image to gitlab container registry or docker-hub or any repository and give the path of image accordingly in helm chart.

While installing the helm chart use release name as demoapp

Command for helm Installation => helm install demoapp ./

OR

You can use your own release name and adjust the connection string in the code accordingly to connect to redis-master