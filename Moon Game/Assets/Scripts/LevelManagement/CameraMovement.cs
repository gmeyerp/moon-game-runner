using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool isVertical;
    [SerializeField] float offset = 5;
    [SerializeField] float height = 2;
    [SerializeField] float lerpSpeed = 0.5f;
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.playerInstance.gameObject.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = new Vector3 (player.position.x + offset * Player.playerInstance.faceDirection, transform.position.y, transform.position.z);
        //
        //if (isVertical && player.position.y > transform.position.y)
        //{
        //    transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        //}
        //
        float x = player.position.x + offset * Player.playerInstance.faceDirection;
        float y = transform.position.y;
        if (isVertical && player.position.y > transform.position.y + height)
            y = player.position.y + height;
        float z = transform.position.z;
        Vector3 newPos = new Vector3(x, y, z);
        transform.position = Vector3.Lerp(transform.position, newPos, lerpSpeed);
    }
}
