using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int currentScene;
    public bool gameOver;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        gameOver = false;
    }

    void Update()
    {
        CheckInput();
    }

    public void PlayerLose()
    {
        SoundManager.instance.ChangeBGM(3);
        SceneManager.LoadScene(3);
    }

    public void PlayerWin()
    {
        SceneManager.LoadScene(4);
    }

    public void BossDefeat()
    {
        currentScene = 2;
        SoundManager.instance.ChangeBGM(2);
        SceneManager.LoadScene(2);
    }

    private void CheckInput()
    {
        if(Input.touchCount == 5)
        {
            Touch lastTouch = Input.GetTouch(4);
            if (lastTouch.phase == TouchPhase.Ended)
            {
                SoundManager.instance.ChangeBGM(2);
                SceneManager.LoadScene(2);
            }
        }
    }

    public int GetCurrentScene()
    {
        return currentScene;
    }

    public void SetCurrentScene(int scene)
    {
        currentScene = scene;
    }
}
