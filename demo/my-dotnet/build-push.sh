#!/bin/bash
echo "$0 started"

./build-only.sh
docker compose push

echo "$0 DONE"
