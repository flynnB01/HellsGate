using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsResolution : MonoBehaviour
{
    // Dropdown for selecting resolution in the UI
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    // Array to hold all available screen resolutions
    private Resolution[] resolutions;
    // List to hold filtered resolutions based on current refresh rate
    private List<Resolution> filteredResolutions;

    // Store the current refresh rate of the screen
    private float currentRefreshRate;
    // Index of the currently selected resolution in the dropdown
    private int currentResolutionIndex = 0;

    void Start()
    {
        // Get all available screen resolutions
        resolutions = Screen.resolutions;
        // Initialize the list to hold filtered resolutions
        filteredResolutions = new List<Resolution>();

        // Clear any existing options in the dropdown
        resolutionDropdown.ClearOptions();
        // Get the current refresh rate
        currentRefreshRate = (float)Screen.currentResolution.refreshRateRatio.value;

        // Log the current refresh rate for debugging
        Debug.Log("Refresh Rate: " + currentRefreshRate);

        // Filter resolutions to match the current refresh rate
        for (int i = 0; i < resolutions.Length; i++)
        {
            // Only add resolutions that match the current refresh rate
            if ((float)resolutions[i].refreshRateRatio.value == currentRefreshRate) 
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        // Sort filtered resolutions by width (descending) and height (descending)
        filteredResolutions.Sort((a, b) => {
            if (a.width != b.width)
                return b.width.CompareTo(a.width);
            else
                return b.height.CompareTo(a.height);
        });

        // Prepare options for the dropdown
        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            // Format the resolution string to display in the dropdown
            string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRateRatio.value.ToString("0.##") + " Hz";
            options.Add(resolutionOption);

            // Set the current resolution index if it matches the screen's current resolution
            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height && (float)filteredResolutions[i].refreshRateRatio.value == currentRefreshRate)
            {
                currentResolutionIndex = i; // Update the current resolution index
            }
        }

        // Add the filtered resolution options to the dropdown
        resolutionDropdown.AddOptions(options);
        // Set the dropdown value to the current resolution index
        resolutionDropdown.value = currentResolutionIndex;
        // Refresh the dropdown to show the correct selected value
        resolutionDropdown.RefreshShownValue();
        // Set the screen resolution based on the current selection
        SetResolution(currentResolutionIndex);
    }

    // Method to change the screen resolution based on the selected index
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
        Debug.Log("Resolution set to " + resolution.width + "x " + resolution.height + "x");
    }
}
