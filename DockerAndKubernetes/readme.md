# step by step 

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
  docker run \
    -e MARIADB_ROOT_PASSWORD=example \
    mariadb 

  docker run \
    -p 8087:80 \
    -e PMA_HOST=172.17.0.5 \
    phpmyadmin

## 
