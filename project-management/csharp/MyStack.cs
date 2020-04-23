using Pulumi;

class MyStack : Stack
{
    public MyStack()
    {

        const string prjName = "tf-test-001";

        var prj = Pulumi.AzureDevOps.Core.GetProject.InvokeAsync(new Pulumi.AzureDevOps.Core.GetProjectArgs {
            ProjectName = prjName
        });

        prj.ContinueWith((result) => {
            Pulumi.Log.Info($"Sucessfully loaded project with name [${prjName}] => [${result.Id}]");
        });

        const string newProjName = "pulumi-new-project-csharp";
        var newProj = new Pulumi.AzureDevOps.Core.Project(newProjName, new Pulumi.AzureDevOps.Core.ProjectArgs{
            ProjectName = newProjName,
            Description = "Pulumi Sample C# Project",
            VersionControl = "Git",
            Visibility = "private",
            WorkItemTemplate = "Agile"
        });

    }
}
