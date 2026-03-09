# Cloud-Security-Labs

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Visão Geral

Este repositório contém uma coleção de laboratórios, scripts e exemplos práticos voltados à **segurança de ambientes em nuvem, híbridos e on‑premises**. O foco está na automação e nas melhores práticas de **DevSecOps**, com ênfase especial em infraestrutura como código (IaC), containers, orquestração e pipelines de desenvolvimento.

**Por que este projeto existe?**

1. Servir como base de estudo e referência para profissionais de segurança e desenvolvedores.
2. Demonstrar como aplicar controles de segurança em diferentes camadas da infraestrutura.
3. Facilitar experimentação com ferramentas modernas e fluxos de trabalho seguros.

---

## Tecnologias e Ferramentas Utilizadas

- **Docker** – construção e gerenciamento de containers seguros e eficientes.
- **Terraform** – provisionamento declarativo de infraestrutura.
- **Kubernetes** – exemplos e scripts para clusters resilientes e hardening.
- **Ansible** – automação de configuração e hardening de sistemas.
- **Pulumi** – IaC com linguagens de programação (TypeScript, Python, etc.).
- **.NET (5/6/8)** – amostras de aplicações seguras integradas a ambientes cloud.

---

## Organização do Repositório

Cada diretório agrupa um conjunto de experimentos, modelos ou automações relacionadas à segurança. A estrutura a seguir mostra os principais conteúdos:

```
/Cloud-Security-Labs
│
├── Docker/                # Dockerfiles e scripts para containers seguros
├── Terraform/             # Módulos e exemplos de provisionamento com Terraform
├── Ansible/               # Playbooks de automação e hardening
├── Pulumi/                # Projetos de IaC em várias linguagens
├── Samples/               # Exemplos de aplicações (.NET, Python, etc.)
├── Docs/                  # Documentação complementar e melhores práticas
└── README.md              # Este documento
```

> Cada pasta inclui instruções detalhadas para reprodução e exploração dos laboratórios.

---

## Começando

1. Clone este repositório:
   ```bash
   git clone https://github.com/Inajara/Cloud-Security-Labs.git
   ```
2. Navegue até o diretório desejado e leia o `README` específico de cada lab.
3. Siga as instruções de instalação e execução listadas nos subprojetos.

> Requisitos comuns: `Docker`, `terraform`, `ansible`, `pulumi` e `kubectl` (dependendo do conteúdo).

---

## Contribuições

Contribuições são bem‑vindas! Sinta‑se à vontade para enviar pull requests com novas ferramentas, exemplos ou melhorias nos labs existentes. Mantenha o padrão de segurança e a documentação clara.

1. Fork este repositório.
2. Crie um branch com a sua feature (`git checkout -b minha-feature`).
3. Adicione testes/documentação quando aplicável.
4. Abra um pull request descrevendo suas alterações.

---

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

---

## Autor

[Ina Lemos (Inajara)](https://github.com/Inajara)

Especialista em segurança da informação com experiência em ambientes híbridos, certificações AWS e Azure, e foco em práticas DevSecOps e CISSP.