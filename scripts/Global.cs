using Godot;
using System;

public class Global : Node
{
    public string current_player = "templars";
    public bool hasPlay = false;
    public TemplarsCards templarsCards = new TemplarsCards();
    public RomansCards romansCards = new RomansCards();
    public int templarsPoints = 0;
    public int romansPoints = 0;
}
