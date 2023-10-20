using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightDimmer : MonoBehaviour
{
    [SerializeField] private PointLight targetLight;
    [SerializeField] private float initialRange;
    [SerializeField] private float timer;
    [SerializeField] private float decreaseRate = 1f;

    private void Start()
    {
        targetLight = GetComponent<PointLight>();
        initialRange = targetLight.range;
        timer = 0f;
        InvokeRepeating("DecreaseLight", 10f, 10f);
    }

    private void DecreaseLight()
    {
        if (targetLight.range > 10f)
        {
            targetLight.range -= decreaseRate;
        }
        else
        {
            targetLight.range = 10f;
        }
    }
}

