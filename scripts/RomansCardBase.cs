using Godot;
using System;

public class RomansCardBase : Control
{
    // Initializing variables
    private Global global;
    [Export]
    private string card_name;
    private string picture_name;
    private string name;
    // private string type;
    // private int points;
    // private string description;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // global = GetNode<Global>("/root/Global");
        // GetNode<Sprite>("Card").Texture = GD.Load<Texture>($"res://assets/cards/romans/{global.templarsCards.leader[0]}.png"); // Set card image
        // GetNode<Label>("Bars/TopBar/MidGap/Name").Text = global.templarsCards.leader[1]; // Set card name
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        
    }
}