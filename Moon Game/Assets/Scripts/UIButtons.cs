using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReplayGame() //depois tem a opcao de colocar um contador de fases
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Fechar programa");
        Application.Quit();
    }
}
