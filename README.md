# RecruitmentApp

Aplicación web para la gestión de candidatos y sus experiencias laborales. Desarrollada como prueba técnica enfocada en la implementación de buenas prácticas de desarrollo backend usando .NET.

---

## 🚀 Tecnologías utilizadas

- **.NET SDK 9.0** – Framework principal para desarrollo de la aplicación.
- **ASP.NET Core Razor Pages** – Para la interfaz web simple de CRUD.
- **Entity Framework Core (EF Core)** – ORM para persistencia de datos.
- **SQL In-Memory** – Base de datos temporal para pruebas locales sin instalación adicional.
- **C#** – Lenguaje de programación utilizado.
- **OOP / DDD / SOLID / Clean Code** – Principios y prácticas aplicadas.
- **CQRS** – Patrón utilizado para separar comandos y consultas.

---

## 🧠 Arquitectura

El proyecto se encuentra dividido en los siguientes módulos:

- **Domain**: Contiene las entidades y contratos que representan el dominio de negocio.
- **Application**: Lógica de aplicación (casos de uso, validaciones, servicios).
- **Infrastructure**: Implementaciones técnicas como acceso a datos con Entity Framework.
- **Controllers**: Capas expuestas por la API para manejar las solicitudes HTTP.
- **Frontend**: Módulo Razor Pages que proporciona una interfaz sencilla para gestionar candidatos.

---

## 🧰 Tecnologías utilizadas

- [.NET Core 9.0 SDK](https://dotnet.microsoft.com/en-us/)
- ASP.NET Core Razor Pages
- Entity Framework Core (Code-First)
- SQL In-Memory Provider (para pruebas sin base de datos real)
- C#
- HTML + Razor Pages
- Clean Architecture
- DDD, SOLID, CQRS
- Git + GitHub

---

## ⚙️ Requisitos

- .NET 9 SDK instalado
- Visual Studio 2022+ o VS Code
- Git instalado
- Navegador moderno

---

## 🚀 Cómo ejecutar el proyecto

1. Clona el repositorio:

   ```bash
   git clone https://github.com/danielvargass97/RecruitmentApp.git
   cd RecruitmentApp
   
2. Abre la solución en Visual Studio o Visual Studio Code.
3. Restaura los paquetes y ejecuta el proyecto:
   ```bash
   dotnet restore
   dotnet run
4. Accede desde tu navegador a https://localhost:5276/Candidates

---

## 🧪 Testing y validaciones
La validación de datos se realiza con data annotations y validaciones del lado del servidor.

Se puede probar con candidatos con múltiples experiencias laborales.

Al guardar un candidato con correo ya registrado, se retorna error 400 Bad Request.

---

## 📁 Posibles mejoras futuras
Dividir la solución en múltiples proyectos (Domain, Application, Infrastructure, Web).

Implementar pruebas unitarias y de integración.

Persistencia real con SQL Server, PostgreSQL u otro.

Autenticación y autorización.

Migrar a una API RESTful con frontend independiente (React, Angular, etc.).

---

## 💡 Notas
El backend está completamente funcional y aislado para poder adaptarse a otros tipos de frontend fácilmente.

Se puede reemplazar el proveedor In-Memory por SQL Express con mínima configuración.

---

## 🧑‍💻 Autor

Daniel Vargas

Backend Developer - .NET, Java

Contacto: [daniel_vrgs@hotmail.com]
