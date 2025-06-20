terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "4.32.0"
    }
  }
}

provider "azurerm" {
  # Trocar pela sua subscription
  subscription_id = "your-subscription-id"
  features {}
}