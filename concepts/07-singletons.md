# Singletons

## Problema del acceso a elementos comunes.

Cuando estamos programando un videojuego normalmente nos encontramos 
con la siguiente situación: Queremos acceder al Player desde otra
clase.

Con lo que sabemos ahora usaríamos una variable pública y asignaríamos
una referencia al Player usando el editor de Unity. O si no queremos
hacerlo de ese modo escribiríamos un código similar a este:

```cs
GameObject player = null;

void Start() 
{
    player = FindObjectOfType<PlayerController>();
    player.GiveItem(sword);
}
```

Esto en sí mismo no parece demasiado nocivo. Pero en un proyecto largo la lista
de cosas habituales a las que vamos a necesitar acceder aumenta. Además hay elementos
comunes a toda la partida que nuestro juego va a necesitar gestionar. Cosas como:

- Cargar niveles.
- Lanzar cinemáticas.
- Crear al jugador.
- Mostrar la pantalla de GameOver.

Si por cada una de esas tareas tenemos que crear un GameObject y una clase
a la larga vamos a tener problemas en recordar cuáles son y cómo acceder
a estas instancias desde otras clases. 

## ¿Qué es un Singleton?

Un Singleton es una clase de la que *solo puede existir una instancia*. Añadiendo
esta restricción podemos garantizar el fácil acceso a dicha instancia, así como las 
variables y métodos que contiene:

```cs
void Start() 
{
    GameManager.Instance.Player.GiveItem(sword);
}
```
Vamos a desglosar esto por partes:
- `GameManager`: Un `MonoBehaviour` script de Unity, se va a encargar
  del *estado global* de la partida, y por tanto, mantiene una referencia
  al Player.
- `Instance`: Es *una variable estática*, creada dentro de la clase `GameManager` 
   y que guarda una referencia a *la única instancia* que hay `de sí misma`.
- `Player`: Una variable pública, normal y corriente, creada dentro de la clase
  `GameManager`, que contiene una referncia al GameObject del jugador.

Como véis, no ha sido necesaria una búsqueda con `FindObjectOfType`, o asignar
el jugador desde el editor con una variable pública. Tan solo acceder a una variable
estática `Instance`, de tipo `GameManager`.

## ¿Cómo se crea un Singleton?

Aquí está el código comentado de cómo crear un Singleton en el contexto
de Unity. En este caso concreto el Singleton va a ser una clase GameManager,
que vamos a usar para gestionar el estado global de la partida en nuestro
juego.

```cs
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Primero creamos una variable privada y estática del tipo GameManager.
    private static GameManager _instance = null;

    // Después vamos a crear una property de C#, estática.
    // Esta property la usaremos para acceder a la variable _instance.
    public static GameManager Instance 
    { 
        // Definimos lo que sucede cuando se accede a la variable.
        get 
        {
            // Si es la primera vez que se llama a Instance, _instance será null.
            if (_instance == null) 
            {
                // Buscamos una instancia de GameManager, al menos tenemos que haber añadido una en la escena.
                _instance = FindAnyObjectByType<GameManager>();
                if (_instance == null)
                {
                    Debug.LogError("GameManager Singleton is missing from the scene!");
                }
            }
            // Retornamos la instancia.
            return _instance;
        }
    }

    public void Awake()
    {
        // Importante comprobar que no existan otras instancias
        // que accidentalmente podemos haber añadido a la escena.
        // Si es el caso, las borramos y lanzamos un warning.
        if (Instance != this)
        {
            Debug.LogWarning("Can not exist multiple instances of GameManager.");
            Debug.LogWarning("Deleting: " + this.gameObject.name);
            Destroy(this.gameObject);
            return;
        }

    }
}
```
