using Godot;
using System;

public class TemplarsHand : HBoxContainer
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
            card_rnd = rnd.Next(0, global.templarsCards.name.Count);
            card_name = global.templarsCards.name[card_rnd];
            child.GetNode<Sprite>("Card").Texture = GD.Load<Texture>($"res://assets/cards/templars/{card_name[0]}.png");
            child.GetNode<Label>("Bars/TopBar/MidGap/Name").Text = card_name[1];
            child.GetNode<Label>("HideProperties/Type").Text = card_name[2];
            child.GetNode<Label>("HideProperties/Points").Text = card_name[4];
            child.GetNode<Label>("HideProperties/Description").Text = card_name[5];
            // global.templarsCards.name.RemoveAt(card_rnd);
        }

        GetNode<Sprite>("/root/Main/TemplarsPositions/Leader/Leader/Card").Texture = GD.Load<Texture>("res://assets/cards/templars/leader.png");
        GetNode<Label>("/root/Main/TemplarsPositions/Leader/Leader/Bars/TopBar/MidGap/Name").Text = global.templarsCards.leader[1];
        GetNode<Label>("/root/Main/TemplarsPositions/Leader/Leader/HideProperties/Type").Text = global.templarsCards.leader[2];
        GetNode<Label>("/root/Main/TemplarsPositions/Leader/Leader/HideProperties/Points").Text = global.templarsCards.leader[4];
        GetNode<Label>("/root/Main/TemplarsPositions/Leader/Leader/HideProperties/Description").Text = global.templarsCards.leader[5];
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        
    }

    private void _on_TemplarLeaderButton_mouse_entered()
    {
        var global = (Global)GetNode("/root/Global");
        if(global.current_player == "templars"){
            GetNode<Control>("/root/Main/TemplarsDescription").Visible = true;
            GetNode<Sprite>("/root/Main/TemplarsDescription/Card").Texture = GetNode("/root/Main/TemplarsPositions/Leader/Leader").GetNode<Sprite>("Card").Texture;
            GetNode<Label>("/root/Main/TemplarsDescription/Bars/TopBar/MidGap/Name").Text = GetNode("/root/Main/TemplarsPositions/Leader/Leader").GetNode<Label>("Bars/TopBar/MidGap/Name").Text;
            GetNode<Label>("/root/Main/TemplarsDescription/Bars/MidBar/MidGap/Type").Text = this.GetNode<Label>("/root/Main/TemplarsPositions/Leader/Leader/HideProperties/Type").Text;
            GetNode<Label>("/root/Main/TemplarsDescription/Bars/MidBar/RightGap/Points").Text = this.GetNode<Label>("/root/Main/TemplarsPositions/Leader/Leader/HideProperties/Points").Text;
            GetNode<Label>("/root/Main/TemplarsDescription/Bars/ButtonBar/MidGap/Description").Text = this.GetNode<Label>("/root/Main/TemplarsPositions/Leader/Leader/HideProperties/Description").Text;
        } else if(global.current_player == "romans"){
            GetNode<Control>("/root/Main/TemplarsDescription").Visible = false;
        }
    }

    private void _on_TemplarLeaderButton_mouse_exited()
    {
        GetNode<Control>("/root/Main/TemplarsDescription").Visible = false;
    }
}
