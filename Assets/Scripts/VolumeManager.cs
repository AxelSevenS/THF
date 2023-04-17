using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SevenGame.Utility;

public class VolumeManager : Singleton<VolumeManager> 
{
    
    [SerializeField] private float masterVolume = 1f;
    [SerializeField] private float musicVolume = 1f;
    [SerializeField] private float sfxVolume = 1f;

    private void OnEnable()
    {
        SetCurrent();
    }

}
