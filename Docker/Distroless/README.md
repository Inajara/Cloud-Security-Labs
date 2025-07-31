# Aplicação Python Flask com Geração de Senhas, Redis e Prometheus (Chainguard)
Este projeto apresenta uma aplicação web desenvolvida em Python Flask que gera senhas, armazena-as no Redis e expõe métricas para Prometheus. A principal característica deste setup é o uso de uma imagem base Chainguard no Dockerfile, focando em segurança e minimalismo.

## Estrutura do Projeto
O projeto é organizado com os seguintes arquivos principais:

- Dockerfile: 
Define as instruções para construir a imagem Docker da aplicação.

- app.py: 
Contém o código-fonte da aplicação Flask.

- requirements.txt: 
Lista todas as bibliotecas Python necessárias.

- templates/: 
Diretório para os templates HTML (e.g., index.html).

- static/: 
Diretório para arquivos estáticos (CSS, JavaScript, etc.).

## O que este Dockerfile faz?
O Dockerfile é responsável por criar uma imagem Docker segura e eficiente para sua aplicação Flask:

- Base da Imagem Segura: 
Utiliza cgr.dev/chainguard/python:latest-dev como imagem base. As imagens Chainguard são conhecidas por serem extremamente minimalistas e seguras, contendo apenas o essencial e construídas sem um gerenciador de pacotes tradicional, o que reduz drasticamente a superfície de ataque.

- Diretório de Trabalho: 
Define /app como o diretório de trabalho padrão dentro do contêiner.

- Cópia de Arquivos:
    - Copia o requirements.txt para o diretório de trabalho.
    - Copia o app.py e os diretórios templates/ e static/ para o contêiner.

- Instalação de Dependências Otimizada: 
Executa pip install --user --no-cache-dir -r requirements.txt.

- --user: 
Instala os pacotes no diretório do usuário, o que é uma prática comum em imagens minimalistas como as da Chainguard, que podem não ter permissões de root amplas.

- --no-cache-dir: 
Ajuda a reduzir o tamanho final da imagem, evitando o armazenamento de arquivos de cache do pip.

- Ponto de Entrada (ENTRYPOINT): 
Define o comando principal que será executado quando o contêiner iniciar: flask run --host=0.0.0.0. Isso garante que o servidor Flask seja iniciado e acessível.

## A Aplicação (app.py)
A aplicação app.py é um servidor web Flask com as seguintes funcionalidades:

- Geração de Senhas: 
Uma função criar_senha que gera senhas personalizadas com base no tamanho e na inclusão de números e caracteres especiais.

- Integração com Redis:
    - Conecta-se a um serviço Redis (o host padrão é redis-service, configurável via variável de ambiente REDIS_HOST).
    - Armazena as senhas geradas em uma lista no Redis.
    - Recupera e exibe as últimas 10 senhas geradas na interface web.

- Integração com Prometheus:
    - Um contador (senha_gerada_counter) é incrementado a cada geração de senha.

    - Um endpoint /metrics é exposto na porta 8088 para que um servidor Prometheus possa coletar essas métricas para monitoramento.

- Rotas da Aplicação:
    - / (GET, POST): Página inicial para geração e visualização de senhas.
    - /api/gerar-senha (POST): Endpoint de API para gerar senhas via requisições JSON.
    - /api/senhas (GET): Endpoint de API para listar as últimas senhas geradas em formato JSON.
    - /metrics (GET): Endpoint para coleta de métricas do Prometheus.

- Dependências (requirements.txt)
As bibliotecas Python essenciais para esta aplicação são:
    - Flask==3.0.3: O microframework web.
    - redis==4.5.4: Cliente Python para Redis.
    - prometheus-client==0.16.0: Biblioteca para instrumentação Prometheus.

## Como Usar (Exemplo Básico)
Para construir e executar esta aplicação Docker, você precisará ter o Docker instalado e um servidor Redis disponível (pode ser outro contêiner Docker).

- Construir a Imagem Docker:
```
docker build -t gerador-senhas-chainguard-app .
```
- Executar um Contêiner Redis (se ainda não tiver um):
```
docker run --name redis-service -p 6379:6379 -d redis
```
Certifique-se de que o nome do serviço Redis (redis-service) corresponde ao REDIS_HOST configurado no app.py ou defina a variável de ambiente ao iniciar o contêiner da aplicação.

## Executar o Contêiner da Aplicação:
```
docker run --name gerador-senhas-chainguard -p 5000:5000 -p 8088:8088 --link redis-service:redis-service -d gerador-senhas-chainguard-app
```
- -p 5000:5000: Mapeia a porta da aplicação Flask.

- -p 8088:8088: Mapeia a porta das métricas do Prometheus.

- --link redis-service:redis-service: Conecta a aplicação ao contêiner Redis.

## Acessar a Aplicação:

- Abra seu navegador e acesse http://localhost:5000.

- As métricas do Prometheus estarão disponíveis em http://localhost:8088/metrics.

Este README.md destaca a segurança e a eficiência da imagem Chainguard, além de detalhar as funcionalidades da aplicação Flask.