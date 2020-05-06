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
    features: {
        "testplans": "disabled",
        "artifacts": "disabled"
    },
    ...prjDefArgs    
})

const newProjName2 = "pulumi-new-project-nodejs-1"
var newProj2 = new azdo.Core.Project(newProjName2, {
    projectName: newProjName2,
    description: "Pulumi Sample NodeJS Project 2",
    ...prjDefArgs    
})

const newProjFeatures = "features-" + newProjName2
var prjFeatures = new azdo.Core.ProjectFeatures(newProjFeatures, {
    projectId: newProj2.id,
    features: {
        "repositories": "disabled",
        "testplans": "disabled",
        "artifacts": "disabled"
    }
})