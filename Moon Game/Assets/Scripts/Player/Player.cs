using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int enemyScore;
    private Rigidbody rb;
    Animator animator;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private LightController lightController;

    [Header("Base Stats")]
    [SerializeField] float speed = 2f;
    public float faceDirection = 1;
    [SerializeField] float damagedLight = 40f;

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
    [SerializeField] ParticleSystem hitVFX;

    [Header("SFX")]
    [SerializeField] AudioClip dashSFX;
    [SerializeField] AudioClip hitSFX;

    [Header("Take Damage")]
    float invulnerabilityTimer;    
    bool isInvulnerable;
    [SerializeField] float invulnerabilityCD = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lightController = GetComponentInChildren<LightController>();
        animator = GetComponent<Animator>();
        isInvulnerable = false;
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

        if (invulnerabilityTimer >= invulnerabilityCD)
        {
            isInvulnerable = false;
            Debug.Log(isInvulnerable);
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
                        SoundManager.instance.PlaySFX(dashSFX);                        

                        isDashingH = true;
                        dashDurationTimer = dashDuration;

                        horizontalDashTimer = 0f;
                    }                    
                }
                else if (endTouchPosition.y <= startTouchPosition.y - swipeDistance)
                {
                    if (verticalDashTimer >= verticalDashCD)
                    {
                        dashFX.Play();
                        SoundManager.instance.PlaySFX(dashSFX);

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
        else if(Input.touchCount == 5)
        {
            isInvulnerable = !isInvulnerable;
        }
    }

    private void Jump()
    {
        rb.AddForce(jumpForce * Vector3.up);
        isGrounded = false;
    }

    public void Die()
    {
        SoundManager.instance.PlaySFX(hitSFX);
        GameManager.instance.PlayerLose();
    }

    public void TakeDamage()
    {
        if (!isInvulnerable)
        {
            lightController.DecreaseLight(5, true);
            isInvulnerable = true;
            Debug.Log(isInvulnerable);
            invulnerabilityTimer = 0;
            SoundManager.instance.PlaySFX(hitSFX);
            hitVFX.Play();
            animator.SetTrigger("TakeDamage");
        }        
    }

    public void PlayerIncreseLight()
    {
        lightController.IncreaseLight();
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
            Vector3 forwardMove = transform.right * speed * Time.deltaTime;
            rb.MovePosition(rb.position + forwardMove);
        }
    }

    private void UpdateTimer()
    {
        horizontalDashTimer += Time.deltaTime;
        verticalDashTimer += Time.deltaTime;
        dashDurationTimer -= Time.deltaTime;
        invulnerabilityTimer += Time.deltaTime;
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

