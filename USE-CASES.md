### 🔒 Cenário: Hardening de Cluster Kubernetes  
**Problema**: Cluster exposto a vulnerabilidades (CIS Benchmark não aplicado).  
**Solução**: Use o playbook em `ansible/k8s-hardening` para:  
- Desativar o dashboard público.  
- Configurar Network Policies.  
- Logar atividades suspeitas com Falco.  
