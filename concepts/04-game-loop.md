# Game Loop

En esta lección vamos a aprender, de una forma extremadamente simplificada,
cómo esta programado un motor de videojuegos. O mejor dicho, cómo empezar
a desarrollar un videojuego **casi** desde cero. Esto nos dará una mayor
comprensión de cómo funciona Unity. ¿Por qué tenemos *GameObject* y 
*Components*? ¿Qué sucede cuando creamos un objeto desde el editor de 
Unity?

Para practicar las classes vamos a crear un nuevo proyecto, puedes
llamarlo 04-Game-Loop. Luego entra a `Program.cs` y ve escribiendo lo
que vas aprendiendo. 

Siempre que escribas algo llama a `dotnet run` para
compilar y ejecutar tu proyecto. 

## Pintar un frame (APIs gráficas)

Los videojuegos son un software que generar frames dinámicamente, dependiendo
de una serie de datos, entre ellos el input del jugador. Lo primero que vamos
a aprender son unos fundamentos muy básicos de cómo llevar esto a cabo.

Para pintar estos frames los juegos modernos utilizan algo llamado APIs gráficas.

Estas APIs son software, que viene en los drivers de la tarjeta gráfica, código
que **simplifica enormemente** tareas como convertir los vértices de un modelo 3D
en píxeles en la pantalla. Este proceso se conoce como *rasterización*.

Dependiendo de la plataforma en la que tiene que funcionar nuestro juego y del 
nivel de control que queramos sobre la tarjeta gráfica podemos utilizar una API
gráfica u otra:

Estas son las APIs gráficas más utilizadas:

- ***DirectX11***
    - Plataforma/s: Windows.
    - Dificultad: Normal.
    - Control: Medio.

- ***DirectX12***
    - Plataforma/s: Windows.
    - Dificultad: Difícil.
    - Control: Alto.

- ***OpenGL***
    - Plataforma/s: Todas excepto MacOS. (Versiones antiguas siguen funcionando en MacOS)
    - Dificultad: Sencillo.
    - Control: Bajo.

- ***Vulkan***
    - Plataforma/s: Todas excepto MacOS.
    - Dificultad: Difícil.
    - Control: Alto.

- ***Metal***
    - Plataforma/s: MacOS.
    - Dificultad: Normal.
    - Control: Medio-Alto.

A día de hoy, motores como Unity, Unreal y Godot, o juegos AAA modernos que usan motor propio,
utilizan (por debajo) las APIs que más control sobre la tarjeta gráfica dan: DirectX12, Vulkan 
y Metal, siendo usadas en Windows, Linux/Android y MacOS, respectivamente.

También hay APIs gráficas específicas para cada consola.

> Nota: Aunque estas APIs de consola existan, las consolas modernas suelen
  tener soporte para Vulkan. Esto, probablemente, es para evitar dar trabajo
  extra a los desarrolladores si no disponen de tiempo o recursos. Sin embargo,
  siempre es mejor, si hay posibilidad, de usar la API nativa de la plataforma.

## Por qué usaremos *Raylib*

Aunque alguna de estas APIs la hemos categorizado como dificultad "baja", como OpenGL,
la realidad es que, incluso la más sencilla, necesita horas de estudio y compresión de 
conceptos como la *graphics pipeline*.

Puesto que eso requerería toda una asignatura por separado vamos a utilizar una librería
llamada *Raylib*. Esta librería es un conjunto de código que *abstrae* y *simplifica* el
código de una API gráfica, concretamente OpenGL. Es decir: Nosotros escribiremos código
de Raylib, y Raylib por dentro *llamará* funciones de OpenGL.

Esto nos da la ventaja de tener una experiencia muy cercana a cómo se haría un videojuego,
o un motor de videojuegos **desde cero**, pero sin pasar por todas las horas que conllevaría
hacerlo interactuando directamente con OpenGL.

## ¿Cómo usar el código de Raylib?

Para usar el código de Raylib tenemos que añadirla como *package*
en nuestro proyecto. 

Un *package* es un conjunto de **código externo escrito por un tercero**, 
que añadimos en nuestro proyecto **para simplificar una tarea**. 

En este caso, el package Raylib, simplifica el uso de OpenGL, 
para pintar gráficos en pantalla.

Para **añadir un package**:

- Abrimos un terminal dentro de la carpeta del proyecto.
- Usamos el siguiente comando: `dotnet add package NombreDelPackage`

El nombre del package de Raylib es `Raylib-cs`.

> Nota: El `-cs` en el nombre es porque Raylib en realidad es una
  librería escrita en C puro, pero se ha porteado a infinidad de 
  lenguajes de programación. Por tanto `-cs` se refiere a la versión 
  específica de Raylib para C#.

Una vez añadido el package **podemos empezar a llamar funciones
de Raylib**.

Cabe destacar que Raylib **NO usa métodos** porque originariamente 
está escrita en el lenguaje C, el cual **NO es Orientado a Objetos**.

Recordemos que un método es una función que se llama sobre la
instancia de una clase. 

Ejemplo de método para refrescar la memoria:

```cs
Player player = new Player();
player.Attack(); // Llamamos al método attack sobre player.
```
Las funciones de Raylib son **globales**, o como C# las llama: **estáticas**. 
Este tipo de función no va ligada a ningún objeto o instancia. 

Ejemplo de llamada a una función estática:

```cs
Console.WriteLine("Buenas!");
```
> Nota: Recordemos que `Console` **NO es un objeto**, básicamente se usa como 
  prefijo, para facilitarnos saber a qué concepto va relacionada la función.
  (En este caso: la consola).

Las funciones de Raylib siempre usarán el prefijo de `Raylib.`. Esto es conveniente
ya que con un mero vistazo podemos intuir cuáles son las funciones de Raylib, es
decir, qué funciones pertenecen a **código externo** a nuestro programa.

> Nota: Esto **NO significa** que nuestro juego no usará objetos, solo que las
  funciones de Raylib no dependen de ellos.

## Abrir una ventana

De momento nuestros programas solo han interactuado con el usuario usando
las funciones de `Console.WriteLine` o `Console.ReadLine`, es decir, 
solo hemos estado haciendo **software de consola**.

Sin embargo, para pintar gráficos necesitamos **una ventana**. Por suerte Raylib
también nos simplifica esta tarea. Así que vamos a usar una de las funciones que
el package ofrece para crearla.  En el archivo principal de nuestro programa,
`Program.cs` escribiremos el siguiente código:

```cs
// Importamos las funciones de Raylib.
using Raylib_cs;

// Llamamos a una función de Raylib que crea una ventana.
Raylib.InitWindow(1280, 720, "Mi ventana"); // tamaño en x, tamaño en y, nombre.
```
Esto, como véis abre una ventana y luego la cierra immediatamente.
Es el comportamiento esperado, ya que después de `InitWindow` nuestro
programa termina. Para mantenerla abierta necesitamos algo **mantenga
indefinidamente** nuestro programa sin terminar:

```cs
// Usamos un bucle infinito para que no se cierre la ventana.
while (true) {}
```
Esto funciona, pero por mucho que intentamos cerrar la ventana no vamos
a poder. Vamos a llamar a más funciones de Raylib que nos permitan dejar
la ventana más usable:

```cs
while (Raylib.WindowShouldClose() == false)
{
    // Funciones mínimas que necesitan ser llamadas para que
    // Raylib funcione correctamente.
    Raylib.BeginDrawing();
    Raylib.EndDrawing();
}
```
En lugar de usar un bucle infinito, mantenemos el bucle iterando siempre 
y cuando Raylib quiera mantener la ventana abierta. Si Raylib detecta que 
hemos intentado cerrarla, la función `WindowShouldClose` retornará `true`.

## Empezamos a pintar
