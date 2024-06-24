using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTutorialTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 1f;
        GameManager.instance.SetCurrentScene(1);
        SceneManager.LoadScene(1);
        SoundManager.instance.ChangeBGM(1);
        GameManager.instance.gameOver = false;
        UIButtons.ui_is_Open = false;
    }
}
