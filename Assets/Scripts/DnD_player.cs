//Levan Badzgaradze for CS583
using System.Collections;
using System.Collections.Generic;

public class DnD_player
{
    public string char_name;
    public int ability_strength, ability_dexterity, ability_constitution, ability_intelligence, ability_wisdom, ability_charisma;
    public int strenght_modifier = 2, dexterity_modifier = 2, constitution_modifier = 2, intelligence_modifier = 2, wisdom_modifier = 2, charisma_modifier = 2;
    public string char_race, char_class, char_alignment = "";
    public int experience_points_current = 0;
    public int experience_points_max = 35500;
    public int hit_point_current = 0, hit_point_max = 0;
    public int armor_class;
    public int speed_walking, speed_jumping, speed_running;
    public string[] items = {};


    //walking speed determined by race
    static Dictionary<string, int> walking_spead_race = new Dictionary<string, int>
    {
            { "Dragonborn", 30 },
            { "Dwarf", 25 },
            { "Elf", 30 },
            { "Gnome", 25 },
            { "Half-Elf", 30 },
            { "Half-Orc", 30 },
            { "Halfling", 25 },
            { "Human", 30 },
            { "Tiefling", 30 }
    };

    //die type determined by class
    static Dictionary<string, int> die_type_class = new Dictionary<string, int>
    {
            { "Barbarian", 12 },
            { "Bard", 8 },
            { "Cleric", 8 },
            { "Druid", 8 },
            { "Fighter", 10 },
            { "Monk", 8 },
            { "Paladin", 10 },
            { "Ranger", 10 },
            { "Rogue", 8 },
            { "Sorcerer", 6},
            { "Warlock", 8 },
            { "Wizard", 6 }

    };

    public DnD_player(string name, string char_race, string char_class, string char_alignment, 
        int ability_strenght, int ability_dextirity, int ability_constitution, int ability_intelligence, int ability_wisdom, int ability_charisma)
    {
        this.char_name = name;
        this.char_race = char_race;
        this.char_class = char_class;
        this.char_alignment = char_alignment;
        this.ability_strength = ability_strenght;
        this.ability_dexterity = ability_dextirity;
        this.ability_constitution = ability_constitution;
        this.ability_intelligence = ability_intelligence;
        this.ability_wisdom = ability_wisdom;
        this.ability_charisma = ability_charisma;
        this.armor_class = dexterity_modifier + 10;
        this.speed_walking = char_race == null ? 0 : walking_spead_race[char_race];
        this.speed_running = this.speed_walking * 3 / 2; //made-up factor
        this.speed_jumping = this.speed_walking * 2 / 3; //made-up factor
        this.hit_point_max = char_class == null ? 0 : die_type_class[char_class] + dexterity_modifier;
        this.hit_point_current = this.hit_point_max;
    }

    public string json_output()
    {
        return UnityEngine.JsonUtility.ToJson(this);
    }




}
