using UnityEngine;
/// <summary>
/// Script to play a tick sound synchronized with the actual movement of the hands of the clock
/// </summary>
public class ClockSoundScript : MonoBehaviour
{
    public AudioClip tick;
    string lastSprite = "";

    void Update()
    {
        if (!lastSprite.Equals(GetComponent<SpriteRenderer>().sprite.name))
        {
            GetComponent<AudioSource>().PlayOneShot(tick);
        }
        lastSprite = GetComponent<SpriteRenderer>().sprite.name;
    }
}
