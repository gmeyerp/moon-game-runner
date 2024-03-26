using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
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
}
