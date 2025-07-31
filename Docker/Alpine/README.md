### Imagem Docker para Aplicação Go (Multi-Stage com Configurações Adicionais)
Este projeto define um Dockerfile para criar uma imagem Docker otimizada para executar uma aplicação Go, utilizando um build multi-stage para reduzir o tamanho final da imagem e incluindo algumas configurações adicionais de ambiente e volume.

## O que este Dockerfile faz?
Este Dockerfile é dividido em duas etapas principais, projetadas para criar uma imagem final leve e configurável:

Etapa 1: Build da Aplicação Go (builder)
Base da Imagem: Inicia com a imagem oficial golang:1.18, que fornece o ambiente completo para compilar código Go.

Diretório de Trabalho: Define /app como o diretório de trabalho padrão dentro desta etapa.

Cópia do Código Fonte: Copia todos os arquivos do diretório local (onde o Dockerfile está) para /app no contêiner.

Inicialização do Módulo Go: Executa go mod init hello para inicializar um novo módulo Go chamado hello, essencial para gerenciar as dependências.

Compilação da Aplicação: Compila o código Go em um executável binário chamado hello e o salva em /app/hello.

Etapa 2: Imagem Final Otimizada
Base da Imagem Leve: Utiliza alpine:3.22.0 como a imagem base para a imagem final de produção. Alpine Linux é uma distribuição mínima, perfeita para contêineres por seu tamanho reduzido.

Cópia do Executável: Copia apenas o executável hello (compilado na etapa build) para /app/hello na imagem final. Isso garante que as ferramentas de desenvolvimento Go não sejam incluídas na imagem de produção, resultando em um tamanho muito menor.

Variáveis de Ambiente (ENV) e Argumentos de Build (ARG):

ENV app="hello": Define uma variável de ambiente chamada app com o valor "hello".

ARG hello="Linux": Define um argumento de build chamado hello com um valor padrão de "Linux". Este valor pode ser sobrescrito durante o comando docker build (ex: docker build --build-arg hello="World").

ENV hello=$hello: Define uma variável de ambiente hello na imagem final, usando o valor que foi passado via ARG ou seu padrão.

RUN echo "$hello is life S2!": Executa um comando durante a construção que imprime uma mensagem usando a variável de ambiente hello. Isso demonstra como as variáveis de ambiente podem ser utilizadas durante o processo de build.

## Volume (VOLUME):

VOLUME /app/dados: Declara um ponto de montagem de volume em /app/dados. Isso indica que este diretório é destinado a conter dados persistentes e que deve ser montado a partir do host ou de um volume Docker gerenciado quando o contêiner for executado. É útil para dados que precisam sobreviver ao ciclo de vida do contêiner.

Comando de Execução (CMD): Define o comando padrão que será executado quando o contêiner iniciar: /app/hello. Isso inicia sua aplicação Go.

Benefícios do Build Multi-Stage e Configurações Adicionais
Tamanho Reduzido da Imagem: A imagem final é significativamente menor, pois não inclui as ferramentas de desenvolvimento Go. Isso acelera o download, o armazenamento e a implantação.

Segurança Aprimorada: Uma superfície de ataque menor devido à ausência de componentes desnecessários.

Configuração Flexível: O uso de ENV e ARG permite que você configure sua aplicação de forma dinâmica, seja durante o build ou em tempo de execução.

Persistência de Dados: A declaração de VOLUME facilita a gestão de dados persistentes, garantindo que as informações importantes não sejam perdidas quando o contêiner for removido ou atualizado.

Este Dockerfile é um ótimo exemplo de como criar imagens Docker eficientes e configuráveis para aplicações Go. 
