## NSwag

1. Edit `src/NSwagMSBuild/nswag.json`

2. Put this tag inside `NSwagMSBuild.csproj`

```xml
  <Target Name="NSwag" AfterTargets="Build">
    <Copy SourceFiles="@(Reference)" DestinationFolder="$(OutDir)References" />
    <Exec Command="$(NSwagExe_Core21) run /variables:Configuration=$(Configuration)" />
    <RemoveDir Directories="$(OutDir)References" />
  </Target>

```

3. Build

```bash
dotnet build src/NSwagMSBuild/NSwagMSBuild.csproj
```

4. See `client/generated/Api.ts`
