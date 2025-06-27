output "vm_ids" {
  description = "IDs das VMs criadas"
  value = { for name, mod in module.virtual_machine : name => mod.vm_id  }
}
