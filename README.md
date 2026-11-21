# Sistema de Registro de Películas

## 1. Información general

**Nombre del proyecto:** Sistema de Registro de Películas

**Estudiante:** Enrique Gonzalez Torres

**Asignatura:** Profundización en .NET

**Descripción:**

Este proyecto consiste en el desarrollo de una aplicación de escritorio para registrar y administrar información de películas. El sistema permite guardar, consultar, modificar y eliminar películas mediante una interfaz gráfica sencilla.

La información se almacena en una base de datos SQLite, utilizando ADO.NET para realizar las operaciones de consulta y manipulación de los registros.

**Necesidad que resuelve:**

Permite llevar un control organizado de películas, evitando tener que registrar y consultar la información manualmente.

**Objetivo:**

Desarrollar una aplicación de escritorio que integre programación orientada a objetos, interfaces gráficas con Avalonia y persistencia de información mediante SQLite.

---

## 2. Funcionalidades del sistema

La aplicación cuenta con las siguientes funcionalidades:

- **Registrar películas:** permite ingresar el título, género y año de estreno.
- **Consultar películas:** muestra las películas almacenadas en la base de datos.
- **Modificar películas:** permite seleccionar un registro y actualizar su información.
- **Eliminar películas:** elimina una película seleccionada.
- **Validar información:** verifica que los campos obligatorios estén completos y que el año sea válido.
- **Mostrar mensajes:** informa al usuario cuando una operación se realiza correctamente o cuando existe algún error.
- **Persistencia de datos:** conserva los registros almacenados en SQLite al cerrar y volver a ejecutar el programa.

## 3. Tecnologías utilizadas

| Tecnología | Versión | Utilidad |
|---|---|---|
| C# | .NET 8 | Lenguaje de programación |
| .NET SDK | 8.0 | Entorno de desarrollo |
| Avalonia UI | 11.3.0 | Interfaz gráfica |
| Microsoft.Data.Sqlite | 8.0.0 | Conexión con SQLite |
| SQLite | - | Base de datos |
| ADO.NET | - | Acceso y manipulación de datos |
| Visual Studio Code | - | Editor de código |

## 4. Estructura del proyecto

La organización de los archivos se realizó separando las responsabilidades de cada parte del sistema.

```text
RegistroPeliculasEscritorio/
│
├── Models/
│   └── Pelicula.cs
│
├── Data/
│   ├── ConexionBD.cs
│   └── PeliculaDAO.cs
│
├── Services/
│   └── PeliculaServicio.cs
│
├── Program.cs
├── App.axaml
├── App.axaml.cs
├── MainWindow.axaml
├── MainWindow.axaml.cs
├── RegistroPeliculasEscritorio.csproj
├── README.md
│
└── evidencias/
```

### Descripción de las clases

**Pelicula.cs (Models)**

Representa la entidad principal del sistema. Contiene las propiedades Id, Titulo, Genero y Anio, además de sus constructores y el método ToString().

**ConexionBD.cs (Data)**

Se encarga de establecer la conexión con SQLite y crear la tabla Peliculas cuando no existe.

**PeliculaDAO.cs (Data)**

Contiene las consultas SQL necesarias para registrar, consultar, modificar y eliminar películas. Utiliza parámetros para enviar los datos de forma segura.

**PeliculaServicio.cs (Services)**

Contiene las validaciones de los datos y comunica la interfaz con la clase de acceso a datos.

**MainWindow.axaml**

Define los elementos visuales de la aplicación, como los campos de texto, botones, mensajes y listado de películas.

**MainWindow.axaml.cs**

Controla los eventos de los botones y conecta la interfaz gráfica con la lógica del sistema.

**Program.cs**

Contiene el punto de entrada de la aplicación y configura el inicio de Avalonia.

## 5. Conceptos de programación orientada a objetos

Durante el desarrollo se aplicaron los siguientes conceptos:

- **Clases y objetos:** se creó la clase Pelicula para representar cada registro.
- **Encapsulamiento:** se utilizaron propiedades con métodos get y set para acceder y modificar los atributos.
- **Constructores:** permiten inicializar los objetos con sus respectivos datos.
- **Separación de responsabilidades:** se dividió el programa en modelo, acceso a datos, servicios e interfaz gráfica.

## 6. Base de datos

El proyecto utiliza SQLite para almacenar la información de las películas.

La base de datos se llama `peliculas.db` y la tabla principal se denomina `Peliculas`.

### Estructura de la tabla

| Campo | Tipo | Descripción |
|---|---|---|
| Id | INTEGER | Identificador único |
| Titulo | TEXT | Nombre de la película |
| Genero | TEXT | Género cinematográfico |
| Anio | INTEGER | Año de estreno |

La tabla se crea automáticamente cuando se inicia la aplicación, si todavía no existe.

### Conexión y operaciones

Se utiliza el paquete Microsoft.Data.Sqlite para establecer la conexión.

Las operaciones SQL implementadas son:

- INSERT: registrar películas.
- SELECT: consultar películas.
- UPDATE: modificar películas.
- DELETE: eliminar películas.

Las consultas utilizan parámetros para evitar concatenar directamente los datos ingresados por el usuario.

## 7. Instalación y ejecución

### Requisitos previos

Para ejecutar el proyecto se necesita:

- Windows.
- .NET SDK 8.0.
- Visual Studio Code.
- Extensión de C# para Visual Studio Code.

### Clonar el repositorio

Desde una terminal, ejecutar:

```bash
git clone URL_DEL_REPOSITORIO
```

Ingresar a la carpeta del proyecto:

```bash
cd RegistroPeliculasEscritorio
```

### Restaurar dependencias

```bash
dotnet restore
```

### Compilar el proyecto

```bash
dotnet build
```

### Ejecutar la aplicación

```bash
dotnet run
```

La aplicación abrirá la ventana principal del Sistema de Registro de Películas.

## 8. Pruebas funcionales

Durante las pruebas del sistema se verificaron las siguientes operaciones:

| Prueba | Resultado esperado |
|---|---|
| Registrar una película | Guardar el registro en SQLite |
| Consultar películas | Mostrar los registros almacenados |
| Modificar una película | Actualizar los datos seleccionados |
| Eliminar una película | Eliminar el registro seleccionado |
| Validar campos vacíos | Mostrar un mensaje de advertencia |
| Cerrar y abrir el programa | Mantener los registros guardados |

## 9. Evidencias del funcionamiento

Las capturas de pantalla de las pruebas se encuentran en la carpeta `evidencias/`.

Se incluyen las siguientes evidencias:

1. Interfaz principal del sistema.
2. Registro de una película.
3. Consulta de películas.
4. Modificación de un registro.
5. Eliminación de una película.
6. Validación de campos obligatorios.
7. Persistencia de información después de cerrar y abrir la aplicación.

## 10. Problemas encontrados y soluciones

**Problema 1: Compatibilidad con la versión de .NET**

Durante la creación del proyecto se presentó un error porque el proyecto estaba configurado para .NET 9, mientras que el equipo tenía instalado .NET 8.

**Solución:** se modificó la propiedad TargetFramework del archivo `.csproj` a `net8.0`.

**Problema 2: Error en el punto de entrada del programa**

Se presentó el error CS5001 porque no se encontraba el método Main.

**Solución:** se revisó y corrigió el archivo Program.cs para configurar correctamente el inicio de Avalonia.

**Problema 3: Archivo bloqueado durante la compilación**

Se presentó un error porque Windows estaba utilizando el archivo PDB del proyecto.

**Solución:** se cerró la aplicación, se detuvo el proceso de ejecución y se limpiaron los archivos temporales mediante `dotnet clean`.

## 11. Conclusión

El desarrollo de este proyecto permitió poner en práctica los conceptos de programación orientada a objetos y aplicarlos en una aplicación de escritorio.

También se trabajó con Avalonia para construir la interfaz gráfica y con SQLite y ADO.NET para almacenar y administrar la información.

El resultado es un sistema funcional que permite gestionar películas mediante operaciones CRUD y conservar los registros en una base de datos local.
