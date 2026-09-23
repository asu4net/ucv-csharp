# Crear un proyecto de C#

## Abrir la terminal:

Abre la `búsqueda de Windows` y escribe `cmd`. Después, pulsa `Enter`. Esto debería abrir una terminal negra.

## Comprobar si .NET está instalado:

- En la terminal, escribe `dotnet --version`. Esto debería mostrar el número de versión si .NET está instalado.
- Si **NO** está instalado, ejecuta `winget install Microsoft.DotNet.SDK.10`
- Cierra la terminal y vuelve a abrirla.
- Repite `dotnet --version` para comprobar que se ha instalado correctamente.

## Nos preparamos para crear el proyecto:

- Creamos una carpeta para guardar nuestro proyectos, donde sea.
- Una vez creada, entramos en ella.
- En el explorador de Windows hacemos un click en la barra de arriba.
- Escribimos `cmd` y después pulsamos `Enter`.
- Esto debería de abrir un terminal en la carpeta actual.

## Crear el proyecto:

> Sobre el formato de nombres de proyecto, archivos y clases:
     **Nunca** llamamos a un archivo `buenas tardes.cs` o a una clase `class eljugador`.
     **Siempre** `BuenasTardes.cs` o `class ElJugador`. 
     Este formato recibe el nombre de *UpperCamelCase* (por si os da curiosidad). 

- Escribimos `dotnet new console -n NombreDelProyecto`.
- Se nos creará una carpeta con ese nombre que contendrá dos archivos.
- *Program.cs*: Los archivos de extensión `.cs` son archivos de código de C#.
- *NombreDelProyecto.csproj*: Este es el archivo de proyecto de C#. No se toca. 
