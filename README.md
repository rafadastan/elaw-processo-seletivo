# 📦 elaw-processo-seletivo

Este projeto foi desenvolvido como parte de um processo seletivo para a empresa Elaw. A proposta consistia na construção de uma API RESTful em ASP.NET Core utilizando boas práticas de DDD, Entity Framework Core e padrões de desenvolvimento como Repository, Service e AutoMapper.

## 🛠️ Tecnologias Utilizadas

- .NET Core 8
- Entity Framework Core (InMemory para testes)
- AutoMapper
- FluentValidation
- Swagger (Swashbuckle)
- RESTful APIs
- Clean Architecture / DDD
- C#

---

## ✅ Funcionalidades Implementadas

- [x] Cadastro de clientes (Customer)
- [x] Atualização de clientes
- [x] CRUD completo com Address associado ao Customer
- [x] Validação de entidades
- [x] AutoMapper configurado para DTO <-> Entidades
- [x] Padrões de projeto: Repository, Domain Service, Application Service
- [x] API documentada com Swagger

---

## ⚙️ Organização em Camadas

elaw.API/
├── elaw.API (Controllers)
├── elaw.Application (Services / DTOs / Mappers)
├── elaw.Domain (Entities / Services / Interfaces)
├── elaw.Infra (Repository / EF Context)
└── elaw.Tests (Casos de teste unitário) [Não houve]
