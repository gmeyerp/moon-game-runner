using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] float jumpForce;
    
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement controller = other.gameObject.GetComponent<PlayerMovement>();
        controller.faceDirection *= -1;
        if (controller.isDashingH)
            controller.EndDash();
        }        
    }
}
