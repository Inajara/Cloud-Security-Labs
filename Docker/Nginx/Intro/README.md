### Imagem Docker para Nginx Minimalista
Este projeto define um Dockerfile para criar uma imagem Docker que serve uma página web usando Nginx de forma simples e direta.

## O que este Dockerfile faz?
Este Dockerfile constrói uma imagem Docker com o Nginx, pronta para servir conteúdo estático:

Base da Imagem: Utiliza ubuntu:22.04 como sistema operacional base.

## Instalação de Pacotes:

Atualiza os repositórios de pacotes e instala o nginx (servidor web).

## Exposição de Porta:

Abre a porta 80 para permitir o tráfego HTTP para o servidor Nginx.

## Comando Padrão (CMD):

Define o comando que será executado quando o contêiner iniciar: nginx -g "daemon off;". Isso garante que o Nginx seja executado em primeiro plano, o que é essencial para que o contêiner permaneça ativo.

Em resumo, esta imagem Docker é um servidor Nginx leve e pronto para servir suas páginas web. Você precisará adicionar seus arquivos HTML e outros recursos ao contêiner quando o executar ou durante o processo de build, dependendo da sua necessidade.