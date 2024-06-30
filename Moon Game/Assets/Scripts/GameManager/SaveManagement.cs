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
        string destination = Application.persistentDataPath + "/" +path;
        Debug.Log(destination);
        var content = JsonUtility.ToJson(this, true);
        File.WriteAllText(destination, content);
    }

    public void Load()
    {
        string destination = Application.persistentDataPath + "/" + path;
        var content = File.ReadAllText(destination);
        var p = JsonUtility.FromJson<SaveManagement>(content);
        sfxVolume = p.sfxVolume;
        bgmVolume = p.bgmVolume;
    }
}
