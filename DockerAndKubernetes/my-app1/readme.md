cd frontend 
docker build -t my-app1 -f Dockerfile.dev .


docker build -f Dockerfile.dev .
docker-compose up


<!-- docker run -p 3000:3000 -v /app/node_module -v $PWD:/app 
docker run -p 3005:3000 -v /app/node_module -v $PWD:/app  -->

<!-- docker run -p 3005:3000 -v /app/node_module -v $PWD/:/app -w /app -it my-app1 -->


<!-- docker build -f Dockerfile.dev -t USERNAME:frontend .
docker build -f Dockerfile.dev -t sa:frontend .

docker run -it -p 3000:3000 -v /app/node_module -v ${PWD}:/app sa:frontend -->
