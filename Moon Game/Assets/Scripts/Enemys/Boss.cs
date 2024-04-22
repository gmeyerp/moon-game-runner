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

    [Header("Damaged")]
    [SerializeField] float fallSpeed = 0.15f;
    [SerializeField] int health = 3;
    [SerializeField] float defeatDelay = 2f;
    [SerializeField] float recoverDistance = 10f;

    [Header("Attack")]
    [SerializeField] float drainEffectTimer = 1.5f;
    [SerializeField] float drainFinishTimer = 1.5f;
    [SerializeField] float trapsEffectTimer = 2.3f;
    [SerializeField] GameObject[] trapsPrefab;

    [Header("VFX SFX")]
    [SerializeField] ParticleSystem hitVFX;
    [SerializeField] ParticleSystem drainVFX;
    [SerializeField] ParticleSystem trapVFX;
    [SerializeField] AudioClip damagedClip;
    [SerializeField] AudioClip drainSFX;
    [SerializeField] AudioClip trapSFX;

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
        if (isDamaged)
        {
            Vector3 newPos = new Vector3(transform.position.x, 0, 0);
            transform.position = Vector3.Lerp(transform.position, newPos, fallSpeed);
        }
        else
        {
            Vector3 newPos = new Vector3(player.transform.position.x + playerDelta, heightPosition + Mathf.Sin(Time.time * 3.14f), transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, floatSpeed);
        }

        if (player.transform.position.x - transform.position.x > recoverDistance)
        {
            Recover();
        }
    }
    public void DrainLight()
    {
        SoundManager.instance.PlaySFX(drainSFX);
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
        SoundManager.instance.PlaySFX(trapSFX);
        trapVFX.Play();
        StartCoroutine(CTrapsTimer(trapsEffectTimer));
    }    

    public void Fall()
    {
        isDamaged = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isDamaged && (player.isDashingH || player.isDashingV))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        hitVFX.Play();
        health --;
        SoundManager.instance.PlaySFX(damagedClip);
        if (health <= 0)
        {
            StartCoroutine(CBossDefeated());
        }
        else
        {
            Recover();
        }
    }

    void Recover()
    {
        isDamaged = false;
        ActivateTraps();
    }

    IEnumerator CBossDefeated()
    {
        yield return new WaitForSeconds(defeatDelay);
        GameManager.instance.BossDefeat();
    }
}
