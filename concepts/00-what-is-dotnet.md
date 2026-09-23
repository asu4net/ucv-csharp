# ¿Qué es .NET?

- .NET es un conjunto de herramientas de Microsoft.
- **Lo IMPORTANTE** es que puede crear y compilar proyectos de C#.
- Un proyecto de C# es un conjunto de archivos de extensión `.cs`.
- Estos archivos tendrán código C# que describe qué ha de hacer nuestro programa.
- .NET puede *compilar* este proyecto.
- *Compilar* es convertir nuestros archivos `.cs` con su código `C#` a un **EJECUTABLE**.

```text
    ┌─────────────┐      ┌───────┐      ┌─────────────┐
    │   C# Code   │ ───> │  .NET │ ───> │   game.exe  │
    └─────────────┘      └───────┘      └─────────────┘
```

> Nota: Unity hace esto con nuestros scripts `.cs`, pero en vez de convertirlo
  en un `.exe` lo convierte en un `.dll`. (Dynamic Link Library). Este archivo
  luego es utilizado por tu `game.exe` para darle comportamiento a los GameObjects.
