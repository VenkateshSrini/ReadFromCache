Deploy an app using the minikube . some interesting stuff 
start kubernets
-----------------
minikube.exe start --vm-driver="hyperv" --hyperv-virtual-switch="kubevirtualswitch" --v=7 --alsologtostderr (for version 0.24)
minikube start --kubernetes-version=v1.8.0 --vm-driver="hyperv" --hyperv-virtual-switch="kubevirtualswitch" ( for version 0.25)minikube addons enable ingress
kubectl cluster-infokubectl get pods --all-namespaces
kubectl proxy
dashboard url - http://localhost:8001/ui

install ingress
------------------

-url
--------------------------
https://medium.com/@gokulc/setting-up-nginx-ingress-on-kubernetes-2b733d8d2f45https://kubernetes.io/docs/tools/kompose/user-guide/

openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout D:/Venkatesh/ASPNETCore/2.0/KuberNetStart/code/ReadFromCache/runfolder/nginx-selfsigned.key -out D:/Venkatesh/ASPNETCore/2.0/KuberNetStart/code/ReadFromCache/runfolder/nginx-selfsigned.crt
openssl dhparam -out D:/Venkatesh/ASPNETCore/2.0/KuberNetStart/code/ReadFromCache/runfolder/dhparam.pem 2048

kubectl create secret tls tls-certificate --key nginx-selfsigned.key --cert nginx-selfsigned.crtkubectl create secret generic tls-dhparam --from-file=dhparam.pem

deploy app 
-----------------
kubectl run readfromcache --image=venkateshsrini3/readfromcache:20180127041655 --port=65069
kubectl get deploymentskubectl expose deployment readfromcache  --type=NodePortminikube service readfromcache --url

stop minikube
----------------
minikube stop

important link
-------------------
https://github.com/kubernetes/minikube/issues/754#issuecomment-258129252

https://github.com/dotnet-architecture/eShopOnContainers/wiki/10.-Setting-the-solution-up-in-ACS-Kuberneteshttps://medium.com/@somakdas/containerizing-a-net-core-application-using-docker-acs-and-kubernetes-part-3-aeb0b71e70d1
