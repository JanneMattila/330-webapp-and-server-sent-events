# 330-Webapp and Server-sent Events

## Build Status

[![Build Status](https://dev.azure.com/jannemattila/jannemattila/_apis/build/status/JanneMattila.330-webapp-and-server-sent-events?branchName=master)](https://dev.azure.com/jannemattila/jannemattila/_build/latest?definitionId=51&branchName=master)

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## Introduction

Web app demonstrating the use of [Server-sent events](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events/Using_server-sent_events).

### How to deploy to App Service

Deploy published image to the Azure CLI way:

```batch
# Variables
appSvcName="mywebappssedemo"
appSvcPlanName="webAppPlan"
resourceGroup="rg-webappsse-dev"
location="westeurope"
image="jannemattila/webapp-server-sent-events"

# Login to Azure
az login

# *Explicitly* select your working context
az account set --subscription <YourSubscriptionName>

# Create new resource group
az group create --name $resourceGroup --location $location

# Create App Service Plan
az appservice plan create --name $appSvcPlanName --resource-group $resourceGroup --is-linux --sku B1

# Create App Service
az webapp create --name $appSvcName --plan $appSvcPlanName --deployment-container-image-name $image --resource-group $resourceGroup

# Wipe out the resources
az group delete --name $resourceGroup -y
``` 
