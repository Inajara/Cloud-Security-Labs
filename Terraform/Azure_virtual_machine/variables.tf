variable "vm_list" {
  type = list(object({
    disable_password_authentication = bool
    nic_name = string
    ip_configuration_name = string
    pip_allocation_method = optional(string, "Dynamic")
    pip_name = optional(string, null)
    pip_sku = optional(string, "Standard")
    private_ip_address = optional(string, null)
    private_ip_address_allocation = optional(string, "Dynamic")
    vm_image_offer = string
    vm_image_publisher = string
    vm_image_sku = string
    vm_image_version = string
    vm_name = string
    vm_os_disk_caching = optional(string, "ReadWrite")
    vm_os_disk_name = string
    vm_os_disk_storage_account_type = optional(string, "Standard_LRS")
    vm_size = string
    vm_user = string
  }))
  description = "Lista de VMs"
}

variable "vm_password" {
  description = "Senha da VM"
  type = string
  sensitive = true
}

variable "tags" {
  description = "Tags"
  type = map(string)
}