using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSecond : MonoBehaviour
{
    [SerializeField] float xRange;
    [SerializeField] float xSpeed;
    [SerializeField] float flySpeed;
    private void Update()
    {
        if (!GameManager.instance.gameOver)
        {
            float x = xRange * Mathf.Sin(Time.time * xSpeed / 3.14f);
            float y = flySpeed;
            transform.Translate(new Vector3(x, y) * Time.deltaTime);
        }
        if (transform.position.y >= 155)
        {
            GameManager.instance.PlayerLose();
        }
    }
}
