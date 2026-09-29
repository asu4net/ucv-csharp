using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(1280, 720, "Mi ventana");

Camera2D camera = new Camera2D();
camera.Offset = new Vector2(1280f /2f, 720f/2f);
camera.Target = Vector2.Zero;
camera.Zoom = 100;

while (Raylib.WindowShouldClose() == false)
{
    Raylib.BeginDrawing();
    Raylib.BeginMode2D(camera);
    Raylib.DrawRectangle(0, 0, 1, 1, Color.White);
    Raylib.EndMode2D();
    Raylib.EndDrawing();
}
