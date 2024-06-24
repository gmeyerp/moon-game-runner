using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TutorialMoment {Light, Jump, DashH, DashV, Invulnerable, End}
public class TutorialManager : MonoBehaviour
{
    public TutorialMoment currentMoment = 0;
    [SerializeField] float swipeDistance = 5f;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] GameObject currentPanel;
    Vector2 startTouchPosition;
    Vector2 endTouchPosition;


    private void Update()
    {
        TutorialActivity();
    }

    public void StopGame(TutorialMoment currentMoment, GameObject panel)
    {
        Player.playerInstance.PlayerGravity(false);
        LightController.playerLight.SwitchLightDecay(false);
        TurnOffText();
        this.currentMoment = currentMoment;
        TurnOnText(panel);
        pauseCanvas.SetActive(false);
        UIButtons.ui_is_Open = true;
    }

    public void RestartGame()
    {
        Player.playerInstance.PlayerGravity(true);
        LightController.playerLight.SwitchLightDecay(true);
        TurnOffText();
        pauseCanvas.SetActive(true);
        UIButtons.ui_is_Open = false;
    }

    public void TutorialActivity()
    {
        if (Input.touchCount > 0 && UIButtons.ui_is_Open)
        {
            Touch firstTouch = Input.GetTouch(0);
            if (firstTouch.phase == TouchPhase.Began)
            {
                startTouchPosition = firstTouch.position;
                endTouchPosition = firstTouch.position;
            }

            if (firstTouch.phase == TouchPhase.Ended)
            {
                endTouchPosition = firstTouch.position;

                if (endTouchPosition.x >= startTouchPosition.x + swipeDistance && currentMoment == TutorialMoment.DashH)
                {
                    Player.playerInstance.StartDashH();
                    RestartGame();
                }
                else if (endTouchPosition.y <= startTouchPosition.y - swipeDistance && currentMoment == TutorialMoment.DashV)
                {
                    Player.playerInstance.StartDashV();
                    RestartGame();
                }
                else if (currentMoment == TutorialMoment.Jump)
                {
                    Player.playerInstance.Jump();
                    RestartGame();
                }
            }            
        }
    }

    public void TurnOnText(GameObject panel)
    {
        currentPanel = panel;
        currentPanel.SetActive(true);
    }

    public void TurnOffText()
    {
        currentPanel.SetActive(false);
    }
}
