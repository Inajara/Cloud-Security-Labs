terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "4.31.0"
    }
  }
  backend "azurerm" {
    resource_group_name  = "tf-state"
    storage_account_name = "tfstoragestate001"
    container_name       = "tfstate"
    key                  = "aula.terraform.tfstate"
  }
}