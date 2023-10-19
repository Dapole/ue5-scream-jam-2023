using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundClips;
    [SerializeField] private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void PlayRandomSound()
    {
        if (soundClips.Length > 0)
        {
            int randomIndex = Random.Range(0, soundClips.Length);
            audioSource.clip = soundClips[randomIndex];
            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayRandomSound();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayRandomSound();
        }
    }
}
