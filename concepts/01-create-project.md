# Crear un proyecto de C#

.NET o `dotnet`, para crear proyectos de C#, es un software que puede utilizarse desde
la terminal de Windows. La terminal es simplemente una forma de usar el sistema operativo
sin interfaz gráfica. Podemos hacer las mismas tareas que normalmente hacemos moviendo el ratón 
y haciendo click en elementos de GUI, la diferencia clave es que en la terminal las hacemos escribiendo
comandos.

## Abrir la terminal:

Abre la `búsqueda de Windows` y escribe `cmd`. Después, pulsa `Enter`. Esto debería abrir una terminal negra.

## Comprobar si el SDK de .NET está instalado:

> Nota: SDK significa Software Development Kit, o kit de desarrollo.
  la versión de `dotnet` que necesitamos para poder crear y programar
  proyectos de C# es la del SDK.

- En la terminal, escribe `dotnet new`. Si el SDK de .NET no está instalado, no reconocerá el comando.
- En caso de que sí has terminado, ve al siguiente apartado :)
- Si **NO** está instalado, ejecuta `winget install Microsoft.DotNet.SDK.10`
- Cierra la terminal y vuelve a abrirla.
- De nuevo comprueba si `dotnet new` se reconoce como comando.
- En caso de que sí has terminado, ve al siguiente apartado :)
- En caso de que no quizás es porque se está usando la versión sin SDK.
- Para solucionar esto abre `búsqueda de Windows` y escribe `variables de entorno`.
- Una vez ahí ve a `variables de sistema` y dentro verás que hay dos de `dotnet`.
    - Una de ellas es la instalación del `dotnet` con SDK y otra sin. 
- Usando los botones de `mover arriba` intercambia sus posiciones.
- Cierra **TODAS** las ventanas de terminal y abre una nueva.
- Esta vez el comando `dotnet new` debería de funcionar definitivamente.

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

## Compilar el proyecto.

- Escribimos `dotnet run --project RutaALaCarpetaDelProyecto`.
    - Si ya estamos dentro de la carpeta con `dotnet run` es suficiente.
- Esto debería de mostrar un *print*: `Hello World!`.
- Además si miramos la estructura del proyecto se ha creado una carpeta llamada *bin* y otra *obj*.
- Si navegamos por las subcarpetas dentro de *bin* encontraréis el `.exe` que se ha generado al compilar.
- Este `.exe` es un programa ultra sencillo que lo único que hace es el *print* de `Hello World`.
- El motivo por el que se hace el *print* es porque és el código de ejemplo que traen los nuevos proyectos de .NET.
- Podéis inspeccionarlo en el archivo `Program.cs`.
