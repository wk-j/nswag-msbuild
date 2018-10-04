## Commands

```bash
dotnet new webapi --output src/MyApi
dotnet add src/MyApi/MyApi.csproj package NSwag.MSBuild
dotnet build src/MyApi/MyApi.csproj
```