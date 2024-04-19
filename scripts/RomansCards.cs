using Godot;
using System;

public class RomansCards : Node
{
    public static string[] leader = {"leader", "Romulus Augustus", "leader", "", "10", "Emperator of Romans"};
    public static string[] maximo_decimo = {"maximo_decimo", "Maximo Decimo", "melee", "gold", "8", "Commander of the \nforces. Always in the \nvanguard"};
    public static string[] legionar = {"legionar", "Legionar Soldier", "melee", "silver", "4", "A simple soldier \nwith too much \nenergy"};
    public Godot.Collections.Array<string[]> name = new Godot.Collections.Array<string[]>{
        leader,
        maximo_decimo,
        legionar
    };
}
