#!/bin/bash


./build-only.sh
docker compose push

#  git update-index --chmod=+x build-push.sh

