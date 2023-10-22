using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject finishCanvas;
    [SerializeField] private GameObject controlledObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (controlledObject != null)
            {
                controlledObject.GetComponent<FirstPersonController>().enabled = false;
            }

            if (finishCanvas != null)
            {
                finishCanvas.SetActive(true);
            }
        }
    }
}
