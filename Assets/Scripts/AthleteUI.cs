using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AthleteUI : MonoBehaviour
{
    public Athlete athlete;

    public TextMeshProUGUI nameText;
    public Image image;
    public TextMeshProUGUI statAText;
    public TextMeshProUGUI statBText;

    public void SetAthlete(Athlete a)
    {
        athlete = a;

        nameText.text = a.name;
        //img
        //stat A
        //stat B
    }
}
