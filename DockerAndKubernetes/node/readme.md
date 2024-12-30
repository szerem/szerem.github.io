## by kubectl 
cd k8s-web 
docker build . -t szerem/k8s-web
docker login 
docker push szerem/k8s-web



k create deployment k8s-web --image=szerem/k8s-web 
k expose deployment k8s-web --type=NodePort --port=3000
minikube service k8s-web --url 
curl http://172.25.227.64:32560



kubectl create deployment k8s-web --image=szerem/k8s-web 
kubectl expose deployment k8s-web --type=NodePort --port=3000
kubectl get svc -o wide
minikube service k8s-web

curl http://172.25.227.64:31262

k scale deploy k8s-web --replicas=4

k delete svc k8s-web; k delete deploy k8s-web;


k port-forward services/k8s-web-s 5202:5101


k delete all --all

## by yaml 
https://kubernetes.io/docs/reference/kubernetes-api/workload-resources/deployment-v1/#DeploymentSpec

k apply -f deployment.yaml


https://kubernetes.io/docs/reference/kubernetes-api/service-resources/service-v1/#ServiceSpec

k apply -f service.yaml

minikube service k8s-web-b

k delete -f deployment.yaml -f service.yaml

## deploy web and nginx 

cd k8s-web-nginx
[ web   ]    <-- Loadbalanser 
[ nginx ]

```
docker build . -t szerem/k8s-web-nginx 
docker push szerem/k8s-web-nginx 

k apply -f k8s-web-nginx.yaml -f nginx.yaml
```
minikube service k8s-web-nginx
curl http://172.31.71.39:31009
curl http://172.31.71.39:31009/nginx

k exec k8s-web-nginx-69667db456-x6vv4 -- nslookup nginx
k exec k8s-web-nginx-69667db456-x6vv4 -- wget -qO- http://nginx

k delete -f k8s-web-nginx.yaml -f nginx.yaml
