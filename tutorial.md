comandos
- dotnet new console -o App -n DotNet.Docker
- dotnet publish -c Release


dotnet sdk version: 5.0.102

FROM mcr.microsoft.com/dotnet/aspnet:6.0

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine



docker build -t counter-image -f Dockerfile .

docker start core-counter
docker stop core-counter

docker attach --sig-proxy=false core-counter

