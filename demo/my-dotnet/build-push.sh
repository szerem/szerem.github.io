#!/bin/bash
echo "$0 started"

./build-only.sh
# docker compose push

echo "AAAAAAAAAAAAAAAAAAAAAAAAAA $MY_APP_VERSION"
docker push
# docker push szerem/my-friendly-name

echo "$0 done."
