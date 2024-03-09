using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    Light lightComp;
    [SerializeField] float lightAngle;
    [SerializeField] float delta = 20f;
    [SerializeField] float lightIncrement = 10f;
    
    void Start()
    {
        lightComp = GetComponent<Light>();
        lightAngle = lightComp.spotAngle;
    }
    public void IncreaseLight()
    {
        lightAngle += lightIncrement;
        lightComp.spotAngle = lightAngle;
        lightComp.innerSpotAngle = lightAngle - delta;
        Debug.Log(lightComp.spotAngle);
    }
    public void DecreaseLight()
    {
        lightAngle -= lightIncrement;
        lightComp.spotAngle = lightAngle;
        lightComp.innerSpotAngle = lightAngle - delta;
    }
}
