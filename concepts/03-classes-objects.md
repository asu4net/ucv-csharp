# Classes and Objects

Para practicar las classes vamos a crear un nuevo proyecto, puedes
llamarlo 03-Classes. Luego entra a `Program.cs` y ve escribiendo lo
que vas aprendiendo. 

Siempre que escribas algo llama a `dotnet run` para
compilar y ejecutar tu proyecto. 

## ¿Por qué necesitamos clases?

Sin necesidad de usar clases, podemos afirmar que el siguiente
grupo de variables podría definir un Character (Personaje):

```cs
string characterName;
int characterLifeCharges;
float characterLife;
float characterMana;
```
Hasta aquí es sencillo, pero ¿Qué pasa si queremos almacenar los valores
de un segundo personaje? Sin clases tendríamos que hacer lo siguiente:

```cs
// Personaje 1
string characterName;
int characterLifeCharges;
float characterLife;
float characterMana;

// Personaje 2
string character2Name;
int character2LifeCharges;
float character2Life;
float character2Mana;
```
Esto es una solución pésima y va a escalar fatal. Si queremos añadir
nuevos personajes hemos de duplicar y renombrar ese grupo de variables
cada vez. Si queremos añadir un nuevo atributo a un personaje, tenemos
que añadirlo manualmente en cada uno.

## ¿Qué es una clase?

C# nos permite crear nuestros propios grupos de variables
como definiendo un *tipo* nuevo. Esto es lo que son las clases:

```cs
public class Character
{
    // Attributes
    public string name;
    public int lifeCharges;
    public float life;
    public float mana;
}
```
> Nota 1: SIEMPRE escribir las clases en SU PROPIO ARCHIVO, por ejemplo
  la clase `Character` debería ir en un archivo llamado `Character.cs`.

> Nota 2: `public` usado delante de una clase significa que desde
  otros archivos podrá usarse el *tipo* de la clase. Mientras que
  `public` delante de las variables significa que **fuera de la clase**
  podrás **leer** y **escribir** sus variables.

## Variables creadas a partir de una clase.

Hasta aquí hemos creado la clase, pero NO la hemos usado. Para ello
tendremos que crear una variable usando como **tipo** el nombre de 
la clase. 

```cs
Character player; // El valor por defecto es null.
```

Al contrario que las variables de tipo básico (int, float, char, bool, etc...)
una variable creada a partir del tipo de una clase tiene un valor por defecto
"nulo" al que no le podemos dar utilidad. Un `int`, por ejemplo, tiene valor 
por defecto 0, pero esto sigue siendo un número. Podemos sumarle otro número,
restarlo, multiplicarlo. 

`null` sin embargo, sólo nos indica si la variable de clase está vacía. Por ejemplo:

```
if (player != null)
{
    // Do something.
}
```
A continuación veremos cómo darle un valor a este tipo de variables.

## Cómo crear un objeto

Cuando creamos una variable de tipo básico, se reserva un espacio en la memoria
RAM física de nuestro ordenador para almacenar su valor. Le hayamos dado uno
nosotros o esté usando el que tiene por defecto.

Sin embargo cuando creamos una variable a partir de una clase, **sólo** va a resevarse
espacio físico para ella a partir de que le demos un valor. Si no lo hacemos
es `null`, como hemos visto en el apartado anterior. 

Para darle valor, igual que una variable de tipo básico hemos 
de escribir algo a la derecha del símbolo igual `=`. Concretamente 
hemos de usar la palabra reservada `new`, seguida del nombre de la clase 
y dos paréntesis, como si estuvieramos llamando a una función.

```cs
Character player = new Character();
```

Cuando le damos valor a una variable de clase se reserva memoria
física suficiente para almacenar todas sus variables. Esto es lo 
que se conoce como un *objeto*. Vamos a ver el siguiente código:

```cs
int someNumber   = 8;
Character player = new Character();
string someText  = "Buenas tardes.";
```
Esto, equivale, en memoria física, a lo siguiente:

```
-- Memoria RAM --
------------------------------------------
someNumber          -> 8
------------------------------------------
player:
    name            -> ""
    lifeCharges     -> 0
    life            -> 0.0f
    mana            -> 0.0f
------------------------------------------
someText            -> "Buenas tardes"
------------------------------------------
```
> Note: Fijaros en que todas estas variables de `player` 
  quedan inicializadas a sus valores por defecto.

¿Y qué pasa si creamos otro objeto de tipo `Character`?

```cs
int someNumber = 8;
Character player = new Character();
string someText = "Buenas tardes.";
Character enemy = new Character();
```
En memoria sería lo siguiente:

```
-- Memoria RAM --
------------------------------------------
someNumber          -> 8
------------------------------------------
player:
    name            -> ""
    lifeCharges     -> 0
    life            -> 0.0f
    mana            -> 0.0f
------------------------------------------
someText            -> "Buenas tardes"
------------------------------------------
enemy:
    name            -> ""
    lifeCharges     -> 0
    life            -> 0.0f
    mana            -> 0.0f
------------------------------------------
```
Vamos a hacer un poco de recapitulación:

Como podemos apreciar, un objeto es *una instancia de una clase*.
Cuando creamos una clase, sólo estamos definiendo una plantilla
que describe qué variables tendrán los objetos de dicha clase:

```cs
public class Weapon
{
    public string name;
    public float damage;
}
```
De una clase podemos crear los objetos que queramos:
```cs
Weapon sword = new Weapon();
Weapon axe = new Weapon();
```
Y estos objetos a su vez resevarán espacio físico para sus respectivas variables:
```
-- Memoria RAM --
------------------------------------------
sword:
    name   -> ""
    damage -> 0
------------------------------------------
axe:
    name   -> ""
    damage -> 0
------------------------------------------
```
## Cómo usar un objeto

Para acceder a las variables de un objeto usamos el nombre del objeto
(del **objeto**, no de la clase), seguido del operador punto `.` y este,
a su vez, seguido del nombre de la variable a la que queremos acceder. A
partir de aquí, se aplican todas las normas que conocemos, de *leer* y *escribir*
en variables. 

Por ejemplo, si en nuestro juego ficticio tenemos un yunke, que mejora los objetos
creados a partir de la clase `Weapon`, y en ese yunke, colocamos el objeto `sword`:

```cs
float damageUpgrade = 10.0f;
// Lectura y escritura de la variable damage, del objeto sword.
sword.damage = sword.damage + damageUpgrade;
```
Como es lógico para este ejemplo, el objeto `axe`, que estaba inicializado a sus valores
por defecto, permanece con el valor `damage` a `0`. Son **dos instancias distintas** de la 
misma clase. Y en consecuencia, cada una tiene **su propio almacenamiento**. Si queremos 
modificar el `axe` también, hemos de acceder a sus variables, como hicimos con sword:

```cs
axe.name = "Quebranta huesos";
axe.damage = axe.damage + damageUpgrade;
```
## Funciones en una clase

Para reutilizar operaciones comunes que podamos llevar a cabo sobre los objetos de una 
misma clase podemos usar *métodos*. Los *métodos* son funciones que pueden llamarse 
sobre un objeto. 

Volviendo al ejemplo de la espada y el hacha, vamos a crear un método que ponga
en común todo el asunto de la mejora en el yunke:

```cs
public class Weapon
{
    public string name;
    public float damage;
    
    // Método upgrade, recibe como parámetro de entrada
    // el daño que le añadiremos al arma.
    public void Upgrade(float damageUpgrade)
    {
        this.damage = this.damage + damageUpgrade;
    }
}
```
> Nota: `this` significa literalmente "este objeto". Como estamos escribiendo
  código en la clase, no tenemos definida ninguna instancia, así que usamos la
  esta palabra para acceder a las variables propias de la clase.`

Luego, en nuestro juego ficticio, podemos usar este método sobre los objetos
que queramos, siempre que pertenezcan a la clase `Weapon`:
```cs
sword.Upgrade(10.0f); // Aquí el "this" equivale a sword.
axe.Upgrade(100.0f);  // Aquí el "this" equivale a axe.
```
> Nota: NO es recomendable crear un método para una sola línea de código,
  para este ejemplo lo hemos hecho porque para simplificar la explicación
  pero normalmente quieres hacer esto para operaciones más complejas que
  quieras reutilizar en una misma clase.
