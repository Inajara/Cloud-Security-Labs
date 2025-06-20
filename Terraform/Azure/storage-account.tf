


#Se quiser que o indice começe do "1", use +1 no count. ]


resource "azurerm_storage_account" "storages" {
  count                    = 3
  name                     = "valtertest${count.index + 1}"
  resource_group_name      = azurerm_resource_group.rg.name
  location                 = azurerm_resource_group.rg.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}