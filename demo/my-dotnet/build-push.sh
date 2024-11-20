#!/bin/bash
echo "$0 started"

my_app_version=$(git describe --tag)

./build-only.sh $my_app_version
# docker compose push
docker push "szerem/$my_app_version"

echo "$0 done."
