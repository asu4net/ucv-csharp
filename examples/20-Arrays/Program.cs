using Raylib_cs;
using System.Numerics;

Console.WriteLine("Hello, World!");

Raylib.InitWindow(1280, 720, "Mi ventana");

Camera2D camera = new Camera2D();
camera.Offset = new Vector2(1280/2, 720/2);
camera.Zoom = 1;

Scene scene = new Scene();
GameObject rectA = scene.CreateGameObject(new Vector2(0, 0), new Vector2(100, 100), Color.Red);
GameObject rectB = scene.CreateGameObject(new Vector2(150, 0), new Vector2(100, 100), Color.Blue);

bool running = true;
while(running)
{
    running = Raylib.WindowShouldClose() == false;

    Raylib.ClearBackground(Color.Black);
    Raylib.BeginDrawing();
    Raylib.BeginMode2D(camera);

    rectA.Draw();
    rectB.Draw();

    Raylib.EndMode2D();
    Raylib.EndDrawing();
}