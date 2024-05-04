using Godot;
using System;

public class FinishRoundDialog : Popup
{
    Global global;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        global = GetNode<Global>("/root/Global");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        
    }

    private void _on_finishRound_signal()
    {
        this.Show();

        if(global.current_player == "Templars")
        {
            GetNode<Popup>("/root/Main/PopupControl/FinishRoundPopup").RectRotation = 0;
        } else if(global.current_player == "Romans")
        {
            GetNode<Popup>("/root/Main/PopupControl/FinishRoundPopup").RectRotation = 180;
        }

        GetNode<Label>("/root/Main/PopupControl/FinishRoundPopup/Round").Text = $"Round {global.roundCounter}";

        if(global.alreadyWinner == "Templars")
        {
            GetNode<Label>("/root/Main/PopupControl/FinishRoundPopup/Winner").Text = $"{global.alreadyWinner} Wins!";
            global.templarsWins += 1;
        } else if(global.alreadyWinner == "Romans")
        {
            GetNode<Label>("/root/Main/PopupControl/FinishRoundPopup/Winner").Text = $"{global.alreadyWinner} Wins!";
            global.romansWins += 1;
        } else if(global.alreadyWinner == "Tied")
        {
            GetNode<Label>("/root/Main/PopupControl/FinishRoundPopup/Winner").Text = $"{global.alreadyWinner}!";
            global.templarsWins += 1;
            global.romansWins += 1;
        }

        
    }
}
