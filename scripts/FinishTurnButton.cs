using Godot;
using System;

public class FinishTurnButton : TextureButton
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

    }

    private void _on_FinishTurn_pressed()
    {
        GD.Print("El boton pincha");
    }
}