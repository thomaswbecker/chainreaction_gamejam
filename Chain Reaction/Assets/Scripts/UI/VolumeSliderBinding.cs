using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VolumeSliderBinding : MonoBehaviour
{
    public Slider slider;
    public AudioMixer mixer;

    public string AudioParameterID;

    void Start()
    {
        float mixerVolume;
        bool success = mixer.GetFloat(AudioParameterID, out mixerVolume);
        Debug.Assert(success, "VolumeSliderBinding AudioParameterID is incorrect("+AudioParameterID+")");
        slider.value = mixerVolume;

    }
    public void OnVolumeChanged() {
        mixer.SetFloat(AudioParameterID, slider.value);
    }
}
