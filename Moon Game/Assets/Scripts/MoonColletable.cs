using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonColletable : MonoBehaviour
{
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LightController light = other.GetComponentInChildren<LightController>();
            light.IncreaseLight();
            Destroy(gameObject);
        }
    }
}
