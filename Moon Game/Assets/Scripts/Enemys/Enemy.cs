using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyScore;
    private Rigidbody rb;

    [Header("Base Stats")]
    [SerializeField] float speed = 2f;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 forawrdMove = transform.forward * speed * Time.deltaTime;
        rb.MovePosition(rb.position + forawrdMove);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    //Tipos de colisão com o player.
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
		{
            Die();
		}
        else if(other.gameObject.tag == "Atack")
		{
            //socore++;
            Die();
		}
        else if(other.gameObject.tag == "Especial")
		{
            //socore++;
            Die();
		}

    }
}
