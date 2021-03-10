using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    public Transform athleteHolder;
    public GameObject athleteUIPrefab;

    public void ClearAthleteHolder()
    {
        for(int i = athleteHolder.childCount - 1; i >= 0; i--)
        {
            Destroy(athleteHolder.GetChild(i).gameObject);
        }
    }

    public void DisplayMatchResults(List<Athlete> athletes)
    {
        ClearAthleteHolder();

        for (int i = 0; i < athletes.Count; i++)
        {
            GameObject newAthleteUI = Instantiate(athleteUIPrefab, athleteHolder);

            newAthleteUI.GetComponent<AthleteUI>().SetAthlete(athletes[i]);
        }
    }
}
