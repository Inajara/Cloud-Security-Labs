# 🔐 API Segura em .NET 8 com JWT e Swagger

Este projeto é uma API RESTful de demonstração desenvolvida em .NET 8 que implementa autenticação e autorização usando JSON Web Tokens (JWT). Ele também integra o Swagger/OpenAPI para documentação interativa da API, permitindo testar os endpoints protegidos diretamente da interface do Swagger.

## Funcionalidades Principais
- Autenticação JWT: 
Implementa um fluxo de autenticação JWT, onde os usuários podem fazer login para obter um token de acesso.
- Autorização Baseada em JWT: 
Protege endpoints da API, exigindo um token JWT válido para acesso.
- Swagger/OpenAPI: 
Geração automática de documentação da API e uma interface de usuário interativa para explorar e testar os endpoints.
- Integração JWT no Swagger UI: 
Permite que você insira seu token JWT diretamente na interface do Swagger para testar endpoints protegidos.
- Exemplo de Endpoint Protegido: 
Inclui um endpoint de exemplo (/WeatherForecast) que requer autenticação.
- Exemplo de Login: 
Um endpoint /api/Auth/login para simular o login e gerar um token.

## ⚙️ Tecnologias utilizadas

- [.NET 8](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8)
- ASP.NET Core Web API
- Autenticação JWT com `Microsoft.AspNetCore.Authentication.JwtBearer`
- Swagger (Swashbuckle) com suporte a Bearer token

## Estrutura do Projeto

- Program.cs:
    - Configura os serviços da aplicação, incluindo controladores, Swagger, autenticação JWT e autorização.
    - Define os parâmetros de validação do token JWT (Issuer, Audience, Key, Lifetime).

- appsettings.json:
    - Contém as configurações da aplicação, incluindo os parâmetros para a configuração do JWT (Key, Issuer, Audience, ExpiresInMinutes).

- Controllers/AuthController.cs:
    - Contém a lógica para o endpoint de login (/api/Auth/login).
    - Simula a autenticação de um usuário (admin/password) e gera um token JWT válido.

- Controllers/WeatherForecastController.cs:
    - Um controlador de exemplo com um endpoint (/WeatherForecast) que é protegido pela autorização JWT (requer um token válido).

## Pacotes NuGet Utilizados
As seguintes bibliotecas NuGet são essenciais para o funcionamento deste projeto:
- Microsoft.AspNetCore.Authentication.JwtBearer: 
Para habilitar a autenticação JWT.
- Microsoft.AspNetCore.Identity.EntityFrameworkCore: 
(Embora presente, não é diretamente utilizado para autenticação neste exemplo simples, mas é comum em projetos maiores com gerenciamento de usuários).
- Swashbuckle.AspNetCore: 
Para integrar o Swagger/OpenAPI.
- Swashbuckle.AspNetCore.Filters: 
Para adicionar funcionalidades extras ao Swagger, como a configuração de segurança JWT.

---

## 🚀 Como executar localmente

### Pré-requisitos:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Editor como Visual Studio, VS Code ou Rider
- (Opcional) [Postman](https://www.postman.com/) ou cURL para testar os endpoints

### Passos:

1. Clone o repositório:
```bash
git clone https://github.com/Inajara/Cloud-Security-Labs.git
cd Cloud-Security-Labs/Samples/dotnet-secure-api/
```
2. Restaure os pacotes:
```bash
dotnet restore
```
3. Execute a API:
```bash
dotnet run
```
4. Acesse o Swagger UI:
```bash
https://localhost:5001/swagger
```
🔑 Autenticação JWT

    A API exige um Bearer Token válido para acessar os endpoints protegidos.

    O Swagger já está configurado para permitir testes com JWT.

Exemplo de uso:

    Faça login (caso haja endpoint /login) e receba um token.

    No Swagger, clique em "Authorize" e cole o token:

Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6...

    Os endpoints marcados com 🔒 poderão ser usados após isso.

🧪 Endpoints principais
Método	Rota	            Protegido	Descrição
POST	/login	            ❌	       Retorna token JWT válido
GET	    /GetWeatherForecast	✅          Endpoint protegido

    Detalhes completos disponíveis no Swagger.

📌 Notas de Segurança

    O token tem tempo de expiração configurado (expiração curta por padrão).

    A chave secreta está definida no appsettings.json, mas deve ser protegida (ex: Azure Key Vault ou secrets locais) em produção.

    Futura melhoria: refresh tokens e roles por claims.

📄 Licença
MIT. Livre para estudos e reutilização com crédito.

🙋‍♂️ Autor
Ina Lemos (Inajara)
Especialista em segurança de ambientes híbridos, com foco atual em automações, containers e identidade.