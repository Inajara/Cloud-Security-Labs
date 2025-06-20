output "storage_key" {
  description = "Chave da storage account"
  value       = azurerm_storage_account.storage.primary_access_key
  sensitive   = true
}