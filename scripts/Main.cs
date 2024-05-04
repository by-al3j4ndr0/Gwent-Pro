using Godot;
using System;

public class Main : Node2D
{
    Global global;
    Random rnd = new Random();
    int card_rnd;
    public string[] card_name;
    [Signal]
    public delegate void finishRound();
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        global = GetNode<Global>("/root/Global");
        
        GetNode<Control>("TemplarsDescription").Visible = false;
        GetNode<Control>("RomansDescription").Visible = false;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        GetNode<Label>($"{global.current_player}Pop/TemplarsPoints").Text = $"{global.templarsPoints.ToString()} Pts.";
        GetNode<Label>($"{global.current_player}Pop/RomansPoints").Text = $"{global.romansPoints.ToString()} Pts.";

        _GetSumPoints();
        _GetWinner();
    }

    private void _on_FinishTurn_pressed()
    {
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
    private void _GetSumPoints()
    {
        global.templarsTotal = global.templarsMeleePoints + global.templarsDistancePoints + global.templarsAsediumPoints;
        global.templarsPoints = global.templarsTotal - global.weatherPoints;
        global.romansTotal = global.romansMeleePoints + global.romansDistancePoints + global.romansAsediumPoints;
        global.romansPoints = global.romansTotal - global.weatherPoints;
    }
    private void _GetWinner()
    {
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
        int i = 0;
        foreach(string position in global.positions)
        {
            var templars_node = GetNode($"TemplarsPositions/{position}");
            while(i < templars_node.GetChildCount()){
                var templars_child = templars_node.GetChild(i);
                templars_node.RemoveChild(templars_child);
            }

            var romans_node = GetNode($"RomansPositions/{position}");
            while(i < romans_node.GetChildCount()){
                var romans_child = romans_node.GetChild(i);
                romans_node.RemoveChild(romans_child);
            }  
        }

        var weatherPositions = GetNode("/root/Main/WeatherPositions");
        for(int j = 0; j < 3; j++)
        {
            Node targetNode = weatherPositions.GetNode($"{global.positions[j]}Weather");
            if(targetNode.GetChildCount() == 1)
            {
                targetNode.RemoveChild(targetNode.GetChild(0));
            }
        }

        _GetNewCards();

        GetNode<Popup>("PopupControl/FinishRoundPopup").Hide();

        global.templarsFinishTurn = false;
        global.romansFinishTurn = false;
        global.roundCounter += 1;

        global.templarsMeleePoints = 0;
        global.templarsDistancePoints = 0;
        global.templarsAsediumPoints = 0;
        global.romansMeleePoints = 0;
        global.romansDistancePoints = 0;
        global.romansAsediumPoints = 0;
        global.weatherPoints = 0;
    }

    private void _GetNewCards()
    {
        for(int k = 0; k < 2; k++){
            var cardBase = ResourceLoader.Load<PackedScene>("res://scenes/TemplarsCardBase.tscn").Instance();
            GetNode("/root/Main/TemplarsHand").AddChild(cardBase);
            card_rnd = rnd.Next(0, global.templarsCards.name.Count);
            card_name = global.templarsCards.name[card_rnd];
            cardBase.GetNode<Sprite>("Card").Texture = GD.Load<Texture>($"res://assets/cards/templars/{card_name[0]}.png");
            cardBase.GetNode<Label>("Bars/TopBar/MidGap/Name").Text = card_name[1];
            cardBase.GetNode<Label>("HideProperties/Type").Text = card_name[2];
            cardBase.GetNode<Label>("HideProperties/Points").Text = card_name[4];
            cardBase.GetNode<Label>("HideProperties/Description").Text = card_name[5];
            global.templarsCards.name.RemoveAt(card_rnd);

            var buttonBase = ResourceLoader.Load<PackedScene>("scenes/TemplarButton.tscn").Instance();
            cardBase.AddChild(buttonBase);
            buttonBase.Connect("pressed", cardBase, "_on_TemplarButton_pressed");
            buttonBase.Connect("mouse_entered", cardBase, "_on_TemplarsButton_mouse_entered");
            buttonBase.Connect("mouse_exited", cardBase, "_on_TemplarsButton_mouse_exited");
        }

        for(int k = 0; k < 2; k++){
            var cardBase = ResourceLoader.Load<PackedScene>("res://scenes/RomansCardBase.tscn").Instance();
            GetNode("/root/Main/RomansHand").AddChild(cardBase);
            card_rnd = rnd.Next(0, global.romansCards.name.Count);
            card_name = global.romansCards.name[card_rnd];
            cardBase.GetNode<Sprite>("Card").Texture = GD.Load<Texture>($"res://assets/cards/romans/{card_name[0]}.png");
            cardBase.GetNode<Label>("Bars/TopBar/MidGap/Name").Text = card_name[1];
            cardBase.GetNode<Label>("HideProperties/Type").Text = card_name[2];
            cardBase.GetNode<Label>("HideProperties/Points").Text = card_name[4];
            cardBase.GetNode<Label>("HideProperties/Description").Text = card_name[5];
            global.romansCards.name.RemoveAt(card_rnd);

            var buttonBase = ResourceLoader.Load<PackedScene>("scenes/RomanButton.tscn").Instance();
            cardBase.AddChild(buttonBase);
            buttonBase.Connect("pressed", cardBase, "_on_RomanButton_pressed");
            buttonBase.Connect("mouse_entered", cardBase, "_on_RomansButton_mouse_entered");
            buttonBase.Connect("mouse_exited", cardBase, "_on_RomansButton_mouse_exited");
        }
    }
}