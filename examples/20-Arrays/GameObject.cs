using Raylib_cs;
using System.Numerics;

public class GameObject
{
    public Vector2 position;
    public Vector2 size;
    public Color color;
    public Vector2 speed;

    public GameObject(Vector2 position, Vector2 size, Color color, Vector2 speed = new Vector2())
    {
       this.position = position;
       this.size     = size;
       this.color    = color;
       this.speed    = speed;
    }

    public void Draw()
    {
        Raylib.DrawRectangle(
            (int) this.position.X,
            (int) this.position.Y,
            (int) this.size.X,
            (int) this.size.Y,
            this.color
        );
    }
}