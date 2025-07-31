# Etapa 1: Build com Ubuntu e Nginx
FROM ubuntu:22.04 AS builder

RUN apt-get update && apt-get install nginx -y

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
