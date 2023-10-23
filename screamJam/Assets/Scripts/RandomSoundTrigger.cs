using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundClips;
    [SerializeField] private AudioSource[] audioSource;
    [SerializeField] private float invokingAfterTime = 10f;
    [SerializeField] private int durationBetweenInvoking = 23;

    private void Start()
    {
        InvokeRepeating("PlayRandomSound", invokingAfterTime, durationBetweenInvoking);
    }

    private void PlayRandomSound()
    {

        int randomIndexSource = Random.Range(0, audioSource.Length);
        int randomIndex = Random.Range(0, soundClips.Length);
        audioSource[randomIndexSource].clip = soundClips[randomIndex];
        audioSource[randomIndexSource].Play();

    }
}
