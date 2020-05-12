using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Randomly spawns dangers to spawn at random times and checks if the player is hidden when they strike
/// </summary>
public class DangerSpawner : MonoBehaviour
{
    GameObject spookOne, spookTwo, spookThree, flowerBad, flowerGood, clock, deathItems;
    public AudioClip deathSound;
    void Start()
    {
        spookOne = GameObject.Find("spook1");
        spookTwo = GameObject.Find("spook2");
        spookThree = GameObject.Find("spook3");
        flowerBad = GameObject.Find("badFlower");
        flowerGood= GameObject.Find("flower");
        clock = GameObject.Find("clockAnimated");
        deathItems = GameObject.Find("deathItems");
        deathItems.SetActive(false);
        InvokeRepeating("DangerChecker", GameData.turnLength * GameData.gracePeriod, GameData.turnLength);
        ResetAllSpooks();
    }

    void DangerChecker()
    {
        if ((GameData.isDangerTurn && !GameData.isHidden) || (GameData.turncount == GameData.turnNumber))
        {
            StartCoroutine("Die");
        }
        GameData.turnNumber++;
        float ourValue = Random.Range(0, 1f);
        if (GameData.isDangerTurn)
            GameData.lastTurnDanger = true;
        else
            GameData.lastTurnDanger = false;
        ResetAllSpooks();
        Debug.Log("Last turn was danger: " + GameData.lastTurnDanger);
        if (ourValue < GameData.spawnRate && !GameData.lastTurnDanger)
        {
            SpawnDanger();
        }
        else
            GameData.isDangerTurn = false;
    }

    void SpawnDanger()
    {
        GameData.isDangerTurn = true;
        int dangerType = Random.Range(0, 5); 
        switch (dangerType) //Randomly choose which danger is spawned
        {
            case 0:
                SpawnSpookOne();
                break;
            case 1:
                SpawnSpookTwo();
                break;
            case 2:
                SpawnSpookThree();
                break;
            case 3:
                SpawnFlower();
                break;
            case 4:
                SpawnClock();
                break;
        }
    }

    void SpawnSpookOne()
    {
        spookOne.SetActive(true);
    }

    void SpawnSpookTwo()
    {
        spookTwo.SetActive(true);
    }

    void SpawnSpookThree()
    {
        spookThree.SetActive(true);
    }

    void SpawnFlower()
    {
        flowerBad.SetActive(true);
        flowerGood.SetActive(false);
    }

    void SpawnClock()
    {
        clock.GetComponent<Animator>().SetBool("isActive", true);
    }

    //Disables all the threats to ensure none are active
    private void ResetAllSpooks()
    {
        GameData.isDangerTurn = false;
        spookOne.SetActive(false);
        spookTwo.SetActive(false);
        spookThree.SetActive(false);
        flowerBad.SetActive(false);
        flowerGood.SetActive(true);
        clock.GetComponent<Animator>().SetBool("isActive", false);
    }

    //Plays the death "cutscene" before going to the actual game over screen
    public IEnumerator Die()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(deathSound);
        GameData.controlLocked = true;
        deathItems.SetActive(true);
        GameObject.Find("JoeStaff").SetActive(false);
        GameObject.Find("LatinText").GetComponent<Text>().text = "";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("DeathScene");
    }
}
