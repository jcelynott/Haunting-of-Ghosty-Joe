using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Animates the progress bar
/// </summary>
public class ProgressBarHandler : MonoBehaviour
{
    public Sprite[] sprites;
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[27 * (GameData.wordsCompleted)/(GameData.wordsNeeded)];
        if (GameData.wordsCompleted == GameData.wordsNeeded)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
