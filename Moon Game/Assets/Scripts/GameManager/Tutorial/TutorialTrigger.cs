using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] TutorialManager tutorialManager;
    [SerializeField] TutorialMoment transitionTo;
    [SerializeField] GameObject panel;

    private void OnTriggerEnter(Collider other)
    {
        tutorialManager.StopGame(transitionTo, panel);
        LightController.playerLight.SetDecreaseSpeed(3f);
    }
}
