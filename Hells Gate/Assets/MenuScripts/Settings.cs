using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer am;

    public void SetVolume (float volume)
    {
        am.SetFloat("GameVolume", volume);
    }
}
