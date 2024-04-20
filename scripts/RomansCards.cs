using Godot;
using System;

public class RomansCards : Node
{
    public string[] leader = {"leader", "Romulus Augustus", "Leader", "", "10", "Emperator of Romans"};
    public static string[] maximo_decimo = {"maximo_decimo", "Maximo Decimo", "Melee", "gold", "8", "Commander of the \nforces. Always in the \nvanguard"};
    public static string[] legionar = {"legionar", "Legionar Soldier", "Melee", "silver", "4", "A simple soldier \nwith too much \nenergy"};
    public Godot.Collections.Array<string[]> name = new Godot.Collections.Array<string[]>{
        maximo_decimo,
        legionar
    };
}
