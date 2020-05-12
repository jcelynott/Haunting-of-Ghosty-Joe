using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Script to create and clear the text indicating that it is safe to unhide
/// </summary>
public class SafetyTextManager : MonoBehaviour
{
    Text t;
    int lastTurn;
    void Start()
    {
        t = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameData.isHidden)
        {
            t.text = "";
        }
        else
        {
            if (!GameData.isDangerTurn && GameData.lastTurnDanger)
                t.text = "You feel the presence of GHOSTY JOE leave the room!";
        }
    }
}
