using System.Collections.Generic;
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
            ProjectName      = newProjName,
            Description      = "Pulumi Sample C# Project",
            VersionControl   = "Git",
            Visibility       = "private",
            WorkItemTemplate = "Agile",
            Features         = new Dictionary<string, string>() {
                { "artifacts", "disabled" },
                { "testplans", "disabled" }
            }
        });

        const string newProjName2 = "pulumi-new-project-csharp-1";
        var newProj2 = new Pulumi.AzureDevOps.Core.Project(newProjName2, new Pulumi.AzureDevOps.Core.ProjectArgs{
            ProjectName      = newProjName2,
            Description      = "Pulumi Sample C# Project 2",
            VersionControl   = "Git",
            Visibility       = "private",
            WorkItemTemplate = "Agile",
        });

        const string newProjFeatures = "features-" + newProjName2;
        var prjFeatures = new Pulumi.AzureDevOps.Core.ProjectFeatures(newProjFeatures, new Pulumi.AzureDevOps.Core.ProjectFeaturesArgs {
            ProjectId = newProj2.Id,
            Features  = new Dictionary<string, string>() {
                { "repositories", "disabled" },
                { "artifacts", "disabled" },
                { "testplans", "disabled" }
            }
        });
    }
}
