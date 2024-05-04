using Godot;
using System;

public class Global : Node
{
    public string current_player = "Templars";
    public bool hasPlay = false;
    public bool baitPlayed = false;
    public TemplarsCards templarsCards = new TemplarsCards();
    public RomansCards romansCards = new RomansCards();
    public int templarsTotal = 0;
    public int templarsMeleePoints = 0;
    public int templarsDistancePoints = 0;
    public int templarsAsediumPoints = 0;
    public int romansTotal = 0;
    public int romansMeleePoints = 0;
    public int romansDistancePoints = 0;
    public int romansAsediumPoints = 0;
    public int templarsPoints = 0;
    public int romansPoints = 0;
    public bool templarsFinishTurn = false;
    public bool romansFinishTurn = false;
    public int roundCounter = 1;
    public int templarsWins = 0;
    public int romansWins = 0;
    public string alreadyWinner = "";
    public int weatherPoints = 0;
    public string[] positions = {"Melee", "Distance", "Asedium", "MeleeIncrease", "DistanceIncrease", "AsediumIncrease"};
}
