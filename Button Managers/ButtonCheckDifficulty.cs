using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
    
/// <summary>
/// Button checker during the difficulty selection process
/// </summary>
public class ButtonCheckDifficulty : ButtonChecker
{
    const int WORD_COUNT_EASY = 15;
    const int WORD_COUNT_MEDIUM = 27;
    const int WORD_COUNT_HARD = 40;

    private void Start()
    {
        //We'll default to the hard value if no other difficulty is assigned
        GameData.wordsNeeded = WORD_COUNT_HARD;
    }

    protected override void SinglePress()
    {
        GameData.wordsNeeded = WORD_COUNT_EASY;
        StartCoroutine("StartGame");
    }

    protected override void DoublePress()
    {
        GameData.wordsNeeded = WORD_COUNT_MEDIUM;
        StartCoroutine("StartGame");
    }

    //Access coroutine with a wrapper to make it callable
    public void StartGameWrapper()
    {
        StartCoroutine("StartGame");
    }

    IEnumerator StartGame()
    {
        GameObject.Find("introParchment").SetActive(false);
        GameData.controlLocked = true;
        GameObject.Find("Timer").GetComponent<Text>().text = "";
        GameObject.Find("Text").GetComponent<Text>().text = "LOADING...";
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("MainScene");
    }
}
