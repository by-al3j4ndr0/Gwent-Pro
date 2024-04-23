using Godot;
using System;

public class TemplarsCardBase : Control
{
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

    private void _on_TemplarsButton_mouse_entered()
    {
        var global = (Global)GetNode("/root/Global");
        if(global.current_player == "Templars"){
            GetNode<Control>("/root/Main/TemplarsDescription").Visible = true;
            GetNode<Sprite>("/root/Main/TemplarsDescription/Card").Texture = this.GetNode<Sprite>("Card").Texture;
            GetNode<Label>("/root/Main/TemplarsDescription/Bars/TopBar/MidGap/Name").Text = this.GetNode<Label>("Bars/TopBar/MidGap/Name").Text;
            GetNode<Label>("/root/Main/TemplarsDescription/Bars/MidBar/MidGap/Type").Text = this.GetNode<Label>("HideProperties/Type").Text;
            GetNode<Label>("/root/Main/TemplarsDescription/Bars/MidBar/RightGap/Points").Text = this.GetNode<Label>("HideProperties/Points").Text;
            GetNode<Label>("/root/Main/TemplarsDescription/Bars/ButtonBar/MidGap/Description").Text = this.GetNode<Label>("HideProperties/Description").Text;
        } else if(global.current_player == "Romans"){
            GetNode<Control>("/root/Main/TemplarsDescription").Visible = false;
        }
    }

    private void _on_TemplarsButton_mouse_exited()
    {
        GetNode<Control>("/root/Main/TemplarsDescription").Visible = false;
    }

    private void _on_TemplarButton_pressed()
    {
        var global = (Global)GetNode("/root/Global");
        if(global.hasPlay == false){
            type = this.GetNode<Label>("HideProperties/Type").Text;
            var path = GetPath();
            Node thisNode = this.GetNode<Control>(path);
            if(type == "Weather"){
                Node targetNode = GetNode<CenterContainer>("/root/Main/WeatherPositions/MeleeWeather"); 
                thisNode.GetParent().RemoveChild(thisNode);
                targetNode.AddChild(thisNode);
            } else {
                Node targetNode = GetNode($"/root/Main/TemplarsPositions/{type}");
                thisNode.GetParent().RemoveChild(thisNode);
                targetNode.AddChild(thisNode);
            }
            global.hasPlay = true;
            points = this.GetNode<Label>("HideProperties/Points").Text;
            global.templarsPoints += int.Parse(points);
        }
    }    
}