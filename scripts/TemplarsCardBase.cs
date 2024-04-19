using Godot;
using System;

public class TemplarsCardBase : Control
{
    Godot.Texture picture;
    string name;
    string type;
    string points;
    string description;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

    }

    public void _on_TemplarsButton_mouse_entered()
    {
        GetNode<Control>("/root/Main/TemplarsDescription").Visible = true;
        GetNode<Sprite>("/root/Main/TemplarsDescription/Card").Texture = this.GetNode<Sprite>("Card").Texture;
        GetNode<Label>("/root/Main/TemplarsDescription/Bars/TopBar/MidGap/Name").Text = this.GetNode<Label>("Bars/TopBar/MidGap/Name").Text;
        GetNode<Label>("/root/Main/TemplarsDescription/Bars/MidBar/MidGap/Type").Text = this.GetNode<Label>("HideProperties/Type").Text;
        GetNode<Label>("/root/Main/TemplarsDescription/Bars/MidBar/RightGap/Points").Text = this.GetNode<Label>("HideProperties/Points").Text;
        GetNode<Label>("/root/Main/TemplarsDescription/Bars/ButtonBar/MidGap/Description").Text = this.GetNode<Label>("HideProperties/Description").Text;
    }

    public void _on_TemplarButton_pressed()
    {
        var global = (Global)GetNode("/root/Global");
        GD.Print(global.hasPlay);
        if(global.hasPlay == false){
            type = this.GetNode<Label>("HideProperties/Type").Text;
            var path = GetPath();
            Node thisNode = this.GetNode<Control>(path);
            Node targetNode = GetNode($"/root/Main/TemplarsPositions/{type}");
            thisNode.GetParent().RemoveChild(thisNode);
            targetNode.AddChild(thisNode);
            global.hasPlay = true;
        }
    }

    
}