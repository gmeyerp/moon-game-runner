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
    [SerializeField] private AudioMixer audioMixer;

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

    //Stage Progression

    public void PlayerLose()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayerWin()
    {
        SceneManager.LoadScene(3);
    }

    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Device Orientation Manager

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

    //Cheat Warp to Stage II

    private void CheckInput()
    {
        if (Input.touchCount == 4)
        {
            SceneManager.LoadScene(4);
        }
    }

    //Pause Menu

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

    //Settings Menu

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
