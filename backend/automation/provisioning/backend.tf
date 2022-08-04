terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=3.6.0"
    }
  }
  backend "azure" { }
}

variable "connectionstring" {
  nullable = false
  type     = string
}

variable "subscription_id" {
  type = string
  nullable = false
}

variable "tenant_id" {
  nullable = false
  type = string
}
variable "client_secret" {
  nullable = false
  type = string
}
variable "client_id" {
  nullable = false
  type = string
}
variable "project_name" {
  nullable = false
  type = string
}
variable "environment" {
  type     = string
  default  = "dev"
  nullable = false

  validation {
    condition = var.environment == "dev" || var.environment == "acc" || var.environment == "prd"
    error_message = "Environment can only be 'dev', 'acc', 'prd'."
  }
}

# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
  subscription_id = var.subscription_id
  tenant_id =  var.tenant_id
  client_id = var.client_id
  client_secret = var.client_secret
}

# Use this data source to access the configuration of the AzureRM provider
data "azurerm_client_config" "current" {}

# Private variables. All properties are provide to improve the scalability later
locals {
  resourcegroup_name     ="wdi-rg-${var.environment}-${var.project_name}"
  resourcegroup_location ="northeurope"
  serviceplan_name       ="wdi-plan-${var.environment}-${var.project_name}"
  serviceplan_ostype     ="Linux"
  serviceplan_skuname    ="B1"
  webapp_name            = "wdi-app-${var.environment}-${var.project_name}"
}

# Create a service plan
resource "azurerm_service_plan" "this" {
  name                = local.serviceplan_name
  location            = local.resourcegroup_location
  resource_group_name = local.resourcegroup_name
  os_type             = local.serviceplan_ostype
  sku_name            = local.serviceplan_skuname
}

# Create service app
resource "azurerm_linux_web_app" "this" {
  name                = local.webapp_name
  resource_group_name = local.resourcegroup_name
  location            = local.resourcegroup_location
  service_plan_id     = azurerm_service_plan.this.id
  site_config {
    application_stack {
      dotnet_version = "6.0"
    }
  }
  connection_string {
    name  = "Default"
    type  = "SQLAzure"
    value = var.connectionstring
  }
}
