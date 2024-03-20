using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    enum Vulnerability {Horizontal, Vertical, None};
    public int enemyScore;
    private Rigidbody rb;

    [Header("Base Stats")]
    [SerializeField] float speed;
    [SerializeField] Vulnerability vulnerability;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Vector3 forawrdMove = transform.forward * speed * Time.deltaTime;
        //rb.MovePosition(rb.position + forawrdMove);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    //Tipos de colis�o com o player.
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
		{
            Player player = other.GetComponent<Player>();            
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
