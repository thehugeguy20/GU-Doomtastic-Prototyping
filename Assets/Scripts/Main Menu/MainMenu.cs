using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;


public class MainMenu : MonoBehaviour
{

    //References the exposed master audiomixer
    public AudioMixer audioMixer;

    //References the available resolutions
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;
   
    void Start ()
    {
        //Establishes the resolutions variable as the available screen resolutions assigned by unity
        resolutions = Screen.resolutions;

        //clears default options
        resolutionDropdown.ClearOptions();

        //creates new list of strings containing available resolutions
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        //loops through available resolutions and adds them to the list(options)
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
            resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        //adds options list to resolution drop down
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void PlayGame()
    {
        //Loads the next available scene in the build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        //Closes the application
        Application.Quit();
        Debug.Log("Quit Application");
    }

    

    public void SetVolume (float volume)
    {
        //Sets the master audio mixer dB
        audioMixer.SetFloat("volume", volume);
    }


    //Does not work
    //public void SetQuality (int qualityIndex)
    //{
    //
    //    QualitySettings.SetQualityLevel(qualityIndex);
    // }

    public void SetFullScreen (bool isFullScreen)
    {
        //allows user to switch betweeen fullscreen/windowed
        Screen.fullScreen = isFullScreen;

        //Shows in console if fullscreened or windowed as not shown visually in engine
        if(isFullScreen == true)
        {
            Debug.Log("FullScreen");
        }
        else{Debug.Log("Windowed");}
    }
}
