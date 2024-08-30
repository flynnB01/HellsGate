using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health) // Sets Maximum Health (can be used in junction with level system)
    { // Prolly use this function when starting new level
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health) // Sets health
    {
        slider.value = health;
    }
}
