using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnlyTrigger : MonoBehaviour
{
    [SerializeField] TutorialManager tutorialManager;
    [SerializeField] GameObject panel;
    [SerializeField] bool isTurnOnToo;

    private void OnTriggerEnter(Collider other)
    {
        tutorialManager.TurnOffText();
        if (isTurnOnToo)
            tutorialManager.TurnOnText(panel);
    }
}
