using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Scene currentScene;
    [SerializeField] GameObject pauseMenu;

    void Awake()
    {
        if (instance == null)
        instance = this;
        else
        Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        currentScene = SceneManager.GetActiveScene();
        defineOrientation(currentScene);
        pauseMenu.SetActive(false);
    }

    void update()
    {
        checkInput();
    }

    public void PlayerLose()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayerWin()
    {
        SceneManager.LoadScene(3);
    }

    private void defineOrientation(Scene scene)
    {
        if (scene.name == "00 StartScene" || scene.name == "01 FirstLevel" || scene.name == "02 LoseScene" || scene.name == "03 Win Scene")
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        else if(scene.name == "04 SecondLevel")
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }

    private void checkInput()
    {
        if (Input.touchCount == 4)
        {
            SceneManager.LoadScene(4);
        }
    }

    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
