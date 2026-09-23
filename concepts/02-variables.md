# Variables

Para practicar las variables vamos a crear un nuevo proyecto, puedes
llamarlo 01-Variables, si no tienes mucha imaginación.

## ¿Qué es una variable?

Las variables almacenan datos de tu programa en la memoria RAM.
Has de imaginarlas como `cajas` a las que pones un `nombre` para
saber lo que guardaste en ellas.

```cs
// Una variable que ALMACENA el nombre del jugador.
string playerName = "Pepe";
```

## Estructura de una variable

Las variables tienen:

### Tipo:

Describe el tipo de valor que almacenan:
- `int`: Almacena números enteros.
- `float`: Almacena números decimales.
- `char`: Almacena un caracter.
- `string`: Almacena una colección de caracteres.
- `NombreDeUnaClase`: Almacena un puntero/referencia a una instancia de la clase `NombreDeUnaClase`.

> Nota: Más adelante repasaremos que significa lo de las clases.

### Nombre:

Simplemente el nombre que le quieras poner. Porfavor siempre en formato *lowerCamelCase*.
El nombre se usará más adelante para *leer* o *escribir* el *valor* de la variable.

> Nota: Si no lo haces así un Reddit user te hablará con prepotencia preguntando si sabes programar.

### Valor (Opcional).

Opcionalmente puedes darle un valor a las variable en el momento de crearla.
Si no le das uno, tendrá uno por defecto dependiendo del tipo de variable:

- `int`: 0
- `float`: 0.0f
- `char`: '\0' (Significa caracter vacío)
- `string`: "\0" (Significa cadena de texto con 1 solo *char* vacío) 
- `NombreDeUnaClase`: null (Significa que el puntero no apunta a nada, es nulo).

```cs
// Una variable que ALMACENA el nombre del jugador sin valor.
string playerName;
```

## Diferencia entre crear, leer y escribir en una variable.

### Crear

Crear significa que reservamos espacio físico en la memoria
RAM para la variable. Básicamente CREAMOS la caja.

```cs
// Crear:
string playerName;

```

### Leer

Leer significa que vamos a usar su valor para algo, sin modificarlo.
Un ejemplo de uso del valor de esta variable es printearlo por la 
consola para verlo.

```cs
// Crear:
float playerLife = 100.0f;

// Ejemplo 1: Llamamos a la función de print de .NET.
Console.WriteLine(playerLife);

// Ejemplo 2: Le sumamos 20.0f.
playerLife + 20.0f;
```
Ambas son formas de leer (usar) el valor de la variable. NO la estamos modificando.

### Escribir

Escribir significa modificar el valor de la variable una vez
creada. Podemos hacerlo tantas veces como queramos de la siguiente manera:

```cs
// Crear:
int playerSkillPoints = 8;

// Ejemplo 1: Escribimos los skill points.
playerSkillPoints = 3;

// Ejemplo 2: Leemos y Escribimos los skill points.
playerSkillPoints = playerSkillPoints - 2;

```
- Primero creamos `playerSkillPoints` y le damos un valor inicial de 8.
- Luego escribimos en la variable el valor de 3, así que ha cambiado.
- Después leemos el valor de la variable, le restamos 2, y el valor resultante de la expresión lo escribimos en esa misma variable.
- Importante recordar que las líneas de código terminadas en punto y coma siempre van a ejecutarse de ARRIBA A ABAJO. 
