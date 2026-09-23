# Classes and Instances

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
> Nota: `public` usado delante de una clase significa que desde
  otros archivos podrá usarse el *tipo* de la clase. Mientras que
  `public` delante de las variables significa que **fuera de la clase**
  podrás **leer** y **escribir** sus variables.

## Cómo crear una instancia/objeto

Hasta aquí hemos creado la clase, pero NO la hemos usado. Para ello
tendremos que crear una variable usando como **tipo** el nombre de 
la clase. 

Las variables creadas a partir de clases se 
denominan instancias (objetos).

```cs
// Objeto 1 
Character player = new Character();
// Objeto 2
Character enemy = new Character();
```
