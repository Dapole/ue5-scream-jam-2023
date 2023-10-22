using UnityEngine;
using UnityEngine.Serialization;

public class LightDimmer : MonoBehaviour
{
    private Light targetLight;
    [SerializeField] private GameObject UIToActivate;
    
   public float decreaseRadiusRate = 1f;
   public float decreaseIntensityRate = 0.1f;
   public float minLightRange = 10f;
   public float invokingAfterTime = 10f;
   public int durationBetweenInvoking = 10;
    
    private void Start()
    {
        targetLight = GetComponent<Light>();
        InvokeRepeating("DecreaseLight", invokingAfterTime, durationBetweenInvoking);
    }

    private void DecreaseLight()
    {
        if (targetLight.range > minLightRange)
        {
            targetLight.range -= decreaseRadiusRate;
        }
        else
        {
            targetLight.intensity -= decreaseIntensityRate;
        }
        if (targetLight.intensity <= 0)
        {
            FindObjectOfType<GameManager>().ChangeGameState(UIToActivate, true);
            CancelInvoke("DecreaseLight");
        }
    }
}

