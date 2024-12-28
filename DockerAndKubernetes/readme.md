# DOCKER 

## how to check if running 
``` powershell
docker run hello-world
docker images 
docker ps
docker ps -a
```

## how to run in interactive mode  
``` powershell
docker run -it ubuntu bash
docker run -it busybox
```

## create new alpine container 
``` powershell
docker pull alpine
docker run -it alpine
```

## create nginx container with local map files
``` powershell
docker pull nginx
docker run -p 8080:80 nginx
docker run -p 8081:80 -v ${env:DockerLocalRepo}/nginx:/usr/share/nginx/html nginx      
docker run -p 8080:80 -v $PWD/nginx:/usr/share/nginx/html nginx

docker run -p 8080:80 -v $PWD/nginx:/usr/share/nginx/html --name MyNginx nginx


docker run -p 8080:80 -d nginx
docker logs <id>
```
to generate favicon.ico go to [favicon.io]:[https://favicon.io]


## create python container 
``` powershell
docker pull python 
docker run -it -v $PWD/python:/app python python3 app/hello-world.py
docker run -it -v $PWD/python:/app -w /app python python3 hello-world.py

docker run -it -v $PWD/python:/app -w /app python python3 Calendar-app.py
```


## create node container 
``` powershell
docker container prune
docker pull node 
docker run -it -v $PWD/node:/app -w /app node node hello.js
docker run -it -v $PWD/node:/app -w /app node node hello.js

cd node/express
docker run -v $PWD/:/app -w /app -it node npm init -y
docker run -v $PWD/:/app -w /app -it node npm install express
docker run -v $PWD/:/app -w /app -it node node index.js
docker run -v $PWD/:/app -w /app -it -p 3000:3000 node node index.js


cd node/file
docker run -v $PWD/:/app -w /app -it node node create-file.js

```


## create mongo container 
``` powershell
docker container prune
docker pull mongo
docker run mongo 
docker exec -it <id> bash   
  ps -e
  cat /usr/local/bin/docker-entrypoint.sh 
docker inspect <id>
docker-entrypoint.sh

docker exec -it <id> mongosh 
  db.version()
  show dbs
  db
  use test
  db.animals.insert({"animal":"cat"})
  db.animals.insert({"animal":"dog"})
  db.animals.insert({"animal":"monkey"})
  db.animals.find()
docker exec -it <id> mongosh 


docker run -d -v $PWD/mongo/db/:/data/db/ mongo
docker exec -it <id> mongosh 
docker exec -it <id> bash 
  mongosh  

```



## mapping data for development purposes


### wordpress 
``` powershell
docker container prune
docker run -d -p 8080:80 wordpress
```

### docker network 
docker run -it busybox      | docker run -it busybox
  hostname -i               |
    172.17.0.4              |     172.17.0.2
  ping 172.17.0.2           |   ping 172.17.0.4
  docker inspect <id>

docker exec <id> env

### case 1 by name 
#### mysql 
docker run --name mysql_db_server -e MYSQL_ROOT_PASSWORD=example mysql 
                  ----------------
#### php my admin
docker run --name phpmyadmin -d --link mysql_db_server:db -p 8083:80 phpmyadmin
                                  -----------------------


### case 2 by ip 
#### mariadb 
docker run -e MARIADB_ROOT_PASSWORD=example mariadb 
docker run -it <id> sh 
  hostname -i
    172.17.0.5

#### phpmyadmin
docker run -p 8085:80 -e PMA_HOST=172.17.0.5 phpmyadmin


### case 3 in bash 
  docker network create my-sql
  docker run \
    --name mariadb_server \
    --network my-sql \
    -e MARIADB_ROOT_PASSWORD=my-password \
    -d mariadb 

  docker run \
    --name phpmyadmin_server \
    --network my-sql \
    -p 8080:80 \
    -e PMA_HOST=mariadb_server\
    -d phpmyadmin

  docker run \
    --name wordpress_server \
    --network my-sql \
    -p 8082:80 \
    -e WORDPRESS_DB_HOST=mariadb_server \
    -e WORDPRESS_DB_USER=root \
    -e WORDPRESS_DB_PASSWORD=my-password \
    -e WORDPRESS_DB_NAME=exampledb \
    -it wordpress

  docker network inspect my-sql


## custom bridge network 
docker network ls
docker network create my-net
docker network inspect my-net 
docker run -it --network my-net --name name1 -h host1 busybox
docker run -it --network my-net --name name2 -h host2 busybox
## 



# K8S 

kubectl run nginx --image=nginx
kubectl describe pod nginx
kubectl get pods
kubectl get pods -o wide
kubectl delete pod nginx

Set-Alias -Name k -Value kubectl

k create deployment nginx-deployment --image=nginx
k describe deployment nginx-deployment
k describe pod nginx-deployment-c45d79c8-bwmzg 

k scale deployment nginx-deployment --replicas=5
k get pods -o wide

k exec --stdin --tty nginx-deployment-c45d79c8-bwmzg -- /bin/bash
k exec -it nginx-deployment-c45d79c8-bwmzg -- /bin/bash
k exec -it nginx-deployment-c45d79c8-bwmzg -- bash

k get deploy 
k get deploy -o wide

k expose deployment nginx-deployment --port=8080 --target-port=80
k get services
k get services -o wide

k describe services nginx-deployment
  
k port-forward service/nginx-deployment 8081:8080

k delete svc nginx-deployment
k expose deployment nginx-deployment --type=NodePort --port=8080 --target-port=80 --name=nginx-deployment


k delete service nginx-deployment
k delete deployment nginx-deployment

<!-- https://kubernetes.io/docs/tasks/debug/debug-application/debug-service/ -->
