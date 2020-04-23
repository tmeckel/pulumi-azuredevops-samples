# Pulumi C# Azure DevOps Sample

## Running with locally installed provider

If you want to run the sample with a locally installed Azure DevOps Provider add the following XML fragment
to the `azdo-sample-csharp.csproj` DotNet project file

```xml
  <PropertyGroup>
    <RestoreSources>$(RestoreSources);$(HOME)/.pulumi/nuget;https://api.nuget.org/v3/index.json</RestoreSources>
  </PropertyGroup>
```