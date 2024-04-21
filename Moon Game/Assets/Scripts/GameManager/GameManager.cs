using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Scene currentScene;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] AudioMixer audioMixer;

    void Awake()
    {
        if (instance == null)
        instance = this;
        else
        Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        currentScene = SceneManager.GetActiveScene();
        DefineOrientation(currentScene);
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        CheckInput();
    }

    public void PlayerLose()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayerWin()
    {
        SceneManager.LoadScene(3);
    }

    private void DefineOrientation(Scene scene)
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

    private void CheckInput()
    {
        if (Input.touchCount == 5)
        {
            SceneManager.LoadScene("04 SecondLevel");
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
