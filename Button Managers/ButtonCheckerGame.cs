using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Button checker for the actual gameplay
/// </summary>
public class ButtonCheckerGame : ButtonChecker
{
    bool canPress = false;
    GameObject blackness;
    string[] latinWords = new[]{"Quis semel indicavit mihi mundus", "Est iens ut esse mali",
"Veni ad me orbem", "Terrarum non nocuerunt mihi", "Dixit muta essem", "Et apparuit ad esse muta", "In annis, iter ultra", "Usque in sempiternum ", "Ego pavit ad lupi sed fuit", "Est iniuria non quaerat voluptatem", "Et facti dolor",  "Et perdet sapientiam", "Illic est adeo videre", "Et facite ei", "Quid iniuriam", "Sola viarum vedi?", "Et si non tu noli quaerere", "Si tu non fulgebunt neque meridiem",
"Magna es", "Mirabilis es tu", "Estote parati semper", "Ludere vade" };
    Text t;
    public AudioClip[] chants;

    private void Start()
    {
        t = GameObject.Find("LatinText").GetComponent<Text>();
        blackness = GameObject.Find("blackness");
        blackness.SetActive(false);
        newWord();
    }

    protected override void Update()
    {
        base.Update();
    }
    protected override void SinglePress()
    {
        if (!GameData.isHidden)
        {
            if (canPress)
            {
                GameData.wordsCompleted++;
            }
            else
            {
                if (GameData.wordsCompleted > 0)
                    GameData.wordsCompleted--;
            }
            newWord();
        }
    }

    void newWord()
    {
        t.text = latinWords[Random.Range(0, latinWords.Length - 1)];
        t.color = Color.black;
        Invoke("ChangeColor", Random.Range(1f, 5f));
        canPress = false;
        if(Time.timeSinceLevelLoad > 0.3f && GameData.wordsCompleted != GameData.wordsNeeded)
            GameObject.Find("oldMan").GetComponent<AudioSource>().PlayOneShot(chants[Random.Range(0, chants.Length)]);
    }

    void ChangeColor()
    {
        t.color = Color.white;
        canPress = true;
    }

    protected override void DoublePress()
    {
        blackness.SetActive(!blackness.activeSelf);
        GameData.isHidden = blackness.activeSelf;
    }
}
