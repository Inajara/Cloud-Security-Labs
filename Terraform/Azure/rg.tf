# locals {
#     rg_names = ["dev", "qa", "prod"]
# }

# resource "azurerm_resource_group" "rgs" {
#     for_each = toset(local.rg_names)
#     name = "tf-treinamento-${each.key}"
#     location = "East Us"
  
# }