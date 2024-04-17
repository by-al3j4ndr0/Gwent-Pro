using Godot;
using System;

public class CardBase : MarginContainer
{
    // Initializing variables
    private static TemplarsCards templarsCards = new TemplarsCards();
    private string card_name;
    private string picture_name;
    private string name;
    private string type;
    private string points;
    private string description;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Set variables values
        picture_name = templarsCards.leader[0];
        name = templarsCards.leader[1];
        type = templarsCards.leader[2];
        points = templarsCards.leader[4];
        description = templarsCards.leader[5];
        GetNode<Sprite>("Card").Texture = GD.Load<Texture>($"res://assets/cards/templars/{picture_name}"); // Set card image
        GetNode<Label>("Bars/TopBar/MidGap/Name").Text = name; // Set card name
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        
    }
 }
