terraform {
  backend "azurerm" {
    resource_group_name  = "tf-state"
    storage_account_name = "tfstoragestate001"
    container_name       = "tfstate"
    key                  = "aula.terraform.tfstate"
  }
}