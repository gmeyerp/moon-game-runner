using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float addToPosition;
    
    void Update()
    {
        if (player.position.x - transform.position.x >= addToPosition)
        transform.position = new Vector3(player.position.x + addToPosition, transform.position.y);
    }
}
