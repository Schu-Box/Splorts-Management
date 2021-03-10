using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    PassesAttempted,
    PassesCompleted,
    Assists,
    ShotsAttempted,
    //ShotsOnTarget,
    Goals,
    Steals,
    Saves
}

public class Stat 
{
    public StatType statType;
    public int value;

    public Stat(StatType type)
    {
        statType = type;
        value = 0;
    }
}
