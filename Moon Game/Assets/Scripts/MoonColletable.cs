using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonColletable : MonoBehaviour
{    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LightController light = other.GetComponentInChildren<LightController>();
            light.IncreaseLight();
            Destroy(gameObject);

            Player player = other.GetComponent<Player>();
            player.ActivateLightVFX();
        }
    }
}
