using Raylib_cs;
using System.Numerics;

public class Scene
{
    public static int MaxObjects = 50;

    public GameObject[] gameObjects;
    public int count;

    public GameObject CreateGameObject(Vector2 position, Vector2 size, Color color, Vector2 speed = new Vector2())
    {
        // Si el array de gameObjects está nulo, lo inicializamos.  
        if (gameObjects == null)
        {
            gameObjects = new GameObject[MaxObjects];
        }
        
        GameObject newObject = new GameObject(position, size, color, speed);
        gameObjects[count] = newObject;
        count += 1;
        return newObject;
    }
}