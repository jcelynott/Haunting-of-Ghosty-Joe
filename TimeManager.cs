using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    int lastTurnCount;
    string timeValue, lastVal = "It is midnight";
    public AudioClip dong;
    Text timerText;

    private void Start()
    {
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        float percentLeft = (float) GameData.turnNumber / GameData.turncount;
        int percentRounded = Mathf.FloorToInt(percentLeft * 100);
        if (percentRounded < 16)
            timerText.text = "It is midnight";
        else if (percentRounded < 33)
            timerText.text = "It is half past midnight";
        else if (percentRounded < 50)
            timerText.text = "It is one in the morning";
        else if (percentRounded < 66)
            timerText.text = "It is  half past one in the morning";
        else if (percentRounded < 83)
            timerText.text = "It is two in the morning";
        else if (percentRounded < 100)
            timerText.text = "It is half past two in the morning";
        else
            timerText.text = "Abandon all hope!";
        if (!timerText.text.Equals(lastVal))
        {
            GetComponent<AudioSource>().PlayOneShot(dong); //Play sound of bell ringing if the clock changes over
        }
        lastVal = timerText.text;
    }

   
}
