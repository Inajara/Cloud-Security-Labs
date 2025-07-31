# Etapa 1: Build com Ubuntu e Nginx
FROM ubuntu:22.04 AS builder
#removendo lixo
RUN apt-get update && apt-get install nginx -y && rm -rf /var/lib/apt/lists/*
EXPOSE 80
#dando sinal de vida
COPY index.html /var/www/html/
CMD ["nginx", "-g", "daemon off;"]
# Etapa 2: Configuração do ambiente
WORKDIR /var/www/html
ENV APP_VERSION=1.0.0
