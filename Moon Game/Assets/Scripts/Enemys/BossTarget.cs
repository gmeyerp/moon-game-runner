using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTarget : MonoBehaviour
{
    Boss boss;
    [SerializeField] GameObject drainTrigger;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LightController.playerLight.IncreaseLight();
            boss = FindObjectOfType<Boss>();
            boss.Fall();
            Destroy(drainTrigger);
        }
    }
}
