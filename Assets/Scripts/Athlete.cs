using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Athlete
{
    public string name;

    public Sprite sprite;

    //qualities

    //attributes
    public List<Attribute> attributes = new List<Attribute>();

    //stats
    public List<Stat> stats = new List<Stat>();

    public Athlete()
    {
        name = "Jimmy";
        //generate everything randomly


        foreach(AttributeType at in Enum.GetValues(typeof(AttributeType)))
        {
            attributes.Add(new Attribute(at));
        }

        foreach(StatType st in Enum.GetValues(typeof(StatType)))
        {
            stats.Add(new Stat(st));
        }
    }

    public Attribute GetAttribute(AttributeType attributeType)
    {
        Attribute atty = null;
        for(int i = 0; i < attributes.Count; i++)
        {
            if(attributes[i].attributeType == attributeType)
            {
                atty = attributes[i];
            }
        }

        return atty; //Maybe value instead - depends what I'm using this for
    }

    public void IncrementStat(StatType type)
    {
        GetStat(type).value++;
    }

    public Stat GetStat(StatType statType)
    {
        Stat stat = null;
        for (int i = 0; i < stats.Count; i++)
        {
            if (stats[i].statType == statType)
            {
                stat = stats[i];
            }
        }

        return stat;
    }
}
