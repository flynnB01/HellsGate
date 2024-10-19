using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class SFXPlayer : MonoBehaviour
{
    public AudioMixer mixer;

    public AudioSource src;
    public AudioClip sfx01, sfx02, sfx03;

    public void SetVolume(float volume)
    {
        mixer.SetFloat("GameVolume", volume);
    }

    public void PlaySFX(AudioClip sfx)
    {
        src.PlayOneShot(sfx);
    }
    

}
