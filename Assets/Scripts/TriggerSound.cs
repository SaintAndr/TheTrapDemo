using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    [SerializeField] private GameObject soundPlayer;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            PlaySound();
            hasPlayed = true;
        }
    }

    private void PlaySound()
    {
        if (soundPlayer != null)
        {
            AudioSource audioSource = soundPlayer.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
