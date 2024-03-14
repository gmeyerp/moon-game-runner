using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Base Stats")]
    [SerializeField] float speed = 2f;
    float input;
    public float faceDirection = 1;

    [Header("Dash Skill")]
    public bool isDashingH;
    [SerializeField] float horizontalDashCD = 1f;
    float horizontalDashTimer;
    [SerializeField] float dashDuration = 0.2f;
    float dashDurationTimer;
    [SerializeField] float dashForce = 10f;
    Rigidbody myRb;

    [Header("Jump")]
    [SerializeField] float jumpForce = 800;
    [SerializeField] LayerMask isGround;
    [SerializeField] float groundDistance;
    bool isGrounded;

    [Header("VFX")]
    [SerializeField] ParticleSystem lightVFX;
    [SerializeField] GameObject dustVFX;
    [SerializeField] ParticleSystem dashVFX;
    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, Vector3.down * groundDistance);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        CheckInput();
        CheckPosition();

        if (isDashingH)
        {
            Dash();
        }

        dustVFX.SetActive(isGrounded);
    }

    private void CheckInput()
    {
        input = Input.GetAxisRaw("Horizontal");

        if (input != 0 && horizontalDashTimer >= horizontalDashCD && Input.GetKey(KeyCode.Space))
        {
            dashVFX.Play();

            isDashingH = true;
            dashDurationTimer = dashDuration;
                        
            horizontalDashTimer = 0f;         
        }
        else
        {
            BaseMovement();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            myRb.AddForce(jumpForce * Vector3.up);
            isGrounded = false;
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
        myRb.velocity = new Vector3 (faceDirection * speed, myRb.velocity.y, myRb.velocity.z);
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
            myRb.velocity = input * dashForce * Vector3.right;                
        }
        else
        {
            EndDash();
        }                   
    }
    public void EndDash()
    {
        myRb.velocity = Vector3.zero;
        isDashingH = false;
        dashVFX.Stop();
    }

    public void ActivateLightVFX()
    {
        lightVFX.Play();
    }
}
