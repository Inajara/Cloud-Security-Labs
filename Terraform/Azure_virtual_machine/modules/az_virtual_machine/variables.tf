variable "disable_password_authentication" {
  description = "Descrição"
  type        = bool
}

variable "ip_configuration_name" {
  description = "Descrição"
  type        = string
}

variable "location" {
  description = "Descrição"
  type        = string
}

variable "nic_name" {
  description = "Descrição"
  type        = string
}

variable "pip_allocation_method" {
  description = "Descrição"
  type        = string
  default     = "Static"
}

variable "pip_name" {
  description = "Descrição"
  type        = string
  default     = null
}

variable "pip_sku" {
  description = "Descrição"
  type        = string
  default     = "Standard"
}

variable "private_ip_address" {
  description = "Descrição"
  type        = string
}

variable "private_ip_address_allocation" {
  description = "Descrição"
  type        = string
}

variable "resource_group_name" {
  description = "Descrição"
  type        = string
}

variable "subnet_id" {
  description = "Descrição"
  type        = string
}

variable "tags" {
  description = "Descrição"
  type        = map(string)
}

variable "vm_image_offer" {
  description = "Descrição"
  type        = string
}

variable "vm_image_publisher" {
  description = "Descrição"
  type        = string
}

variable "vm_image_sku" {
  description = "Descrição"
  type        = string
}

variable "vm_image_version" {
  description = "Descrição"
  type        = string
}

variable "vm_name" {
  description = "Descrição"
  type        = string

  validation {
      condition     = can(regex("^tf-", var.vm_name))
      error_message = "A VM tem que começar com 'tf-' no nome"
  }
}

variable "vm_os_disk_caching" {
  description = "Descrição"
  type        = string
}

variable "vm_os_disk_name" {
  description = "Descrição"
  type        = string
}

variable "vm_os_disk_storage_account_type" {
  description = "Descrição"
  type        = string
}

variable "vm_password" {
  description = "Descrição"
  type        = string
  sensitive   = true
}

variable "vm_size" {
  description = "Descrição"
  type        = string
}

variable "vm_user" {
  description = "Descrição"
  type        = string
}
