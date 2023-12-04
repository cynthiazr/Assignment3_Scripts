using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/*
Used info/syntax from this source: https://www.youtube.com/watch?v=Cq_Nnw_LwnI
*/

public class MenuController : MonoBehaviour
{
    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;

    [Header("Graphics Settings")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessTextValue = null;
    [SerializeField] private float defaultBrightness = 1;

    private float _brightnessLevel;

    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;
    
    [Header("Levels to Load")]
    public string _newGameLevel; // We are going to run this when we create a new game
    private int levelToLoad; // We load our level when we need it
    [SerializeField] private GameObject noSavedGameDialog = null;

    public void NewGameDialogYes()
    {
        if(PlayerPrefs.HasKey("SavedLevel"))
        {
            PlayerPrefs.DeleteKey("SavedLevel");
        }
        SceneManager.LoadScene(_newGameLevel); // Load the scene when we ask it to

    }

    public void LoadGameDialogYes()
    {
        if(PlayerPrefs.HasKey("SavedLevel")) // Check if we have a file that says "SavedLevel"
        {
            levelToLoad = PlayerPrefs.GetInt("SavedLevel");
            SceneManager.LoadScene(levelToLoad);

        }
        else
        {   // if we dont have anything to load, then we want to Pop the NoSaveGame Dialog
            noSavedGameDialog.SetActive(true);
        }
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene(1); // Will open the Tutorial scene 
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitButton()
    {
        Application.Quit(); // Exit the Game
    }

    public void SetVolume(float volume) // it will change all the audio of the game
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0"); // Whenever we change the value, it will update it in the game
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    public void SetBrightness(float brightness)
    {
        _brightnessLevel = brightness;
        brightnessTextValue.text = brightness.ToString("0.0");
    }

    public void GraphicsApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", _brightnessLevel);

        StartCoroutine(ConfirmationBox());
    }
    public void ResetButton(string MenuType)
    {
        if (MenuType == "Graphics")
        {
            brightnessSlider.value = defaultBrightness;
            brightnessTextValue.text = defaultBrightness.ToString("0.0");
            GraphicsApply();
        }
        if(MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeTextValue.text = defaultVolume.ToString("0.0");
            VolumeApply();
        }
    }

    // When we press apply in our volume setting, we will confirm that it happen
    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
