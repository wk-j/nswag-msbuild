## Generate client API with NSwag

- Create project

```bash
dotnet new api --language C# --output src/MyApi
dotnet new api --language C# --output src/MyApi.Generate
dotnet add src/MyApi.Generate/MyApi.Generate.csproj reference src/MyApi/MyApi.csproj
```

- Remove default `Startup.cs`

```bash
rm src/MyApi.Generate/Startup.cs
```

- Install packages

```bash
dotnet add src/MyApi/MyApi.csproj package NSwag.AspNetCore
dotnet add src/MyApi.Generate/MyApi.Generate.csproj package NSwag.MSBuild
```

- Add `src/WebApi.Generate/nswag.json`

```json
{
    "runtime": "NetCore22",
    "swaggerGenerator": {
        "aspNetCoreToSwagger": {
            "assemblyPaths": [
                "$(OutputPath)/MyApi.dll"
            ]
        }
    },
    "codeGenerators": {
        "swaggerToTypeScriptClient": {
            "className": "{controller}Client",
            "typeScriptVersion": 1.8,
            "template": "Fetch",
            "output": "../../.client/generated/MyApiClient.ts"
        },
        "swaggerToCSharpClient": {
            "namespace": "MyClient",
            "className": "{controller}Client",
            "output": "../../.client/generated/MyApiClient.cs"
        }
    }
}
```

- Put this tag inside `src/MyApi.Generate/Directory.Build.targets`

```xml
<Project>
    <Target Name="NSwag" AfterTargets="Build">
        <Copy SourceFiles="@(ReferencePath)" DestinationFolder="$(OutDir)References" />
        <Exec Command="$(NSwagExe_Core22) run nswag.json /variables:Configuration=$(Configuration),OutDir=$(OutDir),OutputPath=$(OutputPath)" />
        <RemoveDir Directories="$(OutDir)References" />
    </Target>
</Project>
```

- Generate client API

```bash
dotnet build src/MyApi.Generate/MyApi.Generate.csproj
```

- Check

```bash
.client/generated/MyApiClient.cs
.client/generated/MyApiClient.ts
```