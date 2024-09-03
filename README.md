
# Carlos - Noel : XyzBoutique

Este es un pequeño proyecto de backend, realizado con Visual Studio 2022 usando .net 8.0

Se ha usado EF migration.

## Para la conexión a la base de datos

Para la base de datos usamos MySql.

Para conectar la aplicación a la base de datos, asegúrate de configurar la cadena de conexión en el archivo `appsettings.json`. Aquí tienes un ejemplo de cómo debería verse la configuración:

*"ConnectionStrings": {
    "DefaultConnection": "Server={inserte servidor};Database={inserte base de datos};User={inserte usuario};Password={inserte contraseña};"
  }

* No olvides crear la base de datos correspondiente.

Aquí algunos comandos para poder generar las tablas de la base de datos:

* dotnet ef migrations add InitialCreate
* dotnet ef database update

#### Recuerda que para el entorno de producción lo mejor es configurar las variables dentro del pipeline.

