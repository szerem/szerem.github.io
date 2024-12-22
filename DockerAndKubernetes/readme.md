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
```
