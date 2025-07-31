# Imagem Docker para Nginx com Node Exporter
Este projeto define um Dockerfile para criar uma imagem Docker que serve uma página web simples usando Nginx e inclui o Node Exporter para coletar métricas do sistema.

## O que este Dockerfile faz?
O Dockerfile é dividido em etapas para construir uma imagem otimizada e funcional:

- Base da Imagem: Utiliza ubuntu:22.04 como sistema operacional base para a construção.

- Metadados: Define o maintainer (mantenedor) da imagem.

## Instalação de Pacotes:

Atualiza os repositórios de pacotes e instala nginx (servidor web) e curl (ferramenta para fazer requisições HTTP).

Limpa os arquivos de cache do apt para reduzir o tamanho final da imagem.

## Exposição de Porta:

Abre a porta 80 para permitir o tráfego HTTP para o servidor Nginx.

## Node Exporter:

Descompacta o arquivo node_exporter-1.6.0.linux-amd64.tar.gz no diretório /root/node-exporter. O Node Exporter é uma ferramenta popular para expor métricas de hardware e SO para sistemas de monitoramento como o Prometheus.

## Conteúdo Web:

Copia o arquivo index.html (presumivelmente a página web a ser servida) para o diretório /var/www/html/, que é o diretório padrão de documentos do Nginx.

- Diretório de Trabalho: 
Define /var/www/html como o diretório de trabalho padrão dentro do contêiner.

- Variáveis de Ambiente: 
Define uma variável de ambiente APP_VERSION com o valor 1.0.0, que pode ser usada para versionamento da aplicação.

## Ponto de Entrada (ENTRYPOINT):

Configura nginx como o comando principal a ser executado quando o contêiner inicia.

## Comando Padrão (CMD):

Fornece os argumentos padrão para o ENTRYPOINT, garantindo que o Nginx seja executado em primeiro plano (daemon off;), o que é essencial para contêineres Docker.

## Verificação de Saúde (HEALTHCHECK):

Define um mecanismo de verificação de saúde que tenta acessar localhost na porta 80 usando curl. Se a requisição falhar, o contêiner é considerado não saudável. O timeout é de 2 segundos.

Em resumo, a imagem Docker resultante será um servidor Nginx pronto para servir a página index.html, com o Node Exporter configurado para monitoramento e um mecanismo de verificação de saúde para garantir sua disponibilidade.