using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainVFX : MonoBehaviour
{
    Player player;
    // Update is called once per frame

    private void Start()
    {
        player = Player.playerInstance;
    }
    void Update()
    {
        transform.LookAt(player.transform.position);        
    }
}
