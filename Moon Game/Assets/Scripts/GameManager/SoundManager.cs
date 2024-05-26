using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioClip[] globalSounds;
    SaveManagement save;

    public static SoundManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        instance = this;
        else
        Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        save = new SaveManagement();
        save.Load();
        sfx.volume = save.sfxVolume;
        bgm.volume = save.bgmVolume;
    }

    private void OnEnable()
    {
        save.Load();
        sfx.volume = save.sfxVolume;
        bgm.volume = save.bgmVolume;
    }

    public void ChangeBGM(AudioClip music)
    {
        bgm.clip = music;
        bgm.Play();
        bgm.loop = true;         
    }

    public void PlaySFX(int index)
    {
        sfx.Stop();
        sfx.PlayOneShot(globalSounds[index]);
    }
    public void PlaySFX(AudioClip sound)
    {
        sfx.Stop();
        if(sound != null)
        sfx.PlayOneShot(sound);
    }

    public void PlaySFX(AudioClip sound, float volume)
    {
        sfx.Stop();
        if (sound != null)
        sfx.PlayOneShot(sound, volume);
    }

    public void ChangeBGMVolume(float volume)
    {
        bgm.volume = volume;
    }

    public void ChangeSFXVolume(float volume)
    {
        sfx.volume = volume;
    }

    private void OnDestroy()
    {
        UpdateSave();
    }

    public void UpdateSave()
    {
        save.sfxVolume = sfx.volume;
        save.bgmVolume = bgm.volume;
        save.Save();
    }

    public float GetSFXVolume()
    {
        return sfx.volume;
    }

    public float GetBGMVolume()
    {
        return bgm.volume;
    }

}
