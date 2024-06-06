using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossStartTrigger : MonoBehaviour
{
    [SerializeField] GameObject bossPrefab;
    [SerializeField] float spawnDistance = 30f;
    [SerializeField] GameObject bossText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 position = new Vector3(transform.position.x + spawnDistance, transform.position.y, transform.position.z);
            Instantiate(bossPrefab, position, Quaternion.identity);
        }
    }
}
