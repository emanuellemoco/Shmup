using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // public static AudioClip hitSound, jumpSound, gameSound, winSound, endSound;
    public static AudioClip metalSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        metalSound = Resources.Load<AudioClip>("metal_collision");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound (string clip)
    {
            switch(clip){
            case "metal":
                audioSrc.PlayOneShot (metalSound);
                break;
            // case "jump":
            //     audioSrc.PlayOneShot (jumpSound);
            //     break;
            // case "music_game":
            //     audioSrc.PlayOneShot (gameSound);
            //     break;
            // case "win":
            //     audioSrc.PlayOneShot (winSound);
            //     break;
            // case "end":
            //     audioSrc.PlayOneShot (endSound);
            //     break;
        }
    }
}
