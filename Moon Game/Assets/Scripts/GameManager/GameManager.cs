using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Scene currentScene;
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
        currentScene = SceneManager.GetActiveScene();        
    }

    void Update()
    {
        CheckInput();
    }

    public void PlayerLose()
    {
        SceneManager.LoadScene(3);
        SoundManager.instance.ChangeBGM(3);
    }

    public void PlayerWin()
    {
        SceneManager.LoadScene(4);
    }

    public void BossDefeat()
    {
        SceneManager.LoadScene(2);
        SoundManager.instance.ChangeBGM(2);
    }

    private void CheckInput()
    {
        if(Input.touchCount == 5)
        {
            Touch lastTouch = Input.GetTouch(4);
            if (lastTouch.phase == TouchPhase.Ended)
            {
                SceneManager.LoadScene(2);
                SoundManager.instance.ChangeBGM(2);
            }
        }
    }

    public Scene GetCurrentScene()
    {
        return currentScene;
    }
}
