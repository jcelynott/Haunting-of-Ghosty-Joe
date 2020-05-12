using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Script to play and control the death "jumpscare"
/// </summary>
public class DeathSceneManager : MonoBehaviour
{
    public AudioClip[] jumpSounds;
    GameObject joe;
    
    //Due to lack of button checker on this scene, we need to make sure the cursor is disabled
    private void Awake() 
    {
        Cursor.visible = false;
    }

    void Start()
    {
        joe = GameObject.Find("GhostyJoe");
        joe.SetActive(false);
        StartCoroutine("Spooker");
    }

    //Do jumpscare after time
    IEnumerator Spooker()
    {
        yield return new WaitForSeconds(4.1f);
        joe.SetActive(true);
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(jumpSounds[Random.Range(0, jumpSounds.Length)]);
        yield return new WaitForSeconds(3);
        GameData.controlLocked = false;
        SceneManager.LoadScene("IntroScene");
    }
}
