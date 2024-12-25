docker network create redis-net
docker run -d \
  --name redis-svr \
  --network redis-net \
  -p 6379:6379 \
  redis


docker run -it --network redis-net busybox
    ping redis-svr


docker run -it \
  --name redis-cmd \
  --network redis-net \
  -p 8081:8081 \
  -e REDIS_HOSTS=redis-svr \
  rediscommander/redis-commander


docker exec -it redis-svr redis-cli
    set key1 value1


docker stop redis-svr
docker stop redis-cmd
docker container prune 
docker network prune
