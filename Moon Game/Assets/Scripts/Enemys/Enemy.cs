using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    enum Vulnerability {Horizontal, Vertical, None};

    [Header("Base Stats")]
    [SerializeField] Vulnerability vulnerability;
    [SerializeField] GameObject deathVFX;
    Player player;
    private void Die()
    {
        GameObject vfxObject = Instantiate(deathVFX, transform.position, deathVFX.transform.rotation);
        player.PlayerIncreaseLight();
        Destroy(gameObject);        
    }

    //Tipos de colis�o com o player.
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
		{
            player = Player.playerInstance;            
            switch (vulnerability)
            {
                case Vulnerability.Horizontal:
                {
                    if (player.isDashingH)
                        Die();
                    else
                    player.TakeDamage();                    
                    break;
                }

                case Vulnerability.Vertical:
                {
                    if (player.isDashingV)
                        Die();
                    else
                    player.TakeDamage();                    
                    break;
                }
                
                case Vulnerability.None:
                {
                    player.TakeDamage();
                    break;
                }
            }
        }        
    }
}
