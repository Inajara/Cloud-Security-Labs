# Aplicação Python Flask com Geração de Senhas, Redis e Prometheus
Este projeto consiste em uma aplicação web desenvolvida em Python Flask que permite a geração de senhas. A aplicação utiliza Redis para armazenar as senhas geradas e integra-se com Prometheus para expor métricas de monitoramento. Todo o ambiente é empacotado em um contêiner Docker para facilitar a implantação e a execução.

## Estrutura do Projeto
O projeto é composto pelos seguintes arquivos principais:

- Dockerfile: Define como a imagem Docker da aplicação é construída.

- app.py: O código-fonte da aplicação Flask.

- requirements.txt: Lista as dependências Python necessárias.

- templates/: Diretório contendo os templates HTML da aplicação (e.g., index.html).

- static/: Diretório para arquivos estáticos (CSS, JavaScript, imagens).

## O que este Dockerfile faz?
O Dockerfile é responsável por criar a imagem Docker da sua aplicação Flask:

- Base da Imagem: Utiliza python:3.11-slim como imagem base, que é uma versão leve do Python, otimizada para contêineres.

- Diretório de Trabalho: Define /app como o diretório de trabalho padrão dentro do contêiner.

- Cópia de Arquivos:

    - Copia o arquivo requirements.txt para o diretório de trabalho.

    - Copia o arquivo app.py para o diretório de trabalho.

    - Copia os diretórios templates/ e static/ para o contêiner.

- Instalação de Dependências: 
Executa pip install --no-cache-dir -r requirements.txt para instalar todas as bibliotecas Python listadas no requirements.txt. O --no-cache-dir ajuda a reduzir o tamanho final da imagem.
- Exposição de Porta: 
A porta 5000 é exposta, que é a porta padrão onde a aplicação Flask será executada.
- Comando de Execução (CMD): 
Define o comando que será executado quando o contêiner iniciar: flask run --host=0.0.0.0. Isso inicia o servidor Flask, tornando-o acessível de qualquer interface de rede dentro do contêiner.

## A Aplicação (app.py)
A aplicação app.py é um servidor web Flask com as seguintes funcionalidades:
- Geração de Senhas:
Possui uma função criar_senha que gera senhas com base no tamanho e na inclusão de números e caracteres especiais.
- Integração com Redis:
Conecta-se a um serviço Redis (o host padrão é redis-service, configurável via variável de ambiente REDIS_HOST).
Armazena as senhas geradas em uma lista no Redis (r.lpush("senhas", senha)).
Recupera as últimas 10 senhas geradas para exibição.

## Integração com Prometheus:

- Utiliza a biblioteca prometheus_client para expor métricas.
- Um contador (senha_gerada_counter) é incrementado cada vez que uma senha é gerada.
- Um endpoint /metrics é exposto (na porta 8088 por padrão, iniciada via start_http_server(8088)) para que um servidor Prometheus possa coletar essas métricas.

- Rotas da Aplicação:
    - / (GET, POST): Página inicial que permite gerar senhas e exibe as últimas senhas geradas.
    - /api/gerar-senha (POST): Endpoint de API para gerar senhas via requisições JSON.
    - /api/senhas (GET): Endpoint de API para listar as últimas senhas geradas em formato JSON.
    - /metrics (GET): Endpoint para coletar métricas do Prometheus.

## Dependências (requirements.txt)
As seguintes bibliotecas Python são necessárias para a execução da aplicação:
- Flask==3.0.3: O microframework web para Python.
- redis==4.5.4: Cliente Python para interagir com o servidor Redis.
- prometheus-client==0.16.0: Biblioteca para instrumentar a aplicação com métricas Prometheus.

## Como Usar (Exemplo Básico)
Para construir e executar esta aplicação Docker, você precisará ter o Docker e um servidor Redis em execução (ou um contêiner Redis).

## Construir a Imagem Docker:
```
docker build -t gerador-senhas-app .
```
- Executar um Contêiner Redis (se ainda não tiver um):
```
docker run --name redis-service -p 6379:6379 -d redis
```
- Certifique-se de que o nome do serviço Redis corresponda ao REDIS_HOST configurado no app.py (ou defina a variável de ambiente ao iniciar o contêiner da aplicação).

## Executar o Contêiner da Aplicação:
```
docker run --name gerador-senhas -p 5000:5000 -p 8088:8088 --link redis-service:redis-service -d gerador-senhas-app
```
- -p 5000:5000: Mapeia a porta da aplicação Flask.

- -p 8088:8088: Mapeia a porta das métricas do Prometheus.

- --link redis-service:redis-service: Conecta a aplicação ao contêiner Redis usando o nome redis-service.

## Acessar a Aplicação:

- Abra seu navegador e acesse http://localhost:5000.

- As métricas do Prometheus estarão disponíveis em http://localhost:8088/metrics.