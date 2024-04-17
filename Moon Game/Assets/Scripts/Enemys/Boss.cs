using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Player player;
    LightController lightController;
    Animator animator;
    bool isDamaged;

    [Header("Movement")]
    [SerializeField] float heightPosition = 5f;
    [SerializeField] float playerDelta = 15f;
    [SerializeField] float floatSpeed = 0.5f;

    [Header("Attack")]
    [SerializeField] float drainDelay = 1.5f;
    [SerializeField] float attackCD;
    [SerializeField] GameObject[] trapsPrefab;

    [Header("VFX SFX")]
    [SerializeField] ParticleSystem hitVFX;
    [SerializeField] ParticleSystem drainVFX;
    [SerializeField] ParticleSystem trapVFX;

    void Start()
    {
        player = FindObjectOfType<Player>();
        lightController = player.ReturnLightSource();
        //animator = GetComponent<Animator>();

        lightController.SwitchLightDecay(false);
        DrainLight();
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

    public void DrainLight()
    {
        drainVFX.Play();
        StartCoroutine(CDrainTimer(drainDelay));
    }

    IEnumerator CDrainTimer(float drainDelay)
    {
        yield return new WaitForSeconds(drainDelay);
        Debug.Log("Drain");
        lightController.DecreaseLight(false);
    }

    public void CreateTraps()
    {
        int trapIndex = Random.Range(0, trapsPrefab.Length);
        Vector3 trapPos = new Vector3(transform.position.x, 0, 0);
        Instantiate(trapsPrefab[trapIndex], trapPos, Quaternion.identity);
    }
}
