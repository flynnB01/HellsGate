using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions; // Resolution array for collecting all resolution types
    private List<Resolution> filteredResolutions;

    private float currentRefreshRate;
    private int currentResIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        resolutionDropdown.ClearOptions(); // Clears all resolutions
        currentRefreshRate = (float)Screen.currentResolution.refreshRateRatio.value; // Takes screen's current res and refresh rate as default

        for (int i = 0; i < resolutions.Length; i++)
        {
            if ((float)resolutions[i].refreshRateRatio == currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        filteredResolutions.Sort((a, b) => 
        {
            if(a.width != b.width)
            return b.width.CompareTo(a.width);
            else
            return b.height.CompareTo(a.height);
        });

        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string resolutionOption =
            filteredResolutions[i].width + "x" +
            filteredResolutions[i].height + " " +
            filteredResolutions[i].refreshRateRatio.value.ToString("0.##") + " Hz";
            options.Add(resolutionOption);
            if (filteredResolutions[i].width == Screen.width && 
            filteredResolutions[i].height == Screen.height && 
            (float)filteredResolutions[i].refreshRateRatio.value == currentRefreshRate);
            {
                currentResIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIndex = 0;
        resolutionDropdown.RefreshShownValue();
        SetResolution(currentResIndex);
        
    }

    public void SetResolution(int resolutionIndex)
    {
        resolutionDropdown resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
}
