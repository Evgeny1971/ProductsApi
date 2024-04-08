#Start a SQL Server Container (docker)
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=unity@052024"   -p 1433:1433 --name sql_server   -v sql_data:/var/opt/mssql   -d mcr.microsoft.com/mssql/server:2019-latest

#Test docker
docker ps -a

#Inspect IP of docker
Execute : 
docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' sql_server

(172.17.0.2 - IP2)
