using Raylib_cs;
using System.Numerics; // Para usar Vectores.

Raylib.InitWindow(1280, 720, "Mi ventana");

Camera2D camera = new Camera2D();
camera.Offset = new Vector2(1280f /2f, 720f/2f);
camera.Zoom = 100;

float whiteRectangleSpeed = 2;
Vector2 whiteRectanglePosition = new Vector2();

while (Raylib.WindowShouldClose() == false)
{
    float deltaTime = Raylib.GetFrameTime();
    whiteRectanglePosition += new Vector2(1, 0) * whiteRectangleSpeed * deltaTime;

    Raylib.BeginDrawing();
    Raylib.BeginMode2D(camera);

    Raylib.DrawRectangleV(whiteRectanglePosition, new Vector2(1, 1), Color.White);
    Raylib.DrawRectangleV(new Vector2(0, 0), new Vector2(1, 1), Color.Red);

    Raylib.EndMode2D();
    Raylib.EndDrawing();
}
