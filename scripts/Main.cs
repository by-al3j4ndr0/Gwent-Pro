using Godot;
using System;

public class Main : Node2D
{
    public string current_player = "templars";
    
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
        if(current_player == "templars"){
            GetNode<Camera2D>("TemplarsCam").Current = false;
            GetNode<Camera2D>("RomansCam").Current = true;
            GetNode<Sprite>("BoardBG").FlipV = true;
            GetNode<TextureButton>("FinishTurn").RectRotation = 180;
            current_player = "romans";
        } else if(current_player == "romans"){
            GetNode<Camera2D>("TemplarsCam").Current = true;
            GetNode<Camera2D>("RomansCam").Current = false;
            GetNode<Sprite>("BoardBG").FlipV = false;
            GetNode<TextureButton>("FinishTurn").RectRotation = 0;
            current_player = "templars";
        }
    }
}
