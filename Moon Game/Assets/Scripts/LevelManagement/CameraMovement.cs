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
    public static Transform finalFruit;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.playerInstance.gameObject.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float x = player.position.x + offset * Player.playerInstance.faceDirection;
        float y = transform.position.y;
        if (isVertical && player.position.y > transform.position.y + height)
            y = player.position.y + height;
        float z = transform.position.z;
        Vector3 newPos = new Vector3(x, y, z);
        if (GameManager.instance.gameOver && finalFruit != null)
        {
            newPos = new Vector3(finalFruit.position.x, finalFruit.position.y, transform.position.z);
        }
        transform.position = Vector3.Lerp(transform.position, newPos, lerpSpeed);
    }
}
