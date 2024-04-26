using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonColletable : MonoBehaviour
{
    [SerializeField] AudioClip collectSFX;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Player player = Player.playerInstance;
            player.ActivateLightVFX();
            player.PlayerIncreaseLight();

            Destroy(gameObject);
            SoundManager.instance.PlaySFX(collectSFX);
        }
    }
}
