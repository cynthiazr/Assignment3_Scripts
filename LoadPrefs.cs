using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
Used info/syntax from this source: https://www.youtube.com/watch?v=Cq_Nnw_LwnI
*/

// Save all the setting that have been saved before
public class LoadPrefs : MonoBehaviour
{
    [Header("General Setting")]
    [SerializeField] private bool canUse = false; // if we should load, or not load preferences
    [SerializeField] private MenuController menuController;

    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;

    [Header("Brightness Setting")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessTextValue = null;

    // This runs before any other method in game
    private void Awake()
    {
        if(canUse)
        {
            if(PlayerPrefs.HasKey("masterVolume"))
            {
                float localVolume = PlayerPrefs.GetFloat("masterVolume");

                volumeTextValue.text = localVolume.ToString("0.0");
                volumeSlider.value = localVolume;
                AudioListener.volume = localVolume;
            }
            else
            {
                menuController.ResetButton("Audio");
            }

            if(PlayerPrefs.HasKey("masterBrightness"))
            {
                float localBrightness = PlayerPrefs.GetFloat("masterBrightness");

                brightnessTextValue.text = localBrightness.ToString("0.0");
                brightnessSlider.value = localBrightness;
            }
        }
    }
}
