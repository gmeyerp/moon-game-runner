using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public void BGMChange(float value)
    {
        SoundManager.instance.ChangeBGMVolume(value);
    }

    public void SFXChange(float value)
    {
        SoundManager.instance.ChangeSFXVolume(value);
    }
}
