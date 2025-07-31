### Explorando Dockerfiles
Este repositório contém uma coleção de Dockerfiles que demonstram diferentes abordagens para empacotar aplicações e serviços em contêineres Docker. Cada Dockerfile é projetado para um propósito específico, ilustrando desde configurações básicas de servidor web até builds otimizados de aplicações Go.

## O que são Dockerfiles?
Um Dockerfile é um script que contém uma série de instruções que o Docker Engine executa para construir uma imagem Docker. Ele define o ambiente, as dependências, o código da aplicação e as configurações de execução, garantindo que sua aplicação seja executada de forma consistente em qualquer lugar.

## Dockerfiles Explorados
Aqui está um resumo dos tipos de Dockerfiles que foram abordados:

1. Nginx com Node Exporter (com ADD local)
Este Dockerfile cria uma imagem Docker para servir conteúdo estático usando Nginx e inclui o Node Exporter (uma ferramenta para coletar métricas do sistema) que é adicionado a partir de um arquivo local. Ele também configura verificações de saúde (HEALTHCHECK) para monitorar a disponibilidade do serviço.

2. Nginx Básico
Uma versão mais simplificada, este Dockerfile foca apenas em empacotar o Nginx para servir páginas web. É ideal para cenários onde você precisa de um servidor web leve sem componentes adicionais.

3. Nginx Minimalista
A versão mais básica, este Dockerfile apenas instala o Nginx e o configura para rodar. Ele serve como um ponto de partida para quem precisa de um contêiner Nginx puro, onde o conteúdo web seria adicionado posteriormente ou montado via volume.

4. Nginx com Node Exporter (com ADD remoto)
Similar ao primeiro, mas com uma diferença chave: o Node Exporter é baixado e descompactado diretamente de uma URL remota (como o GitHub) usando a instrução ADD. Isso demonstra a flexibilidade do Dockerfile para buscar recursos de diversas fontes.

5. Aplicação Go (Build Multi-Stage)
Este Dockerfile é um excelente exemplo de como otimizar o tamanho da imagem final para aplicações compiladas (como Go). Ele utiliza um build multi-stage:

A primeira etapa (builder) compila a aplicação Go.

A segunda etapa (final) copia apenas o executável compilado para uma imagem base muito leve (alpine), resultando em uma imagem de produção significativamente menor e mais segura.

6. Aplicação Go (Multi-Stage com Configurações Adicionais)
Uma extensão do Dockerfile anterior, este também utiliza o build multi-stage para aplicações Go, mas adiciona conceitos importantes como:

Variáveis de Ambiente (ENV): Para configurar a aplicação em tempo de execução.

Argumentos de Build (ARG): Para passar valores durante o processo de construção da imagem.

Volumes (VOLUME): Para declarar pontos de montagem para dados persistentes, garantindo que os dados da aplicação não sejam perdidos quando o contêiner é removido.

Conceitos Chave Demonstrados
Através desses Dockerfiles, vários conceitos fundamentais do Docker são ilustrados:

FROM: Define a imagem base para o build.

RUN: Executa comandos durante a construção da imagem.

EXPOSE: Informa quais portas o contêiner escuta em tempo de execução.

COPY: Copia arquivos do host para a imagem.

ADD: Copia arquivos (e pode descompactar arquivos tar ou baixar de URLs) para a imagem.

CMD: Define o comando padrão a ser executado quando o contêiner inicia.

ENTRYPOINT: Configura o comando principal que será executado no contêiner.

HEALTHCHECK: Define um comando para verificar a saúde do contêiner.

LABEL: Adiciona metadados à imagem.

WORKDIR: Define o diretório de trabalho padrão.

ENV: Define variáveis de ambiente.

ARG: Define variáveis de build.

VOLUME: Declara um ponto de montagem para dados persistentes.

Build Multi-Stage: Uma técnica para criar imagens menores e mais eficientes, separando as etapas de build e runtime.

## Por Que Usar Docker?
O Docker oferece inúmeros benefícios para o desenvolvimento e implantação de aplicações:

Consistência: Garante que sua aplicação funcione da mesma forma em qualquer ambiente.

Isolamento: Cada contêiner é isolado do sistema host e de outros contêineres.

Portabilidade: Contêineres podem ser facilmente movidos entre diferentes ambientes.

Eficiência: Utiliza recursos de forma mais eficiente do que máquinas virtuais tradicionais.

Escalabilidade: Facilita a escalabilidade de aplicações, permitindo que você execute múltiplas instâncias de um serviço.

Sinta-se à vontade para explorar cada Dockerfile individualmente para entender melhor suas funcionalidades e como eles podem ser aplicados em seus próprios projetos!