using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        instance = this;
        else
        Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlayerLose()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayerWin()
    {
        SceneManager.LoadScene(3);
    }
}
