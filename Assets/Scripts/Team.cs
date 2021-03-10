using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
    public string name;
    public List<Athlete> roster = new List<Athlete>();

    public Team(string teamName)
    {
        name = teamName;

        for(int i = 0; i < 5; i++)
        {
            roster.Add(new Athlete());
        }
    }
}
