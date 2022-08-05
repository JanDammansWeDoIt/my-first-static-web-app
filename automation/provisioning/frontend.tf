terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=3.0.0"
    }
  }
  backend "azurerm" { }
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

variable "environment" {
  type    = string
  default = "dev"

  validation {
    condition = var.environment == "dev" || var.environment == "acc" || var.environment == "prd"
    error_message = "Environment can only be 'dev', 'acc', 'prd'."
  }
}

variable "project_name" {
  type    = string
  default = "nextgen"
}

variable "rg_name" {
  type    = string
  default = "<PLACEHOLDER>"
}

variable "static_name" {
  type    = string
  default = "<PLACEHOLDER>"
}

locals {
  template    = "wdi-<RESOURCE>-${var.environment}-${var.project_name}"
  rg_name     = var.rg_name == "<PLACEHOLDER>" ? replace(local.template, "<RESOURCE>", "rg") : var.rg_name
  static_name = var.static_name == "<PLACEHOLDER>" ? replace(local.template, "<RESOURCE>", "static") : var.static_name
}

# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
  subscription_id = var.subscription_id
  tenant_id =  var.tenant_id
  client_id = var.client_id
  client_secret = var.client_secret
}

data "azurerm_client_config" "current" {}

resource "azurerm_static_site" "this" {
  name                = local.static_name
  resource_group_name = local.rg_name
  location            = "westeurope"
}

output "deploymentToken" {
  value     = azurerm_static_site.this.api_key
  sensitive = true

}