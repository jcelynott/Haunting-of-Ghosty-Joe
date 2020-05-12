using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Script to ensure music play is seamless from the main menu to the difficulty selection script
/// </summary>
public class MusicBoxScript : MonoBehaviour
{
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("MainScene"))
            Destroy(gameObject);
    }
}
