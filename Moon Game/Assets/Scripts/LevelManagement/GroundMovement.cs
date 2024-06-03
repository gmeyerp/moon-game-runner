using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float addToPosition;
    [SerializeField] bool isHorizontal = true;
    
    void Update()
    {
        if (isHorizontal && player.position.x - transform.position.x >= addToPosition)
            transform.position = new Vector3(transform.position.x + 2 * addToPosition, transform.position.y);
        if (!isHorizontal && player.position.y - transform.position.y >= addToPosition)
            transform.position = new Vector3(transform.position.x, transform.position.y + 2 * addToPosition);
    }
}
