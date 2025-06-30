variable "vm_user" {
  description = "Meu user"
  type        = string
  default     = "azureuser"
}

variable "vm_password" {
  description = "Senha da maquina"
  type        = string
  sensitive   = true
}

variable "resource_group_name" {
  description = "aaaaaa"
  type        = string
}

variable "location" {
  description = "aaaaaa"
  type        = string
}

variable "storage_account_name" {
  description = "aaaaaa"
  type        = string
}

variable "storage_account_tier" {
  description = "aaaaaa"
  type        = string
}

variable "storage_account_replication_type" {
  description = "aaaaaa"
  type        = string
  default     = "LRS"
}

variable "tags" {
  description = "aaaaaa"
  type        = map(string)
}
