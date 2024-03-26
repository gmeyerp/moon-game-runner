using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    Light lightComp;
    [SerializeField] float lightAngle;
    [SerializeField] float delta = 20f;
    [SerializeField] float lightIncrement = 10f;
    [SerializeField][Range(0.1f, 1f)] float lerpSpeed = 0.2f;
    
    void Start()
    {
        lightComp = GetComponent<Light>();
        lightAngle = lightComp.spotAngle;
    }

    void Update()
    {
        lightComp.spotAngle = Mathf.Lerp(lightComp.spotAngle, lightAngle, lerpSpeed);
        lightComp.innerSpotAngle = Mathf.Lerp(lightComp.innerSpotAngle, lightAngle - delta, lerpSpeed);
    }

    public void IncreaseLight()
    {
        lightAngle += lightIncrement;
        ///lightComp.spotAngle = lightAngle;
        //lightComp.innerSpotAngle = lightAngle - delta;
    }
    public void DecreaseLight(float amount)
    {
        if (lightAngle == amount)
        {
            Player player = GetComponentInParent<Player>();
            player.Die();
        }
        lightAngle = amount;
        
        //lightComp.spotAngle = lightAngle;
        //lightComp.innerSpotAngle = lightAngle - delta;
    }
}
