using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match
{
    public Team homeTeam;
    public Team awayTeam;

    private Team offense;
    private Team defense;

    private int homeScore;
    private int awayScore;

    private int possessions = 0;
    private int maxPossessions = 100;

    public Match(Team home, Team away)
    {
        homeTeam = home;
        awayTeam = away;

        StartMatch();
    }

    public void StartMatch()
    {
        NewPossession(homeTeam);
    }

    public void NewPossession(Team newOffense)
    {
        possessions++;

        if(possessions > maxPossessions)
        {
            EndMatch();
        }
        else
        {
            if (newOffense == homeTeam)
            {
                offense = homeTeam;
                defense = awayTeam;
            }
            else
            {
                offense = awayTeam;
                defense = homeTeam;
            }

            Athlete initiator = offense.roster[Random.Range(0, offense.roster.Count)];

            NewPlay(initiator);
        }
    }

    public void NewPlay(Athlete possessor)
    {
        //Choose to shoot or pass
        if (Random.value > 0.5f)
        {
            AttemptPass(possessor);
        }
        else
        {
            AttemptShot(possessor);
        }
    }

    public void AttemptPass(Athlete passer)
    {
        Athlete receiver = passer;
        Athlete defender = defense.roster[Random.Range(0, defense.roster.Count)];

        while(receiver == passer)
        {
            receiver = offense.roster[Random.Range(0, offense.roster.Count)];
        }

        passer.IncrementStat(StatType.PassesAttempted);

        float passRoll = Random.value * passer.GetAttribute(AttributeType.Passing).value;
        float defenseRoll = Random.value * defender.GetAttribute(AttributeType.Defending).value;
        if(passRoll >= defenseRoll)
        {
            PassSuccess(passer, receiver);
        }
        else
        {
            PassFailure(passer, defender);
        }
    }

    public void PassSuccess(Athlete passer, Athlete receiver)
    {
        //Debug.Log("pass success");

        passer.IncrementStat(StatType.PassesCompleted);

        NewPlay(receiver);
    }

    public void PassFailure(Athlete passer, Athlete stealer)
    {
        //Debug.Log("pass failure");

        stealer.IncrementStat(StatType.Steals);

        NewPossession(defense);
    }

    public void AttemptShot(Athlete shooter)
    {
        Athlete defender = defense.roster[Random.Range(0, defense.roster.Count)];

        shooter.IncrementStat(StatType.ShotsAttempted);

        float shotRoll = Random.value * shooter.GetAttribute(AttributeType.Shooting).value;
        float defenseRoll = Random.value * defender.GetAttribute(AttributeType.Defending).value;

        if(shotRoll > defenseRoll)
        {
            ShotSuccess(shooter);
        }
        else
        {
            ShotFailure(shooter, defender);
        }
    }

    public void ShotSuccess(Athlete shooter)
    {
        //Debug.Log("shot success");

        shooter.IncrementStat(StatType.Goals);

        if (offense == homeTeam)
            homeScore++;
        else
            awayScore++;

        Debug.Log("GOAL! " + homeScore + " to " + awayScore);

        NewPossession(defense);
    }

    public void ShotFailure(Athlete shooter, Athlete defender)
    {
        //Debug.Log("shot failure");

        defender.IncrementStat(StatType.Saves);

        NewPossession(defense);
    }

    public void EndMatch()
    {
        Debug.Log("Match is now over");
    }
}
