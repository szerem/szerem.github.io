
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
