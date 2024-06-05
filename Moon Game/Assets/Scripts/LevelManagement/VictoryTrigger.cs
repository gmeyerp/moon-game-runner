using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    [SerializeField] Transform finalFruit;
    [SerializeField] float speed;
    [SerializeField] GameObject victoryVFX;
    [SerializeField] float winDelay = 2f;
    [SerializeField] GameObject victoryCanvas;

    private void Awake()
    {
        CameraMovement.finalFruit = this.gameObject.transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.gameOver = true;
            StartCoroutine(EndGame(winDelay));
        }
    }
    IEnumerator EndGame(float delay)
    {
        victoryVFX.SetActive(true);
        yield return new WaitForSeconds(delay);
        victoryCanvas.SetActive(true);

    }
}
