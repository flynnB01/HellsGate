using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;

    public void SetMaxEnergy(int energy) // Sets Maximum Energy (can be used in junction with level system)
    { // Prolly use this function when starting new level
        slider.maxValue = energy;
        slider.value = energy;
    }

    public void SetEnergy(int energy) // Sets energy
    {
        slider.value = energy;
    }
}
