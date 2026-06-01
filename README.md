# SegurAppSuite

Sistema de gestión de seguros desarrollado como proyecto de referencia para la aplicación práctica de **Clean Architecture**, **Domain-Driven Design (DDD)** y **CQRS** en un contexto de negocio real.

> Proyecto personal en desarrollo activo. El objetivo no es solo funcionar — es demostrar cómo se estructura un sistema mantenible, desacoplado y listo para escalar.

---

## Contexto de negocio

El dominio modela los procesos centrales de una compañía de seguros:

- **Clientes** — gestión del asegurado y sus datos
- **Pólizas** — contratación, vigencia y condiciones de cobertura
- **Siniestros** — registro, seguimiento y resolución de reclamos

Cada concepto es un **Aggregate Root** con sus propias reglas de negocio, eventos de dominio y contratos de repositorio — sin lógica de negocio fuera de la capa de dominio.

---

## Arquitectura

```
SegurAppSuite/
├── SegurAppSuite.Domain/           # Núcleo del sistema — sin dependencias externas
│   ├── Entities/                   # Aggregates: Cliente, Poliza, Siniestro
│   ├── ValueObjects/               # Objetos de valor inmutables
│   ├── Events/                     # Domain Events
│   ├── Exceptions/                 # Excepciones de dominio tipadas
│   ├── Interfaces/                 # Contratos de repositorios e interfaces del dominio
│   └── Services/                   # Domain Services (ej: ServicioDeReclamos)
│
├── SegurAppSuite.Application/      # Casos de uso — orquesta el dominio
│   ├── Commands/                   # Write side (CQRS)
│   ├── Queries/                    # Read side (CQRS)
│   ├── Handlers/                   # MediatR handlers
│   ├── DTOs/                       # Contratos de entrada/salida
│   └── Behaviors/                  # Pipeline behaviors (validación, logging)
│
├── SegurAppSuite.Infrastructure/   # Implementaciones técnicas
│   ├── Persistence/
│   │   ├── SqlServer/              # EF Core — datos transaccionales
│   │   └── MongoDB/                # Repositorios de documentos / eventos
│   ├── Repositories/               # Implementación de interfaces del dominio
│   └── DependencyInjection/        # Registro de servicios
│
└── SegurAppSuite.Presentation/     # Entry point — ASP.NET Minimal API
    ├── Endpoints/                  # Endpoints organizados por dominio
    └── Middleware/                 # Manejo global de errores, autenticación
```

### Principios aplicados

- **Dependency Rule** — las dependencias apuntan siempre hacia adentro. Domain no conoce nada de Infrastructure ni de Application.
- **Aggregates con invariantes** — las entidades protegen su propio estado. No hay setters públicos sin intención.
- **CQRS con MediatR** — Commands y Queries completamente separados. Cada Handler tiene una única responsabilidad.
- **Domain Events** — los cambios de estado relevantes se publican como eventos, desacoplando efectos secundarios del núcleo del negocio.
- **Repositorios por contrato** — Infrastructure implementa interfaces definidas en Domain. La capa de aplicación nunca depende de EF Core ni de MongoDB directamente.

---

## Stack técnico

### Backend
![.NET](https://img.shields.io/badge/.NET_10-512BD4?style=flat&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
![ASP.NET Minimal API](https://img.shields.io/badge/ASP.NET_Minimal_API-512BD4?style=flat&logo=dotnet&logoColor=white)
![MediatR](https://img.shields.io/badge/MediatR-512BD4?style=flat&logo=dotnet&logoColor=white)
![FluentValidation](https://img.shields.io/badge/FluentValidation-512BD4?style=flat&logo=dotnet&logoColor=white)

### Arquitectura
![Clean Architecture](https://img.shields.io/badge/Clean_Architecture-6D28D9?style=flat)
![DDD](https://img.shields.io/badge/DDD-7C3AED?style=flat)
![CQRS](https://img.shields.io/badge/CQRS-8B5CF6?style=flat)

### Persistencia
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat&logo=microsoftsqlserver&logoColor=white)
![MongoDB](https://img.shields.io/badge/MongoDB-47A248?style=flat&logo=mongodb&logoColor=white)
![EF Core](https://img.shields.io/badge/Entity_Framework_Core-512BD4?style=flat&logo=dotnet&logoColor=white)
![Dapper](https://img.shields.io/badge/Dapper-1e1e2e?style=flat&logoColor=white)

---

## Decisiones de diseño destacadas

### Persistencia dual: SQL Server + MongoDB

La elección de dos motores de base de datos no es arbitraria — responde a la naturaleza distinta de cada parte del dominio:

| Contexto | Motor | Justificación |
|---|---|---|
| Clientes, Pólizas | SQL Server + EF Core | Datos relacionales, integridad referencial, consultas transaccionales |
| Siniestros, Domain Events | MongoDB | Estructura variable, trazabilidad de eventos, lecturas de alta frecuencia |

### Domain Services vs Application Services

`ServicioDeReclamos` vive en Domain porque encapsula reglas de negocio que involucran múltiples aggregates y no dependen de ninguna infraestructura. Los casos de uso que orquestan esas reglas viven en Application.

### Minimal API como Presentation layer

Se eligió Minimal API sobre Controllers para mantener el entry point lo más delgado posible. Los endpoints son funciones de enrutamiento — toda la lógica real está en los Handlers de Application.

---

## Estado del proyecto

| Capa | Estado |
|---|---|
| Domain | ✅ En desarrollo activo |
| Application | 🔄 En progreso |
| Infrastructure | ⏳ Pendiente |
| Presentation | ⏳ Pendiente |
| Tests | ⏳ Planificado |

---

## Roadmap

- [ ] Implementar Commands y Queries base con MediatR
- [ ] Pipeline behavior de validación con FluentValidation
- [ ] Repositorios SQL Server con EF Core (Clientes, Pólizas)
- [ ] Repositorios MongoDB (Siniestros, Domain Events)
- [ ] Endpoints Minimal API por bounded context
- [ ] Unit tests sobre el dominio
- [ ] Integration tests sobre Infrastructure
- [ ] Docker Compose para levantar el entorno completo

---

## Autor

**Jorge Aníbal Rodríguez**
Desarrollador Fullstack Senior · .NET & C# · Posadas, Argentina

[![LinkedIn](https://img.shields.io/badge/LinkedIn-rzjan-0A66C2?style=flat&logo=linkedin&logoColor=white)](https://linkedin.com/in/rzjan)
[![GitHub](https://img.shields.io/badge/GitHub-rzjan-181717?style=flat&logo=github&logoColor=white)](https://github.com/rzjan)
