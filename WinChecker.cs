using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Change the scene to the victory scene if you meet the victory conditions
/// </summary>
public class WinChecker : MonoBehaviour
{
    void Update()
    {
        if (GameData.wordsCompleted == GameData.wordsNeeded)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
