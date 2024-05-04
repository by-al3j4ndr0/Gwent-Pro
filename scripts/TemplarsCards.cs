using Godot;
using System;

public class TemplarsCards : Node
{
    public string[] leader = {"leader", "Sir. Jacques de Molay", "Leader", "", "10", "Leader of Templars"};
    public static string[] leonheart = {"leonheart", "Eduard Leonheart", "Melee", "gold", "8", "Con su gran fuerza \ndestroza a todos los \nenemigos"};
    public static string[] the_hood = {"the_hood", "The Hood", "Distance", "old", "8", "Donde pone el ojo \npone una flecha"};
    public static string[] simple_soldier = {"simple_soldier", "Soldier", "Melee", "silver", "3", "Soldado de infaneria. \nSimple pero valioso"};
    public static string[] the_fog = {"the_fog", "Battle Fog", "Weather", "", "4", "Neblina en el campo \n de batalla, podria \ndificultar la vision"};
    public static string[] priest = {"priest", "Priest", "Increase", "", "2", "La fe puede mover \nmontanas o aumentar \nel poder de las tropas"};
    public static string[] sun_horizon = {"sun_horizon", "Sun Horizon", "Clearance", "", "0", "Un dia soleado puede \nacabar con cualquier \nmal clima"};
    public static string[] catapult = {"catapult", "Catapult", "Asedium", "gold", "8", "Un objetivo nunca \nesta lo sificiente \nlejos"};
    public static string[] archer = {"archer", "Infantery Archer", "Distance", "silver", "3", "No necesita estar \ncerca ara acabar \ncon un enemigo"};
    public static string[] battle_ram = {"battle_ram", "Battle Ram", "Asedium", "silver", "4", "Una bestia en el \ncombate. Nada \nsobrevive a su paso"};
    public static string[] ghost_armoured = {"ghost_armoured", "Ghost Armoured", "Bait", "", "0", "Un fantasma tan real \nque podria confundirse \ncon algun ser vivo"};
    public static string[] communion = {"communion", "The Comunnion", "Increase", "", "2", "El cuerpo de cristo \nda poder a quien \nlo consuuma"};
    public static string[] stormy = {"stormy", "The Storm", "Weather", "", "4", "Una tormenta llega \npuede traer problemas \nen el campo"};

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
        ghost_armoured,
        communion,
        stormy
    };
}