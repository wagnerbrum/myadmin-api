# Comandos C# uteis

### Criar novo projeto C#
> dotnet new console -o src -n MyAdmin 
<br>
> dotnet new webapi -o src/MyAdmin.WebApi -n MyAdmin.WebApi

### Criar Release para publicação
> dotnet publish -c Release

# Docker

## Dockerfile

### SDK's .net

```Dockerfile
# Release
FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS release

# Development or Build
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS development
```

### Criar imagem
> docker build -t {nome-imagem}:{versao} .
<br>
> docker build -t MyAdmin:v1 .

### Criar container
> docker run -e {enviroment1} -e {enviroment2} -it MyAdmin:v1

### Copiar algo de dentro do container para fora

> docker cp {container_id}:{container_path} {host_path}
<br>
> docker cp {nome-imagem}:"/" "C:\Src\..."

### Monitorar saida do container
> docker attach --sig-proxy=false {nome-imagem}
