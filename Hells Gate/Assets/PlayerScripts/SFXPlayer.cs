using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx01, sfx02, sfx03;

    public void PlaySFX(AudioClip sfx)
    {
        src.PlayOneShot(sfx);
    }
    

}
