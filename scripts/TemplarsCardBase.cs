using Godot;
using System;

public class TemplarsCardBase : Control
{
    Global global;
    string type;
    int points;
    int rndPosition;
    int childCount;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        global = GetNode<Global>("/root/Global");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

    }

    private void _on_TemplarsButton_mouse_entered()
    {
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
        Random rnd = new Random();
        if(global.hasPlay == false){
            type = this.GetNode<Label>("HideProperties/Type").Text;
            var path = GetPath();
            Node thisNode = this.GetNode<Control>(path);
            points = int.Parse(this.GetNode<Label>("HideProperties/Points").Text);
            if(global.baitPlayed == true)
            {
                var targetNode = GetNode<HBoxContainer>("/root/Main/TemplarsHand");
                thisNode.GetParent().RemoveChild(thisNode);
                targetNode.AddChild(thisNode);
                targetNode.Visible = true;
                global.baitPlayed = false;
                global.hasPlay = true;
            } else if(type == "Weather")
            {
                // rndPosition = rnd.Next(0, 3);
                // Node targetNode = GetNode($"/root/Main/WeatherPositions/{global.positions[rndPosition]}Weather"); 
                // thisNode.GetParent().RemoveChild(thisNode);
                // targetNode.AddChild(thisNode);
                // global.weatherPoints += points;
                // global.hasPlay = true;

                for (int i = 0; i < 3; i++)
                {
                    rndPosition = rnd.Next(0, 3);
                    Node targetNode = GetNode($"/root/Main/WeatherPositions/{global.positions[rndPosition]}Weather"); 
                    childCount = targetNode.GetChildCount();
                    if(childCount == 0)
                    {
                        thisNode.GetParent().RemoveChild(thisNode);
                        targetNode.AddChild(thisNode);
                        if(global.positions[rndPosition] == "Melee"){
                            global.templarsMeleePoints -= points;
                        } else if(global.positions[rndPosition] == "Distance"){
                            global.templarsDistancePoints -= points;
                        } else if(global.positions[rndPosition] == "Asedium"){
                            global.templarsAsediumPoints -= points;
                        }
                        global.hasPlay = true;
                        break;
                    }
                }
            } else if(type == "Clearance") 
            {
                var weatherPositions = GetNode("/root/Main/WeatherPositions");
                for(int i = 0; i < 3; i++)
                {
                    Node targetNode = weatherPositions.GetNode($"{global.positions[i]}Weather");
                    childCount = targetNode.GetChildCount();
                    if(childCount == 1)
                    {
                        var child = targetNode.GetChild(0);
                        targetNode.RemoveChild(child);
                        thisNode.GetParent().RemoveChild(thisNode);
                        global.weatherPoints = 0;
                        global.hasPlay = true;
                    }
                }
            } else if(type == "Increase")
            {
                for (int i = 0; i < 3; i++)
                {
                    rndPosition = rnd.Next(0, 3);
                    Node targetNode = GetNode($"/root/Main/TemplarsPositions/{global.positions[rndPosition]}Increase"); 
                    childCount = targetNode.GetChildCount();
                    if(childCount == 0)
                    {
                        thisNode.GetParent().RemoveChild(thisNode);
                        targetNode.AddChild(thisNode);
                        if(global.positions[rndPosition] == "Melee"){
                            global.templarsMeleePoints *= points;
                        } else if(global.positions[rndPosition] == "Distance"){
                            global.templarsDistancePoints *= points;
                        } else if(global.positions[rndPosition] == "Asedium"){
                            global.templarsAsediumPoints *= points;
                        }
                        global.hasPlay = true;
                        break;
                    }
                }
            } else if(type == "Bait")
            {
                var targetNode = GetNode<HBoxContainer>("/root/Main/TemplarsHand");
                thisNode.GetParent().RemoveChild(thisNode);
                global.baitPlayed = true;
                targetNode.Visible = false;
            } else {
                Node targetNode = GetNode($"/root/Main/TemplarsPositions/{type}");
                thisNode.GetParent().RemoveChild(thisNode);
                targetNode.AddChild(thisNode);
                global.hasPlay = true;

                if(type == "Melee")
                    {
                        global.templarsMeleePoints += points;
                    } else if(type == "Distance")
                    {
                        global.templarsDistancePoints += points;
                    } else if(type == "Asedium")
                    {
                        global.templarsAsediumPoints += points;
                    }
            }
        }
    }
}