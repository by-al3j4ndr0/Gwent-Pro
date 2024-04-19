using Godot;
using System;

public class RomansHand : HBoxContainer
{
    Random rnd = new Random();
    Global global = new Global();
    int card_rnd;
    string[] card_name;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        for(int i = 0; i < GetChildCount(); i++){
            var child = GetChild(i);
            card_rnd = rnd.Next(0, global.romansCards.name.Count);
            card_name = global.romansCards.name[card_rnd];
            child.GetNode<Sprite>("Card").Texture = GD.Load<Texture>($"res://assets/cards/romans/{card_name[0]}.png");
            child.GetNode<Label>("Bars/TopBar/MidGap/Name").Text = card_name[1];
            child.GetNode<Label>("HideProperties/Type").Text = card_name[2];
            child.GetNode<Label>("HideProperties/Points").Text = card_name[4];
            child.GetNode<Label>("HideProperties/Description").Text = card_name[5];
            // global.romansCards.name.RemoveAt(card_rnd);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        
    }
}
