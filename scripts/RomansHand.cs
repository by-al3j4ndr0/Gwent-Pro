using Godot;
using System;

public class RomansHand : HBoxContainer
{
    Random rnd = new Random();
    int card_rnd;
    public string[] card_name;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var global = (Global)GetNode("/root/Global");

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

        GetNode<Sprite>("/root/Main/RomansPositions/Leader/Leader/Card").Texture = GD.Load<Texture>("res://assets/cards/romans/leader.png");
        GetNode<Label>("/root/Main/RomansPositions/Leader/Leader/Bars/TopBar/MidGap/Name").Text = global.romansCards.leader[1];
        GetNode<Label>("/root/Main/RomansPositions/Leader/Leader/HideProperties/Type").Text = global.romansCards.leader[2];
        GetNode<Label>("/root/Main/RomansPositions/Leader/Leader/HideProperties/Points").Text = global.romansCards.leader[4];
        GetNode<Label>("/root/Main/RomansPositions/Leader/Leader/HideProperties/Description").Text = global.romansCards.leader[5];
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        
    }

    private void _on_RomanLeaderButton_mouse_entered()
    {
        var global = (Global)GetNode("/root/Global");
        if(global.current_player == "Romans"){
            GetNode<Control>("/root/Main/RomansDescription").Visible = true;
            GetNode<Sprite>("/root/Main/RomansDescription/Card").Texture = GetNode("/root/Main/RomansPositions/Leader/Leader").GetNode<Sprite>("Card").Texture;
            GetNode<Label>("/root/Main/RomansDescription/Bars/TopBar/MidGap/Name").Text = GetNode("/root/Main/RomansPositions/Leader/Leader").GetNode<Label>("Bars/TopBar/MidGap/Name").Text;
            GetNode<Label>("/root/Main/RomansDescription/Bars/MidBar/MidGap/Type").Text = GetNode("/root/Main/RomansPositions/Leader/Leader").GetNode<Label>("HideProperties/Type").Text;
            GetNode<Label>("/root/Main/RomansDescription/Bars/MidBar/RightGap/Points").Text = GetNode("/root/Main/RomansPositions/Leader/Leader").GetNode<Label>("HideProperties/Points").Text;
            GetNode<Label>("/root/Main/RomansDescription/Bars/ButtonBar/MidGap/Description").Text = GetNode("/root/Main/RomansPositions/Leader/Leader").GetNode<Label>("HideProperties/Description").Text;
        } else if(global.current_player == "Templars"){
           GetNode<Control>("/root/Main/RomansDescription").Visible = false; 
        }
    }

    private void _on_RomanLeaderButton_mouse_exited()
    {
        GetNode<Control>("/root/Main/RomansDescription").Visible = false;
    }

    private void _on_LeaderButton_pressed()
    {
        Node melee = GetNode("/root/Main/RomansPositions/Melee");
        Node hand = GetNode("/root/Main/RomansHand");
        int i = 0;
        while(i < melee.GetChildCount())
        {
            var child = melee.GetChild(i);
            melee.RemoveChild(child);
            hand.AddChild(child);
        }
    }
}
