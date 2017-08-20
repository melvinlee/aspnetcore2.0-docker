FROM microsoft/aspnetcore:2.0

WORKDIR /app
EXPOSE 80
COPY src/bin/Debug/netcoreapp2.0/publish .
ENTRYPOINT ["dotnet", "hit-counter.dll"]