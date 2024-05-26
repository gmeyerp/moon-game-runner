using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] bool isSFX;
    private void OnEnable()
    {
        if (isSFX)
            slider.value = SoundManager.instance.GetSFXVolume();
        else
            slider.value = SoundManager.instance.GetBGMVolume();
    }

    public void BGMChange(float value)
    {
        SoundManager.instance.ChangeBGMVolume(value);
    }

    public void SFXChange(float value)
    {
        SoundManager.instance.ChangeSFXVolume(value);
    }

    private void OnDisable()
    {
        SoundManager.instance.UpdateSave();
    }
}
