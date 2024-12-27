## api as python and web as node  

### api
``` powershell
cd api 
pipenv requirements > requirements.txt 
docker build . -t images-gallery-api

docker run -it -p 5050:5050 images-gallery-api

```
how to check 
curl localhost:5050/new-image?query=car



``` powershell
docker exec -it <id or name> bash 
    ps -x 

```

### web 
``` powershell
cd my-app 

docker build . -t images-gallery-web

docker run -it -p 3000:3000 images-gallery-web
```

## web & api 
``` 
docker run -d -p 5050:5050 images-gallery-api
docker run -d -p 3000:3000 images-gallery-web

docker exec -it <id> sh 
    ps 
    ps -x
```



## docker compose 
```
docker container prune
docker-compose up 
docker-compose up -d 

docker-compose down

```
