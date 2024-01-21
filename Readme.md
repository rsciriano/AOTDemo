# AOTDemo

## Publish

```
dotnet publish "./src/NoAOTWebApi/NoAOTWebApi.csproj" -c Release /p:UseAppHost=false
 ls -l src/NoAOTWebApi/bin/Release/net8.0/publish
```

```
dotnet publish "./src/AOTWebApi/AOTWebApi.csproj" -c Release /p:UseAppHost=true
 ls -l -h src/AOTWebApi/bin/Release/net8.0/linux-x64/publish
```


## Build Docker images

```
docker build -t rsciriano/aot-webapi:demo -f src/AOTWebApi/Dockerfile .
```

```
docker build -t rsciriano/noaot-webapi:demo -f src/NoAOTWebApi/Dockerfile .
```

## Deploy to kubernetes

```
helm upgrade --install -f deploy/aot-webapi/helm-values.yaml --namespace aot-demo --create-namespace --atomic --wait --debug aot-webapi bitnami/aspnet-core 
```

```
helm upgrade --install -f deploy/noaot-webapi/helm-values.yaml --namespace noaot-demo --create-namespace --atomic --wait noaot-webapi bitnami/aspnet-core 
```