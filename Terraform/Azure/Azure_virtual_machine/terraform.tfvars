vm_list = [{
  disable_password_authentication = false
  nic_name = "tf-treinamento-nic"
  ip_configuration_name = "internal"
  pip_allocation_method = "Static"
  pip_name = "tf-treinamento-public-ip"
  pip_sku = "Standard"
  private_ip_address_allocation = "Dynamic"
  vm_image_offer = "0001-com-ubuntu-server-jammy"
  vm_image_publisher = "Canonical"
  vm_image_sku = "22_04-lts"
  vm_image_version = "latest"
  vm_name = "tf-treinamento-vm"
  vm_os_disk_name = "tf-treinamento-osdisk"
  vm_size = "Standard_B1s"
  vm_user = "azureuser"
},
{
  disable_password_authentication = false
  nic_name = "tf-treinamento-3-nic"
  ip_configuration_name = "internal"
  private_ip_address_allocation = "Dynamic"
  vm_image_offer = "0001-com-ubuntu-server-jammy"
  vm_image_publisher = "Canonical"
  vm_image_sku = "22_04-lts"
  vm_image_version = "latest"
  vm_name = "tf-treinamento-3-vm"
  vm_os_disk_name = "tf-treinamento-3-osdisk"
  vm_size = "Standard_B1s"
  vm_user = "azureuser"
}]
tags = {}