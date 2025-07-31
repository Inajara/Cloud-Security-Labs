# Imagem Docker para Nginx Básico
Este projeto define um Dockerfile para criar uma imagem Docker que serve uma página web simples usando Nginx.

## O que este Dockerfile faz?
Este Dockerfile constrói uma imagem Docker focada em servir conteúdo estático de forma eficiente:

- Base da Imagem: 
Utiliza ubuntu:22.04 como sistema operacional base para a construção.

## Instalação de Pacotes:

Atualiza os repositórios de pacotes e instala nginx (servidor web).

Remove os arquivos de cache do apt para otimizar o tamanho final da imagem.

## Exposição de Porta:

Abre a porta 80 para permitir o tráfego HTTP para o servidor Nginx.

## Conteúdo Web:

Copia o arquivo index.html (presumivelmente a página web a ser servida) para o diretório /var/www/html/, que é o diretório padrão de documentos do Nginx.

## Comando Padrão (CMD):

Define o comando que será executado quando o contêiner iniciar: nginx -g "daemon off;". Isso garante que o Nginx seja executado em primeiro plano, o que é crucial para que o contêiner permaneça ativo.

- Diretório de Trabalho: 
Define /var/www/html como o diretório de trabalho padrão dentro do contêiner.

- Variáveis de Ambiente: 
Define uma variável de ambiente APP_VERSION com o valor 1.0.0, que pode ser usada para versionamento da aplicação.

Em resumo, a imagem Docker resultante será um servidor Nginx leve e pronto para servir a sua página index.html.