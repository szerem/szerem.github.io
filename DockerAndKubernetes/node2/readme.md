

docker build --no-cache --progress=plain -t my-node .

docker run -p 5100:8080 my-node 
docker exec <id> ps 


docker build -t my-node .
docker run -p 5100:8080 my-node 
docker exec -it <id> sh 


docker-compose up --build 
