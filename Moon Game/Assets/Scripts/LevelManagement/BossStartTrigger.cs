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
        Vector3 position = new Vector3(transform.position.x + spawnDistance, transform.position.y, transform.position.z);
        Instantiate(bossPrefab, position, Quaternion.identity);
        StartCoroutine(CTextDelay());
    }

    IEnumerator CTextDelay()
    {
        bossText.SetActive(true);
        yield return new WaitForSeconds(3f);
        bossText.SetActive(false);
    }
}
