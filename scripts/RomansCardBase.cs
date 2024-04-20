using Godot;
using System;

public class RomansCardBase : Control
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

    private void _on_RomansButton_mouse_entered()
    {
        var global = (Global)GetNode("/root/Global");
        if(global.current_player == "romans"){
            GetNode<Control>("/root/Main/RomansDescription").Visible = true;
            GetNode<Sprite>("/root/Main/RomansDescription/Card").Texture = this.GetNode<Sprite>("Card").Texture;
            GetNode<Label>("/root/Main/RomansDescription/Bars/TopBar/MidGap/Name").Text = this.GetNode<Label>("Bars/TopBar/MidGap/Name").Text;
            GetNode<Label>("/root/Main/RomansDescription/Bars/MidBar/MidGap/Type").Text = this.GetNode<Label>("HideProperties/Type").Text;
            GetNode<Label>("/root/Main/RomansDescription/Bars/MidBar/RightGap/Points").Text = this.GetNode<Label>("HideProperties/Points").Text;
            GetNode<Label>("/root/Main/RomansDescription/Bars/ButtonBar/MidGap/Description").Text = this.GetNode<Label>("HideProperties/Description").Text;
        } else if(global.current_player == "templars"){
            GetNode<Control>("/root/Main/RomansDescription").Visible = false;
        }
    }

    private void _on_RomansButton_mouse_exited()
    {
        GetNode<Control>("/root/Main/RomansDescription").Visible = false;
    }

    private void _on_RomanButton_pressed()
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
                Node targetNode = GetNode($"/root/Main/RomansPositions/{type}");
                thisNode.GetParent().RemoveChild(thisNode);
                targetNode.AddChild(thisNode);
            }
            global.hasPlay = true;
            points = this.GetNode<Label>("HideProperties/Points").Text;
            global.romansPoints += int.Parse(points);
        }
    }

}