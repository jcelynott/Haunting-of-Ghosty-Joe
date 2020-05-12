using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Button checker for the intro scene
/// </summary>
public class ButtonCheckerIntro : ButtonChecker
{
    private void Start()
    {
        GameData.ResetData(); //Always reset data during the intro
    }

    protected override void SinglePress()
    {
        SceneManager.LoadScene("DiffScene"); //Load difficulty selection scene
    }

    protected override void DoublePress()
    {
        //This remains active for the desktop version, but not for the WebGL version
        //Application.Quit();
    }
}
