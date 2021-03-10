using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Team> teams = new List<Team>();

    private InterfaceController interfaceController;

    private void Start()
    {
        interfaceController = FindObjectOfType<InterfaceController>();

        teams.Add(new Team("Brimstone Ballers"));
        teams.Add(new Team("Old Zeelanders"));

        Match newMatch = new Match(teams[0], teams[1]);

        Debug.Log("idk what it do");

        //Will this work? Is this okay?
        MatchCompleted(newMatch);
    }

    public void MatchCompleted(Match match)
    {
        Debug.Log("match complete");

        interfaceController.DisplayMatchResults(teams[0].roster);
    }
}
