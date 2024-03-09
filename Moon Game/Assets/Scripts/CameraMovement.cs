using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool isHorizontal;
    [SerializeField] float offset = 5;
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isHorizontal)
        {
            transform.position = new Vector3 (player.position.x + offset, transform.position.y, transform.position.z);
        }
        else if (player.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
    }
}
