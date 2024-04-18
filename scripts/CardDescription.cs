using Godot;
using System;

public class CardDescription : Control
{
    // Initializing variables
    private Global global;
    private string card_name;
    private string picture_name;
    private string name;
    private string type;
    private int points;
    private string description;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        global = GetNode<Global>("/root/Global");
        GetNode<Sprite>("Card").Texture = GD.Load<Texture>($"res://assets/cards/{global.current_player}/back.png");
        if(global.current_player == "templars"){
            GetNode<Label>("Bars/TopBar/MidGap/Name").Text = "Templars Knights";
        } else if(global.current_player == "romans"){
            GetNode<Label>("Bars/TopBar/MidGap/Name").Text = "Romans Legionars";
        }
    }
}
