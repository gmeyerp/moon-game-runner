using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;

    public static SoundManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
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

    public void ChangeSFX(AudioClip sound)
    {
        if(sound != null)
        sfx.PlayOneShot(sound);
    }

    public void ChangeSFX(AudioClip sound, float volume)
    {
        if (sound != null)
        sfx.PlayOneShot(sound, volume);
    }
}
