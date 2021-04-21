#docker build -t mygateway -f ../DockerFiles/GatewayApi/Dockerfile .

# docker run -d -p 51080:80 --name api_gateway mygateway
# docker run -it --rm -p 51080:80 -p 51443:443 --name api_gateway mygateway
# docker run -it --rm -p 51080:80 -p 51443:443 -v D:\Work\vs2019\kubernetes_sample\file_share:/app/file_share --name api_gateway mygateway
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
ENTRYPOINT ["dotnet", "GatewayApi.dll"]