using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    enum Vulnerability {Horizontal, Vertical, None};

    [Header("Base Stats")]
    [SerializeField] Vulnerability vulnerability;
    [SerializeField] GameObject deathVFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] Animator animator;
    [SerializeField] float animRange;
    [SerializeField] float deathDelay = 1f;
    bool isDead;
    Player player;

    private void Update()
    {
        if (Vector3.Distance(transform.position, Player.playerInstance.gameObject.transform.position) <= animRange)
        {
            if (animator != null)
                animator.SetTrigger("PlayerRange");
        }
    }
    private void Die()
    {
        isDead = true;
        GameObject vfxObject = Instantiate(deathVFX, transform.position, deathVFX.transform.rotation);
        player.PlayerIncreaseLight();
        if (animator != null)
            animator.SetTrigger("Death");
        if (deathSFX != null)
            SoundManager.instance.PlaySFX(deathSFX);
        Destroy(gameObject, deathDelay);        
    }
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
                    else if (!isDead)
                        player.TakeDamage();                    
                    break;
                }

                case Vulnerability.Vertical:
                {
                    if (player.isDashingV)
                        Die();
                    else if (!isDead)
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
