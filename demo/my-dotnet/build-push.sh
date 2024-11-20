#!/bin/bash
echo "$0 started"

./build-only.sh 
docker compose push
# docker push "szerem/$my_app_version"

echo "$0 done."
