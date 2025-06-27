resource "azurerm_resource_group" "rg" {
  name     = "tf-treinamento"
  location = "East US 2"
}

# networking
resource "azurerm_virtual_network" "vnet" {
  name                = "tf-treinamento-vnet"
  address_space       = ["10.0.0.0/16"]
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
}

resource "azurerm_subnet" "subnet" {
  name                 = "tf-treinamento-subnet"
  resource_group_name  = azurerm_resource_group.rg.name
  virtual_network_name = azurerm_virtual_network.vnet.name
  address_prefixes     = ["10.0.1.0/24"] # cidrsubnet(tolist(azurerm_virtual_network.vnet.address_space)[0], 8, 1

}

module "virtual_machine" {
  source   = "./modules/az_virtual_machine"
  for_each = { for vm in var.vm_list : vm.vm_name => vm }
  disable_password_authentication = each.value.disable_password_authentication
  ip_configuration_name = each.value.ip_configuration_name
  location = azurerm_resource_group.rg.location
  nic_name = each.value.nic_name
  pip_allocation_method = each.value.pip_allocation_method
  pip_name = each.value.pip_name
  pip_sku = each.value.pip_sku
  private_ip_address = each.value.private_ip_address
  private_ip_address_allocation = each.value.private_ip_address_allocation
  resource_group_name = azurerm_resource_group.rg.name
  subnet_id = azurerm_subnet.subnet.id
  tags = var.tags
  vm_image_offer = each.value.vm_image_offer
  vm_image_publisher = each.value.vm_image_publisher
  vm_image_sku = each.value.vm_image_sku
  vm_image_version = each.value.vm_image_version
  vm_name = each.value.vm_name
  vm_os_disk_caching = each.value.vm_os_disk_caching
  vm_os_disk_name = each.value.vm_os_disk_name
  vm_os_disk_storage_account_type = each.value.vm_os_disk_storage_account_type
  vm_password = var.vm_password
  vm_size = each.value.vm_size
  vm_user = each.value.vm_user
}