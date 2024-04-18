using Godot;
using System;

public class RomansCards : Node
{
    public static string[] leader = {"leader", "Romulus Augustus", "leader", "gold", "10", "Emperator of Romans"};

    public Godot.Collections.Array<string[]> name = new Godot.Collections.Array<string[]>{
        leader
    };
}
