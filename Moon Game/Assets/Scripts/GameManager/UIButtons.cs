using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject configPanel;
    public static bool ui_is_Open;
    private void ButtonClicked()
    {
        SoundManager.instance.PlaySFX(0);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        ButtonClicked();
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
        ButtonClicked();
    }

    public void ReplayGame() //depois tem a opcao de colocar um contador de fases
    {
        SceneManager.LoadScene(1);
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
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1.0f;
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        UIButtons.ui_is_Open = false;
        //implementar save de configuracoes
    }

    public void OpenConfig()
    {
        configPanel.SetActive(true);
    }

    public void CloseConfig()
    {
        configPanel.SetActive(false);
        
        //implementar save de configuracoes
    }
}
