#docker build -t mywebapp -f ../DockerFiles/WebApp/Dockerfile .

# docker tag. this is for docker local registry
# docker run -d -p 5000:5000 --restart=always --name registry registry:2
# docker tag mywebapp localhost:5000/mywebapp
# docker push localhost:5000/mywebapp



# docker run -d -p 50080:80 --name my_webapp mywebapp
# docker run -it --rm -p 50080:80 -p 50443:443 --name my_webapp mywebapp
# docker run -it --rm -p 50080:80 -p 50443:443 -v D:\Work\vs2019\kubernetes_sample\file_share:/app/file_share --name my_webapp mywebapp
# docker run -it --rm -p 50080:80 -p 50443:443 -v D:\Work\vs2019\kubernetes_sample\file_share:/app/file_share --env-file D:\Work\vs2019\kubernetes_sample\GatewayApi\DockerFiles\WebApp\WebApp.env --name my_webapp mywebapp
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY *.csproj ./
RUN dotnet restore


COPY . ./
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "WebApp.dll"]