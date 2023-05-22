using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SevenGame.Utility;

public class VolumeManager : Singleton<VolumeManager> 
{

    [SerializeField] private GameObject menuContainer;
    
    public float masterVolume = 1f;
    public float musicVolume = 1f;
    public float sfxVolume = 1f;

    private void OnEnable()
    {
        SetCurrent();
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        AudioListener.volume = masterVolume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        GameManager.current.audioSource.volume = musicVolume;
    }


    public void EnableVolumeMenu()
    {
        menuContainer.SetActive(true);
    }

    public void DisableVolumeMenu()
    {
        menuContainer.SetActive(false);
    }

    public void ToggleVolumeMenu()
    {
        if ( menuContainer.activeSelf ){
            DisableVolumeMenu();
        }
        else
        {
            EnableVolumeMenu();
        }
    }

}
