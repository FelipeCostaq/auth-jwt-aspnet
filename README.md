# Financial Goals API
API para gerenciamento de metas financeiras, podendo gerenciar metas a serem batidas e metas atingidas. Desenvolvida em C# com ASP.NET Core, Entity Framework e JWT.

## Tecnologias Utilizadas
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT
- Swagger (OpenAPI)

### Pré-requisitos
- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/)
- [Git](https://git-scm.com/)

### Passos para rodar localmente
1. Clone o repositório:
   ```bash
   git clone https://github.com/FelipeCostaq/financial-goals-api.git
   cd financial-goals-api

2. Restaure as depêndencias.
   ```bash
   dotnet restore

3. Crie o banco de dados e rode as migrations.
   ```bash
   dotnet ef database update

4. Execute a aplicação
   ```bash
   dotnet run

5. Acesse a documentação completa pelo Swagger em:  
`https://localhost:7215/swagger`


# Endpoints

## Auth
<h3>🔑 - Esta api utiliza autenticação!</h3>

- **POST** `/api/Auth/register` – Registra um usuário.
- **POST** `/api/Auth/login` – Faz login em um usuário e retorna um token para utilização dos outros endpoints.
  
<p>
   
A API utiliza JWT.
Após fazer login, use o token recebido para se autenticar no Swagger:
Bearer <seu_token>

</p>

- **GET** `/api/Auth/me` – Retorna os dados do usuário logado.

## CompletedGoal

- **GET** `/api/CompletedGoal` – Lista todas as metas financeiras atingidas.
- **GET** `/api/CompletedGoal/{title}` – Lista todas as metas financeiras atingidas buscando pelo title.
- **DELETE** `/api/CompletedGoal/{id}` – Remove uma meta financeira atingida.

## FinancialGoal

- **POST** `/api/FinancialGoal` – Adiciona uma meta financeira.
- **GET** `/api/FinancialGoal` – Lista todas as metas finaceiras.
- **GET** `/api/FinancialGoal/{title}` – Lista todas as metas financeiras buscando pelo title.
- **PUT** `/api/FinancialGoal/{id}` – Editar uma meta financeira.
- **PUT** `/api/FinancialGoal/{id}/add-funds` – Adicionar valor a uma meta financeira.
- **DELETE** `/api/FinancialGoal/{id}` – Remove uma meta financeira.

