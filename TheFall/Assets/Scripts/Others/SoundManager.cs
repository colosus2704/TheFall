using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sound;

    void Start()
    {
        if(sound == null)
        {
            sound = this;
            DontDestroyOnLoad(sound);
        }
    }
    
    public void VolumeManager(float value)
    {
        AudioListener.volume = value;
    }
}
