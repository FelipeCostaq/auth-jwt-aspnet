# Car Parking API
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
   git clone https://github.com/usuario/car-parking-api.git
   cd car-parking-api

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
`https://localhost:7148/swagger`


# Endpoints

## Car

- **GET** `/api/Car/all` – Lista todos os carros.
- **GET** `/api/Car/{id}` – Retorna um carro pelo ID.
- **GET** `/api/Car/plate` – Retorna um carro pela placa.
- **GET** `/api/Car/model` – Retorna um carro pelo modelo.
- **GET** `/api/Car/owner` – Retorna um carro pelo proprietário.
- **GET** `/api/Car/apartment` – Retorna um carro pelo apartamento.
- **POST** `/api/Car` – Adiciona um carro.
- **PUT** `/api/Car/{id}` – Atualiza um carro.
- **DELETE** `/api/Car/{id}` – Remove um carro.

## ParkingSpot

- **GET** `/api/ParkingSpot/all` – Lista todas as vagas.
- **GET** `/api/ParkingSpot/number` – Retorna uma vaga pelo número.
- **GET** `/api/ParkingSpot/type` – Retorna uma vaga pelo tipo.
- **GET** `/api/ParkingSpot/status` – Retorna uma vaga pelo status.
- **GET** `/api/ParkingSpot/{id}` – Retorna uma vaga pelo ID.
- **POST** `/api/ParkingSpot` – Adiciona uma vaga.
- **PUT** `/api/ParkingSpot/{id}` – Atualiza uma vaga.
- **DELETE** `/api/ParkingSpot/{id}` – Remove uma vaga.

## ParkingAssignment

- **GET** `/api/ParkingAssignment/all` – Lista todas as atribuições.
- **GET** `/api/ParkingAssignment/spotId` – Retorna uma atribuição pelo ID da vaga.
- **GET** `/api/ParkingAssignment/carId` – Retorna uma atribuição pelo ID do carro.
- **GET** `/api/ParkingAssignment/{id}` – Retorna uma atribuição pelo ID.
- **POST** `/api/ParkingAssignment` – Adiciona uma atribuição.
- **PUT** `/api/ParkingAssignment/{id}` – Atualiza uma atribuição.
- **DELETE** `/api/ParkingAssignment/{id}` – Remove uma atribuição.

