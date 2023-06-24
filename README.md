# RedisDotnetApp-With-Helm-Chart

This application is a dotnet application which is connecting to redis db in kubernete cluster

A helm chart of the application is also attached as zip in the same folder which can be use to run the app in kubernetes

Also build the application tag and push the image to gitlab container registry or docker-hub or any repository and give the path of image accordingly in helm chart.

Use this command to create secret named regcred before helm chart is installed

kubectl create secret docker-registry regcred --docker-server=https://index.docker.io/v1/ --docker-username=your_user_name --docker-password=your_password --docker-email=your_email_id

docker-server is having value "https://index.docker.io/v1/" beacause we are using docker-hub to upload image of application

Change the value of your_user_name and your_password and your_email_id with your details.

Command for helm Installation => helm install demoapp ./

OR

You can use your own release name and adjust the connection string in the code accordingly to connect to redis-master