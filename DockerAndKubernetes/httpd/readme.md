docker run -it \
  -v $PWD/httpd/html/:/usr/local/apache2/htdocs/ \
  -p 8080:80 \
  httpd
