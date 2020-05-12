using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class to check for button presses and determine if they are single or double presses
/// </summary>

public abstract class ButtonChecker : MonoBehaviour
{
    bool coRunning = false, doingDouble = false;
    //Hide cursor at start of game, and ensure the space bar isn't locked
    private void Awake()
    {
        Cursor.visible = false;
        GameData.controlLocked = false;
    }

    //Scan for button presses every frame
    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameData.controlLocked == false)
        {
            if (!coRunning)
                StartCoroutine(ButtonTimer());
            else
            {
                DoublePress();
                doingDouble = true;
            }
        }  
    }
    
    //Used to tell if the space between presses is small enough to constitute a double press
    IEnumerator ButtonTimer() 
    {
        float timeStart = Time.time;
        Debug.Log("Start CO");
        coRunning = true;
        yield return new WaitForSeconds(GameData.buttonTimeGrace);
        coRunning = false;
        if (!doingDouble)
        {
            Debug.Log("Start SP: Delta Time: " + (timeStart - Time.time));
            SinglePress();
        }
        else
        {
            doingDouble = false;
        }
    }

    protected virtual void SinglePress()
    {
        Debug.Log("single");
    }

    protected virtual void DoublePress()
    {
        Debug.Log("double");
    }
}
