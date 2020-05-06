# Pulumi C# Azure DevOps Sample

## Running with locally installed provider

If you want to run the sample with a locally installed Azure DevOps Provider add the following XML fragment
to the `azdo-sample-csharp.csproj` DotNet project file

```xml
  <PropertyGroup>
    <RestoreSources>$(RestoreSources);$(HOME)/.pulumi/nuget;https://api.nuget.org/v3/index.json</RestoreSources>
  </PropertyGroup>
```

> **Hint:**  
> If the nuget package won't get updated in the project after the provider has been (locally installed), or
> intellisense isn't working as expected, remove all Pulumi Azure DevOps nuget packages from the nuget 
> package cache and do a manual restore in the project folder
> 
> On Linux the (personal) package cache is located at `${HOME}/.nuget/packages`; to clean old nuget packages
> for the DevOps provider remove the directory `pulumi.azuredevops`from the nuget package cache.
>
> ```sh
> rm -rf ~/.nuget/packages/pulumi.azuredevops
> ```
>
> After removal, install the provider again using `make install`
>