using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider;

    void Update()
    {
        volumeSlider.onValueChanged.AddListener(val => SoundManager.sound.VolumeManager(val));
    }
}
