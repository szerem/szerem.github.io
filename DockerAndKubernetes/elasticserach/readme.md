#

docker network create elasticsearch-net
docker run \
  --name elasticsearch-svr \
  --net elasticsearch-net \
  -p 9200:9200 \
  -p 9300:9300 \
  -e "discovery.type=single-node" \
  -it elasticsearch:7.17.26

docker run \
  --net elasticsearch-net \
  -it appropriate/curl sh 

    ping elasticsearch-svr
    curl -XPUT http:/elasticsearch-svr:9200/my-index
    curl -XGET http:/elasticsearch-svr:9200/_cat/indices?v
    
    