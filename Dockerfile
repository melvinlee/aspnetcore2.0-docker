FROM microsoft/aspnetcore-build AS builder
WORKDIR /source

 # caches restore result by copying csproj file separately
COPY **/*.csproj .
RUN dotnet restore

 # copies the rest of your code
COPY . .
RUN dotnet publish --output /app/ --configuration Release

 # Stage 2 
FROM microsoft/aspnetcore:2.0
WORKDIR /app
EXPOSE 80
COPY --from=builder /app .
ENTRYPOINT ["dotnet", "hit-counter.dll"]