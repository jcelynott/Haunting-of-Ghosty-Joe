using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Simple timer to make the appearance of text cleaner and more dynamic
/// </summary>
public class WinSceneManager : MonoBehaviour
{
    GameObject text;
    void Start()
    {
        text = GameObject.Find("text");
        StartCoroutine("StartText");
    }

    // Update is called once per frame
    IEnumerator StartText()
    {
        yield return new WaitForSeconds(2);
        text.GetComponent<Text>().text = "And so GHOSTY JOE was forced from the mansion, and the old Baron could enjoy a good night's rest.";
        yield return new WaitForSeconds(2);
        text.GetComponent<Text>().text += "\n\nTap the spacebar one to restart";
    }
}
