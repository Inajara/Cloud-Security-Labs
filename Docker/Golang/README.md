### Imagem Docker para Aplicação Go (Multi-Stage)
Este projeto define um Dockerfile para criar uma imagem Docker otimizada para executar uma aplicação Go, utilizando um build multi-stage para reduzir o tamanho final da imagem.

## O que este Dockerfile faz?
Este Dockerfile é dividido em duas etapas principais para garantir que a imagem final seja o menor possível, contendo apenas o essencial para rodar sua aplicação Go:

Etapa 1: Build da Aplicação Go (builder)
Base da Imagem: Inicia com a imagem oficial golang:1.18, que contém todas as ferramentas necessárias para compilar código Go.

Diretório de Trabalho: Define /app como o diretório de trabalho dentro do contêiner.

Cópia do Código Fonte: Copia todos os arquivos do diretório local (onde o Dockerfile está) para o diretório /app dentro do contêiner.

Inicialização do Módulo Go: Executa go mod init hello para inicializar um novo módulo Go chamado hello. Isso é crucial para gerenciar as dependências do projeto.

Compilação da Aplicação: Compila o código Go em um executável binário chamado hello e o salva em /app/hello.

Etapa 2: Imagem Final Otimizada
Base da Imagem Leve: Utiliza alpine:3.22.0 como a imagem base para a imagem final. Alpine Linux é uma distribuição muito pequena e leve, ideal para contêineres, pois não inclui muitas ferramentas e bibliotecas desnecessárias.

Cópia do Executável: Este é o ponto chave do build multi-stage. Ele copia apenas o executável hello (que foi compilado na etapa build) para o diretório /app/hello na imagem final. Isso evita que toda a pilha de desenvolvimento Go e suas dependências sejam incluídas na imagem de produção.

Comando de Execução (CMD): Define o comando padrão que será executado quando o contêiner iniciar: /app/hello. Isso inicia sua aplicação Go.

Benefícios do Build Multi-Stage
O uso de um build multi-stage é uma prática recomendada para aplicações Go em Docker porque:

Reduz Drasticamente o Tamanho da Imagem: A imagem final não contém compiladores Go, ferramentas de build ou bibliotecas de desenvolvimento, apenas o executável binário e as dependências mínimas do Alpine. Isso resulta em imagens muito menores, que são mais rápidas para baixar, armazenar e implantar.

Melhora a Segurança: Menos componentes na imagem significam menos superfície de ataque.

Simplifica a Imagem Final: A imagem de produção é limpa e contém apenas o que é estritamente necessário para rodar a aplicação.