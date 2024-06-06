using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[Serializable]
public class SaveManagement
{
    public float sfxVolume;
    public float bgmVolume;

    string path = "soundConfig.txt";

    public void Save()
    {
        var content = JsonUtility.ToJson(this, true);
        File.WriteAllText(path, content);
    }

    public void Load()
    {
        var content = File.ReadAllText(path);
        var p = JsonUtility.FromJson<SaveManagement>(content);
        sfxVolume = p.sfxVolume;
        bgmVolume = p.bgmVolume;
    }
}
