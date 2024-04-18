using Godot;
using System;

public class Main : Node2D
{
    private Global global;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GetNode<BoxContainer>("RomansHand").Visible = false;
        GetNode<Control>("TemplarsDescription").Visible = true;
        GetNode<Control>("RomansDescription").Visible = false;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
    
    }

    public void _on_FinishTurn_pressed()
    {
        global = GetNode<Global>("/root/Global");
        // Check que current player and do the changes in the enviroment 
        if(global.current_player == "templars"){
            GetNode<Camera2D>("TemplarsCam").Current = false; // Change the player camera
            GetNode<Camera2D>("RomansCam").Current = true;
            GetNode<Sprite>("BoardBG").FlipV = true; // Rotate the background
            GetNode<TextureButton>("FinishTurn").RectRotation = 180; // Rotate the button
            GetNode<BoxContainer>("TemplarsHand").Visible = false;
            GetNode<BoxContainer>("RomansHand").Visible = true;
            GetNode<Control>("TemplarsDescription").Visible = false;
            GetNode<Control>("RomansDescription").Visible = true;
            global.current_player = "romans";
        } else if(global.current_player == "romans"){
            GetNode<Camera2D>("TemplarsCam").Current = true;
            GetNode<Camera2D>("RomansCam").Current = false;
            GetNode<Sprite>("BoardBG").FlipV = false;
            GetNode<TextureButton>("FinishTurn").RectRotation = 0;
            GetNode<BoxContainer>("RomansHand").Visible = false;
            GetNode<BoxContainer>("TemplarsHand").Visible = true;
            GetNode<Control>("TemplarsDescription").Visible = true;
            GetNode<Control>("RomansDescription").Visible = false;
            global.current_player = "templars";
        }
    }
}