using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown dropdown;
    Resolution[] resolutions;
    List<string> resolutionsList;
    public bool isFullScreen;

    public void Awake()
    {
        resolutionsList = new List<string>();
        resolutions = Screen.resolutions;
        foreach (var i in resolutions)
        {
            resolutionsList.Add(i.width +":" + i.height);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutionsList);
        isFullScreen = Screen.fullScreen;
    }
    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    
    public void Sound()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void FullScreen()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, Screen.fullScreen);
    }
    
    
}

