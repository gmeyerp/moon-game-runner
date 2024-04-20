using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossDrainTrigger : MonoBehaviour
{
    Boss boss;

    void Start()
    {
        boss = FindObjectOfType<Boss>();           
    }

    void OnTriggerEnter(Collider other)
    {
        boss.DrainLight();
    }
}
