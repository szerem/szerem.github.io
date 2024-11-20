#!/bin/bash
echo "$0 started"

./build-only.sh
docker compose push
# docker push szerem/my-friendly-name

echo "$0 done."
