using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Player player;
    Animator animator;
    bool isDamaged;

    [Header("Movement")]
    [SerializeField] float heightPosition = 5f;
    [SerializeField] float playerDelta = 15f;
    [SerializeField] float floatSpeed = 0.5f;

    [Header("Attack")]
    [SerializeField] float drainEffectTimer = 1.5f;
    [SerializeField] float drainFinishTimer = 1.5f;
    [SerializeField] float trapsEffectTimer = 2.3f;
    [SerializeField] GameObject[] trapsPrefab;

    [Header("VFX SFX")]
    [SerializeField] ParticleSystem hitVFX;
    [SerializeField] ParticleSystem drainVFX;
    [SerializeField] ParticleSystem trapVFX;

    void Start()
    {
        player = FindObjectOfType<Player>();
        //animator = GetComponent<Animator>();
        LightController.playerLight.SwitchLightDecay(false);
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
    void DrainLight()
    {
        drainVFX.Play();
        StartCoroutine(CDrainTimer(drainEffectTimer, drainFinishTimer));
    }

    IEnumerator CDrainTimer(float drainDelay, float drainFinish)
    {
        yield return new WaitForSeconds(drainDelay);
        Debug.Log("Drain");
        LightController.playerLight.DecreaseLight(false);
        yield return new WaitForSeconds(drainFinish);
        ActivateTraps();
    }
    void CreateTraps()
    {
        int trapIndex = Random.Range(0, trapsPrefab.Length);
        Vector3 trapPos = new Vector3(transform.position.x, 0, 0);
        Instantiate(trapsPrefab[trapIndex], trapPos, Quaternion.identity);
    }

    IEnumerator CTrapsTimer(float trapsActivateTimer)
    {
        yield return new WaitForSeconds(trapsActivateTimer);
        CreateTraps();
    }

    void ActivateTraps()
    {
        trapVFX.Play();
        StartCoroutine(CTrapsTimer(trapsEffectTimer));
    }



    
}
