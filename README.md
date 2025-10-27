# Sistema de Gestión Académica - TP Final

Este proyecto es un sistema de gestión académica desarrollado como Trabajo Práctico Final. La aplicación permite administrar las entidades centrales de una institución educativa, como alumnos, docentes, planes de estudio, especialidades, materias y cursos.

La arquitectura del sistema está diseñada siguiendo los principios de **Clean Architecture**, con un fuerte enfoque en el Diseño Guiado por el Dominio (DDD), la separación de responsabilidades y la mantenibilidad a largo plazo.

El sistema se compone de dos partes principales:
1.  Una **API RESTful** robusta construida con ASP.NET Core que sirve como backend y única fuente de verdad.
2.  Una **Aplicación de Escritorio** desarrollada en Windows Forms que consume la API para la interacción con el usuario.

## 📋 Tabla de Contenidos
* [Características Principales](#-características-principales)
* [Diseño de la Arquitectura](#-diseño-de-la-arquitectura)
* [Pila Tecnológica](#-pila-tecnológica)
* [Cómo Empezar](#-cómo-empezar)
  * [Pre-requisitos](#pre-requisitos)
  * [Configuración de la Base de Datos](#configuración-de-la-base-de-datos)
  * [Ejecutar la Aplicación](#ejecutar-la-aplicación)
* [Documentación de la API](#-documentación-de-la-api)
* [Estructura del Proyecto](#-estructura-del-proyecto)
* [Autor](#-autor)

## ✨ Características Principales

- **Gestión de Entidades (CRUD):**
  - Administración completa de Personas, Usuarios (Alumnos, Docentes, Administradores), Especialidades, Planes, Materias, Comisiones y Cursos.
- **Lógica de Negocio Compleja:**
  - Inscripción de alumnos a cursos con validaciones (reinscripción, etc.).
  - Asignación de docentes a cursos.
  - Asociación de materias y comisiones a planes de estudio.
- **Baja Lógica (Soft Delete):**
  - Ningún dato se elimina físicamente. Las entidades se marcan como "borradas" y se excluyen automáticamente de todas las consultas, preservando la integridad histórica y permitiendo la auditoría.
- **Seguridad:**
  - Autenticación de usuarios por legajo.
  - Hashing de contraseñas utilizando BCrypt.
- **Herencia y Polimorfismo:**
  - Modelo de `Usuario` con herencia (Tabla Por Jerarquía - TPH) para representar `Alumnos`, `Docentes` y `Administradores` en una única tabla, gestionado por Entity Framework Core.
- **API RESTful Documentada:**
  - Endpoints claros y consistentes para todas las operaciones.
  - Documentación interactiva generada con Swagger / OpenAPI.

## 🏗️ Diseño de la Arquitectura

El proyecto está estructurado siguiendo los principios de **Clean Architecture** para garantizar un bajo acoplamiento, alta cohesión y una excelente testeabilidad.

### 🔹 Domain
El núcleo de la aplicación. No depende de ninguna otra capa.
- **Entidades:** Clases POCO que representan los objetos de negocio (ej. `Plan`, `Usuario`, `Materia`). Contienen la lógica y las reglas de negocio más importantes, con estado protegido (setters privados).
- **Interfaces de Repositorio:** Contratos que definen las operaciones de persistencia (ej. `IPlanRepository`), permitiendo que la capa de aplicación sea agnóstica a la base de datos.
- **Enums y Excepciones de Dominio.**

### 🔹 Application
Contiene la lógica de los casos de uso de la aplicación. Orquesta el flujo de datos entre el dominio y la presentación.
- **Servicios de Aplicación:** (ej. `PlanService`) Clases que implementan los casos de uso. Coordinan los repositorios y las entidades para ejecutar las operaciones.
- **DTOs (Data Transfer Objects):** Modelos de datos específicos para cada operación (ej. `PlanDTO`, `CrearPlanDTO`) para asegurar que solo la información necesaria se transfiere entre capas.
- **Interfaces de Servicios.**
- **Mapeo (AutoMapper):** Perfiles de configuración para mapear eficientemente entre Entidades y DTOs.
- **Excepciones Personalizadas:** (ej. `BusinessRuleException`) para un manejo de errores claro.

### 🔹 Infrastructure
Contiene las implementaciones concretas de las interfaces definidas en la capa de aplicación y dominio. Es el lugar de los detalles técnicos.
- **Persistencia (Entity Framework Core):**
  - `DbContext`: Configuración de las entidades, relaciones y el **Filtro de Consulta Global** para el borrado lógico.
  - `Repositorios`: Implementaciones concretas de las interfaces de repositorio que interactúan con la base de datos MySQL.
  - `Migrations`: Historial de cambios del esquema de la base de datos.
- **Servicios Externos:** (Si los hubiera, como envío de emails, etc.).

### 🔹 Presentation
La cara visible de la aplicación. Contiene la UI y la API.
- **WebApi:** Proyecto ASP.NET Core que expone los endpoints RESTful.
  - `Controllers`: Reciben las peticiones HTTP, las validan y delegan el trabajo a los servicios de aplicación.
- **WinFormsApp:** Proyecto de escritorio que actúa como cliente.
  - `API Clients`: Clases que utilizan `HttpClientFactory` para comunicarse de forma segura y eficiente con la WebApi.
  - `Formularios`: Vistas que presentan los datos al usuario y capturan sus interacciones.

## 🚀 Pila Tecnológica

- **Backend:** .NET 8, ASP.NET Core, Entity Framework Core 8
- **Base de Datos:** MySQL
- **Librerías Principales:**
  - **AutoMapper:** Para el mapeo de objetos.
  - **BCrypt.NET:** Para el hashing de contraseñas.
  - **Swashbuckle:** Para la generación de documentación de la API con Swagger.
  - **Pomelo.EntityFrameworkCore.MySql:** Proveedor de EF Core para MySQL.
- **Frontend:** Windows Forms (.NET)

## 🏁 Cómo Empezar

Sigue estos pasos para configurar y ejecutar el proyecto en tu entorno local.

### Pre-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) o un editor de tu elección.
- Un servidor de base de datos MySQL (ej. a través de XAMPP, WAMP, o Docker).

### Configuración de la Base de Datos
1.  **Crea una base de datos vacía** en tu servidor MySQL (ej. `tp_final_academia`).
2.  **Configura la cadena de conexión:**
    -   Abre el archivo `appsettings.json` en el proyecto `WebApi`.
    -   Modifica la sección `ConnectionStrings` con los datos de tu servidor MySQL:
        ```json
        "ConnectionStrings": {
          "MySqlConnection": "server=localhost;port=3306;database=tp_final_academia;user=tu_usuario;password=tu_contraseña"
        }
        ```
3.  **Aplica las migraciones:**
    -   Abre la **Consola del Administrador de Paquetes** en Visual Studio.
    -   Asegúrate de que el "Proyecto predeterminado" sea `Infrastructure`.
    -   Ejecuta el siguiente comando para crear todas las tablas en tu base de datos:
        ```powershell
        Update-Database
        ```

### Ejecutar la Aplicación
El sistema tiene dos proyectos de inicio: la API y el cliente de escritorio. Deben ejecutarse en el orden correcto.

1.  **Ejecutar la API:**
    -   En Visual Studio, haz clic derecho en el proyecto `WebApi` y selecciona "Establecer como proyecto de inicio".
    -   Presiona `F5` o el botón de play. Se abrirá una ventana del navegador con la interfaz de Swagger. ¡Deja esta aplicación corriendo!
2.  **Ejecutar el Cliente de Escritorio:**
    -   Con la API ya en ejecución, haz clic derecho en el proyecto de Windows Forms y selecciona "Establecer como proyecto de inicio".
    -   Presiona `F5` o el botón de play. La aplicación de escritorio se iniciará y podrá comunicarse con la API.

## 📖 Documentación de la API

Una vez que la `WebApi` está en ejecución, puedes acceder a la documentación interactiva completa de la API a través de Swagger.

Navega a la siguiente URL en tu navegador:
**`http://localhost:[TU_PUERTO]/swagger`**

Desde aquí, podrás ver todos los endpoints disponibles, sus parámetros, y probarlos directamente.

## 📂 Estructura del Proyecto

```
/tp-final-academia
│
+---.github
ª   +---workflows
+---Application
ª   +---bin
ª   ª   +---Debug
ª   ª       +---net8.0
ª   +---DTOs
ª   +---Exceptions
ª   +---Interfaces
ª   ª   +---ApiClients
ª   ª   +---Repositories
ª   ª   +---Services
ª   +---Mappings
ª   +---obj
ª   ª   +---Debug
ª   ª       +---net8.0
ª   ª           +---ref
ª   ª           +---refint
ª   +---Services
+---Domain
ª   +---bin
ª   ª   +---Debug
ª   ª       +---net8.0
ª   +---Entities
ª   +---Interfaces
ª   +---obj
ª       +---Debug
ª           +---net8.0
ª               +---ref
ª               +---refint
+---FrontWeb
ª   +---Auth
ª   +---bin
ª   ª   +---Debug
ª   ª       +---net8.0
ª   ª           +---wwwroot
ª   ª               +---_framework
ª   +---Features
ª   ª   +---Login
ª   ª   ª   +---Pages
ª   ª   +---Pages
ª   +---obj
ª   ª   +---Debug
ª   ª       +---net8.0
ª   ª           +---compressed
ª   ª           +---ref
ª   ª           +---refint
ª   ª           +---scopedcss
ª   ª           ª   +---bundle
ª   ª           ª   +---Layout
ª   ª           ª   +---projectbundle
ª   ª           +---service-worker
ª   ª           +---staticwebassets
ª   ª           +---tmp-webcil
ª   ª           +---webcil
ª   +---Properties
ª   +---Shared
ª   ª   +---Layout
ª   +---wwwroot
ª       +---css
ª           +---bootstrap
+---Infrastructure
ª   +---ApiClient
ª   +---bin
ª   ª   +---Debug
ª   ª       +---net8.0
ª   +---Context
ª   +---M-SqlServer
ª   +---Migrations
ª   +---obj
ª   ª   +---Debug
ª   ª       +---net8.0
ª   ª           +---ref
ª   ª           +---refint
ª   +---Persistance
ª   +---Repositories
+---WebApi
ª   +---bin
ª   ª   +---Debug
ª   ª       +---net8.0
ª   ª           +---cs
ª   ª           +---de
ª   ª           +---es
ª   ª           +---fr
ª   ª           +---it
ª   ª           +---ja
ª   ª           +---ko
ª   ª           +---pl
ª   ª           +---pt-BR
ª   ª           +---ru
ª   ª           +---runtimes
ª   ª           ª   +---browser
ª   ª           ª   ª   +---lib
ª   ª           ª   ª       +---net8.0
ª   ª           ª   +---unix
ª   ª           ª   ª   +---lib
ª   ª           ª   ª       +---net6.0
ª   ª           ª   ª       +---net8.0
ª   ª           ª   +---win
ª   ª           ª   ª   +---lib
ª   ª           ª   ª       +---net6.0
ª   ª           ª   ª       +---net8.0
ª   ª           ª   +---win-arm
ª   ª           ª   ª   +---native
ª   ª           ª   +---win-arm64
ª   ª           ª   ª   +---native
ª   ª           ª   +---win-x64
ª   ª           ª   ª   +---native
ª   ª           ª   +---win-x86
ª   ª           ª       +---native
ª   ª           +---tr
ª   ª           +---zh-Hans
ª   ª           +---zh-Hant
ª   +---Controllers
ª   +---Middleware
ª   +---obj
ª   ª   +---Debug
ª   ª       +---net8.0
ª   ª           +---EndpointInfo
ª   ª           +---ref
ª   ª           +---refint
ª   ª           +---staticwebassets
ª   +---Properties
+---WindowsForms
    +---bin
    ª   +---Debug
    ª       +---net8.0-windows
    ª           +---runtimes
    ª               +---browser
    ª               ª   +---lib
    ª               ª       +---net8.0
    ª               +---unix
    ª               ª   +---lib
    ª               ª       +---net6.0
    ª               ª       +---net8.0
    ª               +---win
    ª               ª   +---lib
    ª               ª       +---net6.0
    ª               ª       +---net8.0
    ª               +---win-arm
    ª               ª   +---native
    ª               +---win-arm64
    ª               ª   +---native
    ª               +---win-x64
    ª               ª   +---native
    ª               +---win-x86
    ª                   +---native
    +---HttpHandlers
    +---obj
    ª   +---Debug
    ª       +---net8.0-windows
    ª           +---ref
    ª           +---refint
    +---Properties
    +---Resources
    +---Vistas
        +---Admin
        ª   +---Comision
        ª   +---Curso
        ª   +---DocenteCurso
        ª   +---Especialidad
        ª   +---Materia
        ª   +---Persona
        ª   +---Plan
        ª   +---Usuario
        +---Alumno
        +---Docente
        +---Reportes

```

## ✒️ Autor

- **Gugliermino Carlos, Franco Zariaga** - *Desarrollo del proyecto* - [carlex74] - [franquito3]
