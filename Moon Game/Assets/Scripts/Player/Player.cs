using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int enemyScore;
    private Rigidbody rb;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    [Header("Base Stats")]
    [SerializeField] float speed = 2f;
    public float faceDirection = 1;
    float input;



    [Header("Dash Skill")]
    public bool isDashingH;
    [SerializeField] float horizontalDashCD = 1f;
    float horizontalDashTimer;
    [SerializeField] float dashDuration = 0.2f;
    float dashDurationTimer;
    [SerializeField] float dashForce = 10f;

    [Header("Jump")]
    [SerializeField] float jumpForce = 800;
    [SerializeField] LayerMask isGround;
    [SerializeField] float groundDistance;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 forawrdMove = transform.forward * speed * Time.deltaTime;
        rb.MovePosition(rb.position + forawrdMove);

        if(Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if(Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if(endTouchPosition.x < startTouchPosition.x)
            {
                isDashingH = true;
                dashDurationTimer = dashDuration;
                        
                horizontalDashTimer = 0f;
            }

            if(endTouchPosition.x < startTouchPosition.x)
            {
                isDashingH = true;
                dashDurationTimer = dashDuration;
                        
                horizontalDashTimer = 0f;
            }
        }
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

        private void CheckPosition()
    {
        Ray ray = new Ray (transform.position, Vector3.down);
        isGrounded = Physics.Raycast(ray, groundDistance, isGround);
    }

    private void BaseMovement()
    {
        if(!isDashingH)
        rb.velocity = new Vector3 (faceDirection * speed, rb.velocity.y, rb.velocity.z);
    }

    private void UpdateTimer()
    {
        horizontalDashTimer += Time.deltaTime;
        dashDurationTimer -= Time.deltaTime;
    }

    private void Dash()
    {        
        if (dashDurationTimer >= 0)
        {
            rb.velocity = input * dashForce * Vector3.right;                
        }
        else
        {
            EndDash();
        }                   
    }
    public void EndDash()
    {
        rb.velocity = Vector3.zero;
        isDashingH = false;
    }
}

