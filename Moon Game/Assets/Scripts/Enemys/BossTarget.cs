using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTarget : MonoBehaviour
{
    Boss boss;
    [SerializeField] AudioClip collectSound;
    [SerializeField] GameObject collectVFX;
    [SerializeField] GameObject drainTrigger;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LightController.playerLight.IncreaseLight();
            GameObject vfx = Instantiate(collectVFX, transform.position, collectVFX.transform.rotation);
            SoundManager.instance.PlaySFX(collectSound);
            boss = FindObjectOfType<Boss>();
            boss.Fall();
            Destroy(drainTrigger);
            Destroy(gameObject);
        }
    }
}
