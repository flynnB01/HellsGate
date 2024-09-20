using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxExp(int exp) // Sets Maximum Health (can be used in junction with level system)
    { // Prolly use this function when starting new level
        slider.maxValue = exp;
        slider.value = exp;
    }

    public void SetExp(int exp) // Sets health
    {
        slider.value = exp;
    }

    public void IncreaseMaxExp(int exp)
    {
        slider.maxValue += exp;
    }
}
