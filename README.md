# README: Clients API

Este repositório contém o projeto **Clients API**, desenvolvido em **.NET 8** seguindo os princípios de **Clean Architecture**, **DDD (Domain-Driven Design)**, e utilizando **Unit of Work**, **IoC (Inversão de Controle)** e **Docker** para facilitar o ambiente de execução.

---

## 🧠 Tecnologias e Arquitetura Utilizadas

- **.NET 8**
- **PostgreSQL**
- **Docker & Docker Compose**
- **DDD (Domain-Driven Design)**
- **Clean Architecture**
- **Unit of Work**
- **Inversão de Controle (IoC)**
- **Entity Framework Core**

---

## 📁 Estrutura do Projeto

O projeto está organizado da seguinte forma:

```
Clients/
│
├── api             # Camada de apresentação (Controllers, Program.cs, Middlewares)
├── application     # Casos de uso e interfaces da aplicação
├── domain          # Entidades e regras de negócio
├── infra.data      # Repositórios, UnitOfWork, Migrations
├── infra.ioc       # Injeção de dependências (IoC)
├── tests           # Testes unitários com xUnit
├── Dockerfile      # Dockerfile da API
├── docker-compose.yml  # Orquestração dos containers da API e do PostgreSQL
```

---

## ✅ Pré-requisitos

- Docker
- Docker Compose

---

## 🚀 Como Executar com Docker Compose

1. **Clone o repositório:**

```bash
git clone https://github.com/VORP2830/TClient-API
cd clients-api
```

2. **Execute o Docker Compose:**

```bash
docker-compose up -d --build
```

> Esse comando irá subir:
> - O **PostgreSQL** na porta `5432`
> - A **Clients API** exposta na **porta 80**

---

## 🌐 Acessando a Aplicação

Após a execução, a API estará disponível em:

```
http://localhost/swagger/index.html
```

> A API está mapeada para a **porta 80**, portanto você não precisa informar a porta na URL.

---

## 🧪 Executando os Testes

Para rodar os testes unitários localmente (fora do Docker), use:

```bash
dotnet test
```

---

## 📝 Observações

- As configurações de banco de dados são injetadas via variáveis de ambiente no `docker-compose.yml`.
- As migrations são aplicadas automaticamente na inicialização do container.
- Certifique-se de que a **porta 80** não esteja sendo usada por outro serviço localmente (como IIS ou Apache).