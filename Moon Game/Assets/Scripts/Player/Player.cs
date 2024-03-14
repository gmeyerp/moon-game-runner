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



    [Header("Dash Skill")]
    public bool isDashingH;
    public bool isDashingV;
    [SerializeField] float horizontalDashCD = 1f;
    [SerializeField] float verticalDashCD = 1f; 
    float horizontalDashTimer;
    float verticalDashTimer;
    [SerializeField] float dashDuration = 0.2f;
    float dashDurationTimer;
    [SerializeField] float dashForce = 10f;
    [SerializeField] float swipeDistance = 5f;


    [Header("Jump")]
    [SerializeField] float jumpForce = 800;
    [SerializeField] LayerMask isGround;
    [SerializeField] float groundDistance;
    bool isGrounded;

    [Header("VFX")]
    [SerializeField] GameObject steps;
    [SerializeField] ParticleSystem collectable;
    [SerializeField] ParticleSystem dashFX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        UpdateTimer();

        CheckPosition();
        BaseMovement();
        CheckInput();


        if (isDashingH)
        {
            DashHorizontal();
        }
        else if (isDashingV)
        {
            DashVertical();
        }

        steps.SetActive(isGrounded);
    }

    private void CheckInput()
    {
        if (Input.touchCount > 0)
        {
            Touch firstTouch = Input.GetTouch(0);
            if (firstTouch.phase == TouchPhase.Began)
            {
                startTouchPosition = firstTouch.position;
                endTouchPosition = firstTouch.position;
            }         

            if (firstTouch.phase == TouchPhase.Ended)
            {
                endTouchPosition = firstTouch.position;

                if (endTouchPosition.x >= startTouchPosition.x + swipeDistance || endTouchPosition.x <= startTouchPosition.x - swipeDistance)
                {
                    if (horizontalDashTimer >= horizontalDashCD)
                    {
                        dashFX.Play();

                        isDashingH = true;
                        dashDurationTimer = dashDuration;

                        horizontalDashTimer = 0f;
                    }                    
                }
                else if (endTouchPosition.y >= startTouchPosition.y + swipeDistance || endTouchPosition.y <= startTouchPosition.y - swipeDistance)
                {
                    if (verticalDashTimer >= verticalDashCD)
                    {
                        dashFX.Play();
                
                        isDashingV = true;
                        dashDurationTimer = dashDuration;
                
                        verticalDashTimer = 0f;
                    }
                }
                else if (isGrounded)
                {
                    Jump();
                }
            }

        }
    }

    private void Jump()
    {
        rb.AddForce(jumpForce * Vector3.up);
        isGrounded = false;
    }

    private void Die()
    {
        GameManager.instance.PlayerLose();
    }

    //Tipos de colis�o com o player.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyAttack")
        {
            Die();
        }
        else if (other.gameObject.tag == "Body")
        {
            //socore++;
            Die();
        }
        else if (other.gameObject.tag == "Especial")
        {
            //socore++;
            Die();
        }
    }

    private void CheckPosition()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        isGrounded = Physics.Raycast(ray, groundDistance, isGround);
    }

    private void BaseMovement()
    {
        if (!isDashingH)
        {
            Vector3 forawrdMove = transform.right * speed * Time.deltaTime;
            rb.MovePosition(rb.position + forawrdMove);
        }
    }

    private void UpdateTimer()
    {
        horizontalDashTimer += Time.deltaTime;
        verticalDashTimer += Time.deltaTime;
        dashDurationTimer -= Time.deltaTime;
    }

    private void DashHorizontal()
    {
        if (dashDurationTimer >= 0)
        {
            rb.velocity = dashForce * Vector3.right;
        }
        else
        {
            EndDash();
        }
    }

    private void DashVertical()
    {
        if (dashDurationTimer >= 0)
        {
            rb.velocity = dashForce * Vector3.down;
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
        isDashingV = false;

        //dashVFX.Stop();
    }

    public void ActivateLightVFX()
    {
        collectable.Play();
    }
}

