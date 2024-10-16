using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DashBar : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public Slider slider;

    public void SetMaxCooldown(float cd) // Sets Maximum Energy (can be used in junction with level system)
    { // Prolly use this function when starting new level
        slider.maxValue = cd;
        slider.value = cd;
    }

    public void SetCooldown(float cd) // Sets energy
    {
        slider.value = cd;
    }
}

