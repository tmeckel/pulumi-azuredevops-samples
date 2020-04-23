import * as pulumi from "@pulumi/pulumi";
import * as azdo from "@pulumi/azuredevops";

const prjName = "tf-test-001"

var prj = azdo.Core.getProject({
    projectName: prjName
})

prj.then((result) => {
    pulumi.log.info(`Sucessfully loaded project with name [${prjName}] => [${result.id}]`)
}).catch((reason) => {
    pulumi.log.error(`Faild to load project with name [${prjName}]`)
})

const prjDefArgs = {
    versionControl: "Git",
    visibility: "private",
    workItemTemplate: "Agile"
}

const newProjName = "pulumi-new-project-nodejs"
var newProj = new azdo.Core.Project(newProjName, {
    projectName: newProjName,
    description: "Pulumi Sample NodeJS Project",
    ...prjDefArgs    
})
