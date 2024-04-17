using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float heightPosition = 5f;
    [SerializeField] float playerDelta = 15f;
    [SerializeField] float floatSpeed = 0.5f;

    [Header("Attack")]
    bool isDamaged;
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDamaged)
        {
            Vector3 newPos = new Vector3(player.transform.position.x + playerDelta, heightPosition + Mathf.Sin(Time.time * 3.14f), transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, floatSpeed);
        }
    }
}
