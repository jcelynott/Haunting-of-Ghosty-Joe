using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Timer that plays on the difficulty selection screen
/// </summary>
public class DiffTimerScript : MonoBehaviour
{
    int time = 15;
    void Start()
    {
        StartCoroutine(Timer());
    }

    private void Update()
    {
        if(time != -1 && !GetComponent<Text>().text.Equals(""))
            GetComponent<Text>().text = "" + time;

    }

    IEnumerator Timer()
    {
        while (time != -1)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
        GetComponent<Text>().text = "";
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("Codes").GetComponent<ButtonCheckDifficulty>().StartGameWrapper();       
    }
}
