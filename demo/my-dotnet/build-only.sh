#!/bin/bash

my_app_version_arg=$1
my_app_version_git=$(git describe --tag)
my_app_version="${my_app_version_arg:-$my_app_version_git}"
# # git tag v1.1.1; git push --tags
# # git tag -a v1.1 -m "my version 1.1"  
echo "MY_APP_VERSION=$my_app_version"
docker compose build --pull --build-arg "MY_APP_VERSION=$my_app_version"
docker tag weshigbee/actions-web:latest "szerem/$my_app_version"

echo "$0 done."
