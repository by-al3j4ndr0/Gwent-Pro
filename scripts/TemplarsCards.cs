using Godot;
using System;

public class TemplarsCards : Node
{
    public string[] leader = {"leader", "Sir. Jacques de Molay", "Leader", "", "10", "Leader of Templars"};
    public static string[] leonheart = {"leonheart", "Eduard Leonheart", "Melee", "gold", "8", "Con su gran fuerza \ndestroza a todos los \nenemigos"};
    public static string[] the_hood = {"the_hood", "The Hood", "Distance", "old", "8", "Donde pone el ojo \npone una flecha"};
    public static string[] simple_soldier = {"simple_soldier", "Soldier", "Melee", "silver", "3", "Soldado de infaneria. \nSimple pero valioso"};
    public static string[] the_fog = {"the_fog", "Battle Fog", "Weather", "", "4", "Neblina en el campo \n de batalla, podria \ndificultar la vision"};
    public static string[] priest = {"priest", "Priest", "MeleeIncrease", "", "2", "La fe puede mover \nmontanas o aumentar \nel poder de las tropas"};
    public static string[] sun_horizon = {"sun_horizon", "Sun Horizon", "Clearance", "", "", "Un dia soleado puede \nacabar con cualquier \nmal clima"};
    public static string[] catapult = {"catapult", "Catapult", "Asedium", "gold", "8", "Un objetivo nunca \nesta lo sificiente \nlejos"};
    public static string[] archer = {"archer", "Infantery Archer", "Distance", "silver", "3", "No necesita estar \ncerca ara acabar \ncon un enemigo"};
    public static string[] battle_ram = {"battle_ram", "Battle Ram", "Asedium", "silver", "4", "Una bestia en el \ncombate. Nada \nsobrevive a su paso"};

    public Godot.Collections.Array<string[]> name = new Godot.Collections.Array<string[]>{
        leonheart,
        the_hood,
        simple_soldier,
        the_fog,
        priest,
        sun_horizon,
        catapult,
        archer,
        battle_ram
    };
}