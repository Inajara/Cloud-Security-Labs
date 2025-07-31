# Etapa 1: Build com Ubuntu e Nginx
FROM ubuntu:22.04 AS builder
#é só uma tag(a quem pertence/contatar)
LABEL maintainer="inajaracloud@outlook.com"
#removendo lixo
RUN apt-get update && apt-get install nginx curl -y && rm -rf /var/lib/apt/lists/*
EXPOSE 80
#pode alocar pacotes de links
ADD https://github.com/prometheus/node_exporter/releases/download/v1.6.0/node_exporter-1.6.0.linux-amd64.tar.gz /root/node-exporter
#apenas local
COPY index.html /var/www/html/
# Etapa 2: Configuração do ambiente
WORKDIR /var/www/html
ENV APP_VERSION=1.0.0
ENTRYPOINT ["nginx"]
CMD ["-g", "daemon off;"]
#checando estado do sistema
HEALTHCHECK --timeout=2s CMD curl -f localhost || exit 1