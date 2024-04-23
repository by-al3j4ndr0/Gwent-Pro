using Godot;
using System;

public class Main : Node2D
{
    [Signal]
    public delegate void finishRound();
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GetNode<Control>("TemplarsDescription").Visible = false;
        GetNode<Control>("RomansDescription").Visible = false;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        var global = (Global)GetNode("/root/Global");
        GetNode<Label>("PointsPop/TemplarsPoints").Text = $"{global.templarsPoints.ToString()} Pts.";
        GetNode<Label>("PointsPop/RomansPoints").Text = $"{global.romansPoints.ToString()} Pts.";
        GetNode<Label>("PointsPop2/TemplarsPoints").Text = $"{global.templarsPoints.ToString()} Pts.";
        GetNode<Label>("PointsPop2/RomansPoints").Text = $"{global.romansPoints.ToString()} Pts.";
        _GetWinner();
    }

    private void _on_FinishTurn_pressed()
    {
        var global = (Global)GetNode("/root/Global");
        // Check que current player and do the changes in the enviroment 
        if(global.current_player == "Templars"){
            GetNode<Camera2D>("TemplarsCam").Current = false; // Change the player camera
            GetNode<Camera2D>("RomansCam").Current = true;
            GetNode<Sprite>("BoardBG").FlipV = true; // Rotate the background
            GetNode<TextureButton>("FinishTurn").RectRotation = 180; // Rotate the button
            GetNode<Control>("TemplarsDescription").Visible = false;
            if(global.hasPlay == false){
                global.templarsFinishTurn = true;
            }
            global.current_player = "Romans";
            global.hasPlay = false;
        } else if(global.current_player == "Romans"){
            GetNode<Camera2D>("TemplarsCam").Current = true;
            GetNode<Camera2D>("RomansCam").Current = false;
            GetNode<Sprite>("BoardBG").FlipV = false;
            GetNode<TextureButton>("FinishTurn").RectRotation = 0;
            GetNode<Control>("RomansDescription").Visible = false;
            if(global.hasPlay == false){
                global.romansFinishTurn = true;
            }
            global.current_player = "Templars";
            global.hasPlay = false;
        }
        if(global.romansFinishTurn == true && global.templarsFinishTurn == true){
            EmitSignal("finishRound");
        }
    }
    private void _GetWinner()
    {
        var global = (Global)GetNode("/root/Global");
        if(global.templarsPoints > global.romansPoints)
        {
            global.alreadyWinner = "Templars";
        } else if(global.templarsPoints < global.romansPoints)
        {
            global.alreadyWinner = "Romans";
        } else if(global.templarsPoints == global.romansPoints){
            global.alreadyWinner = "Tied";
        }
    }

    private void _on_ResetRound_pressed()
    {
        var global = (Global)GetNode("/root/Global");
        foreach(string position in global.positions)
        {
            var templars_node = GetNode($"TemplarsPositions/{position}");
            for(int i = 0; i < templars_node.GetChildCount(); i++){
                var templars_child = templars_node.GetChild(i);
                templars_node.RemoveChild(templars_child);
            }

            var romans_node = GetNode($"RomansPositions/{position}");
            for(int i = 0; i < romans_node.GetChildCount(); i++){
                var romans_child = romans_node.GetChild(i);
                romans_node.RemoveChild(romans_child);
            }   
        }
        GetNode<Popup>("PopupControl/FinishRoundPopup").Hide();

        global.templarsFinishTurn = false;
        global.romansFinishTurn = false;
        global.roundCounter += 1;
    }
}