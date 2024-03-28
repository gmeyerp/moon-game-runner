using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    Light lightComp;
    [SerializeField] float lightAngle;
    [SerializeField] float delta = 20f;
    [SerializeField] float lightIncrement;
    [SerializeField] float lerpSpeed = 0.01f;
    float maxAmount = 179f;
    float minAmount = 40f;
    [SerializeField] int incrementsNumber = 10;
    [SerializeField] int amoutToDie = 4;
    [SerializeField] float decreaseSpeed = 0.5f;

    
    void Start()
    {
        lightComp = GetComponent<Light>();
        lightIncrement = (maxAmount-minAmount)/incrementsNumber;
        lightAngle = minAmount + lightIncrement * incrementsNumber/2;
    }

    void Update()
    {
        DecreaseLight(decreaseSpeed * Time.deltaTime, false);

        lightComp.spotAngle = Mathf.Lerp(lightComp.spotAngle, lightAngle, lerpSpeed);
        lightComp.innerSpotAngle = Mathf.Lerp(lightComp.innerSpotAngle, lightAngle - delta, lerpSpeed);
    }

    public void IncreaseLight()
    {
        lightAngle += lightIncrement;
        ///lightComp.spotAngle = lightAngle;
        //lightComp.innerSpotAngle = lightAngle - delta;
    }

    public void IncreaseLight(int amount)
    {
        lightAngle += amount * lightIncrement;
        lightAngle = Mathf.Clamp(lightAngle, minAmount, maxAmount);
    }

    public void IncreaseLight(bool full)
    {
        if (full)
            lightAngle = maxAmount;
        lightAngle = Mathf.Clamp(lightAngle, minAmount, maxAmount);
    }

    public void DecreaseLight(float amount, bool kill)
    {
        if (lightAngle <= minAmount + amoutToDie * lightIncrement && kill)
        {
            Player player = GetComponentInParent<Player>();
            player.Die();
        }
        lightAngle -= amount;
        lightAngle = Mathf.Clamp(lightAngle, minAmount, maxAmount);
        
        //lightComp.spotAngle = lightAngle;
        //lightComp.innerSpotAngle = lightAngle - delta;
    }

    public void DecreaseLight(int amount, bool kill)
    {
        if (lightAngle <= minAmount + amoutToDie * lightIncrement && kill)
        {
            Player player = GetComponentInParent<Player>();
            player.Die();
        }
        lightAngle -= amount * lightIncrement;
        lightAngle = Mathf.Clamp(lightAngle, minAmount, maxAmount);
    }

    public void DecreaseLight(bool kill)
    {
        if (lightAngle <= minAmount + amoutToDie * lightIncrement && kill)
        {
            Player player = GetComponentInParent<Player>();
            player.Die();
        }
        lightAngle -= lightIncrement;
        lightAngle = Mathf.Clamp(lightAngle, minAmount, maxAmount);
    }
}
