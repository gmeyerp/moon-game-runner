using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject configPanel;
    [SerializeField] GameObject instructionPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject[] tutorial;
    public static bool ui_is_Open;
    private void ButtonClicked()
    {
        SoundManager.instance.PlaySFX(0);
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        GameManager.instance.SetCurrentScene(1);
        SceneManager.LoadScene(1);
        SoundManager.instance.ChangeBGM(1);
        GameManager.instance.gameOver = false;
        ButtonClicked();
    }

    public void ReturnMenu()
    {
        GameManager.instance.SetCurrentScene(0);
        SceneManager.LoadScene(0);
        SoundManager.instance.ChangeBGM(0);
        GameManager.instance.gameOver = false;
        ButtonClicked();
    }

    public void ReplayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(GameManager.instance.GetCurrentScene());        
        SoundManager.instance.ChangeBGM(GameManager.instance.GetCurrentScene());
        GameManager.instance.gameOver = false;
        ButtonClicked();
    }

    public void QuitGame()
    {
        Debug.Log("Fechar programa");
        Application.Quit();
    }
    
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
        UIButtons.ui_is_Open = true;
        ButtonClicked();
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1.0f;
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        StartCoroutine(IUnpauseDelay());
        ButtonClicked();
    }

    IEnumerator IUnpauseDelay()
    {
        yield return new WaitForEndOfFrame();
        UIButtons.ui_is_Open = false;
    }

    public void OpenConfig()
    {
        configPanel.SetActive(true);
        ButtonClicked();
    }

    public void CloseConfig()
    {
        configPanel.SetActive(false);
        ButtonClicked();
    }

    public void SwitchCreditsPanel()
    {
        creditsPanel.SetActive(!creditsPanel.activeSelf);
        ButtonClicked();
    }

    public void SwitchInstructionsPanel()
    {
        instructionPanel.SetActive(!instructionPanel.activeSelf);
        ButtonClicked();
    }

    public void MoreTutorialInfo()
    {
        foreach(GameObject info in tutorial)
        {
            info.SetActive(!info.activeSelf);
        }
    }
}
