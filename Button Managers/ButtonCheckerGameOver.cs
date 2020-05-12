using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Button checker to handle game over interaction
/// </summary>
public class ButtonCheckerGameOver : ButtonChecker
{
    protected override void SinglePress()
    {
        SceneManager.LoadScene("IntroScene"); //Load intro scene
    }

    protected override void DoublePress()
    {
        //This remains active for the desktop version, but not for the WebGL version
        //Application.Quit();
    }
}
