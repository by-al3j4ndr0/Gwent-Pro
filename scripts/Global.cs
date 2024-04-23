using Godot;
using System;

public class Global : Node
{
    public string current_player = "Templars";
    public bool hasPlay = false;
    public TemplarsCards templarsCards = new TemplarsCards();
    public RomansCards romansCards = new RomansCards();
    public int templarsPoints = 0;
    public int romansPoints = 0;
    public bool templarsFinishTurn = false;
    public bool romansFinishTurn = false;
    public int roundCounter = 1;
    public int templarsWins = 0;
    public int romansWins = 0;
    public string alreadyWinner = "";
    public string[] positions = {"Melee", "Distance", "Asedium", "MeleeIncrease", "DistanceIncrease", "AsediumIncrease"};
}
