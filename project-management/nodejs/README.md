# Pulumi NodeJS Azure DevOps Sample

## Running with locally installed provider

> **Note**  
> Please ensure that the following directories are listed in the `$PATH`
> environment variable. It's advised to extend the `$PATH` environment variable
> in your `$HOME/.bashrc` and `$HOME/.profile`
> 
> * `$HOME/go/bin`
> * `$HOME/.pulumi/bin`

If you want to run the sample with a locally installed Azure DevOps Provider add a link to the installed Javascript files

```sh
$ cd pulumi-azuredevops-samples/project-management/nodejs
$ yarn link "@pulumi/azuredevops"
```
