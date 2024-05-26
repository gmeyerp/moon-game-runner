using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public static LightController playerLight;
    Light lightComp;
    [SerializeField] float lightAngle;
    [SerializeField] float delta = 20f;
    [SerializeField] float lightIncrement;
    [SerializeField] float lerpSpeed = 0.01f;
    float maxAmount = 179f;
    float minAmount = 40f;
    [SerializeField] int incrementsNumber = 10;
    [SerializeField] int amountToDie = 4;
    [SerializeField] float decreaseSpeed = 0.5f;
    float normalIntensity = 50f;
    float newIntensity = 50f;
    Player player;

    [Header("Flicker")]
    [SerializeField] float intensityRange;
    float flickerTimer = 0.3f;
    [SerializeField] float flickerCD = 0.3f;
    bool isDecaying = true;

    private void Awake()
    {
        if (playerLight == null)
        {
            playerLight = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        player = Player.playerInstance;
        lightComp = GetComponent<Light>();
        lightIncrement = (maxAmount-minAmount)/incrementsNumber; //calculando o valor de cada incremento
        lightAngle = maxAmount; //colocando o valor inicial no maximo

        lightComp.spotAngle = lightAngle; //colocando o angulo da luz no valor inicial
        lightComp.innerSpotAngle = lightAngle - delta;

    }

    void Update()
    {
        if (isDecaying)
        {
            DecreaseLight(decreaseSpeed * Time.deltaTime, false);
        }

        lightComp.spotAngle = Mathf.Lerp(lightComp.spotAngle, lightAngle, lerpSpeed);
        lightComp.innerSpotAngle = Mathf.Lerp(lightComp.innerSpotAngle, lightAngle - delta, lerpSpeed);

        flickerTimer -= Time.deltaTime;
        if (lightAngle <= minAmount + amountToDie * lightIncrement && flickerTimer <= 0)
        {
            Flicker();
        }

        lightComp.intensity = Mathf.Lerp(lightComp.intensity, newIntensity, 0.5f);
    }

    public void IncreaseLight()
    {
        lightAngle += lightIncrement;

        if (lightAngle > minAmount + amountToDie) //caso o jogador esteja morrendo, a luz recupera mais intensamente para evitar feedback negativo
        {
            lightAngle += lightIncrement;
        }

        lightAngle = Mathf.Clamp(lightAngle, minAmount, maxAmount);

        if (lightAngle > minAmount + amountToDie)
        {
            newIntensity = normalIntensity;
        }

        ///lightComp.spotAngle = lightAngle;
        //lightComp.innerSpotAngle = lightAngle - delta;
    }

    public void IncreaseLight(int incrementsAmount)
    {
        lightAngle += incrementsAmount * lightIncrement;

        if (lightAngle > minAmount + amountToDie) //caso o jogador esteja morrendo, a luz recupera mais intensamente para evitar feedback negativo
        {
            lightAngle += lightIncrement;
        }

        lightAngle = Mathf.Clamp(lightAngle, minAmount, maxAmount);

        if (lightAngle > minAmount + amountToDie)
        {
            newIntensity = normalIntensity;
        }
    }

    public void IncreaseLight(bool full)
    {
        if (full)
            lightAngle = maxAmount;

        lightAngle = Mathf.Clamp(lightAngle, minAmount, maxAmount);

        if (lightAngle > minAmount + amountToDie)
        {
            newIntensity = normalIntensity;
        }
    }

    public void DecreaseLight(float decreaseAmount, bool kill)
    {
        if (lightAngle <= minAmount + amountToDie * lightIncrement && kill)
        {
            player.Die();
        }
        lightAngle -= decreaseAmount;
        lightAngle = Mathf.Clamp(lightAngle, minAmount, maxAmount);
        
        //lightComp.spotAngle = lightAngle;
        //lightComp.innerSpotAngle = lightAngle - delta;
    }

    public void DecreaseLight(int incrementsDecrease, bool kill)
    {
        if (lightAngle <= minAmount + amountToDie * lightIncrement && kill)
        {
            player.Die();
        }
        lightAngle -= incrementsDecrease * lightIncrement;
        lightAngle = Mathf.Clamp(lightAngle, minAmount, maxAmount);
    }

    public void DecreaseLight(bool kill)
    {
        if (lightAngle <= minAmount + amountToDie * lightIncrement && kill)
        {
            player.Die();
        }
        lightAngle -= lightIncrement;
        lightAngle = Mathf.Clamp(lightAngle, minAmount, maxAmount);
    }

    public void Flicker()
    {        
        newIntensity = normalIntensity - Random.Range(0, intensityRange);  
        flickerTimer = flickerCD;            
    }

    public void SwitchLightDecay(bool isDecaying)
    {
        this.isDecaying = isDecaying;
    }
}
