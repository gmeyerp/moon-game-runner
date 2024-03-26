using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioClip[] globalSounds;

    public static SoundManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        instance = this;
        else
        Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
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
}
