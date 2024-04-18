using Godot;
using System;

public class TemplarsCards : Node
{
    public static string[] leader = {"leader", "Sir. Jacques de Molay", "leader", "", "10", "Leader of Templars"};
    public static string[] leonheart = {"leonheart", "Eduard Leonheart", "melee", "gold", "8", "Con su gran fuerza \ndestroza a todos los \nenemigos"};
    public static string[] the_hood = {"the_hood", "The Hood", "distance", "gold", "8", "Donde pone el ojo \npone una flecha"};
    public static string[] simple_soldier = {"simple_soldier", "Soldier", "melee", "silver", "3", "Soldado de infaneria. \nSimple pero valioso"};
    public static string[] the_fog = {"the_fog", "Battle Fog", "weather", "", "4", "Neblina en el campo \n de batalla, podria \ndificultar la vision"};
    public static string[] priest = {"priest", "Priest", "increase", "", "2", "La fe puede mover \nmontanas o aumentar \nel poder de las tropas"};
    public static string[] sun_horizon = {"sun_horizon", "Sun Horizon", "clearance", "", "", "Un dia soleado puede \nacabar con cualquier \nmal clima"};
    public static string[] catapult = {"catapult", "Catapult", "asedium", "gold", "8", "Un objetivo nunca \nesta lo sificiente \nlejos"};
    public static string[] archer = {"archer", "Infantery Archer", "distance", "silver", "3", "No necesita estar cerca \npara acabar con \nun enemigo"};
    public static string[] battle_ram = {"battle_ram", "Battle Ram", "asedium", "silver", "4", "Una bestia en el \ncombate. Nada sobrevive \na su paso"};

    public Godot.Collections.Array<string[]> name = new Godot.Collections.Array<string[]>{
        leonheart,
        the_hood,
        simple_soldier,
        the_fog,
        priest,
        sun_horizon,
        catapult,
        archer,
        battle_ram,
        leader
    };
}