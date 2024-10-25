using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private GameObject soundBook;

    public HUDController HUDController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPickedUp();
            PlaySound();
        }
    }

    public void OnPickedUp()
    {
        HUDController.IncrementBookCount();
        HUDController.CollectBook();
        Destroy(gameObject);
    }
    private void PlaySound()
    {
        if (soundBook != null)
        {
            AudioSource audioSource = soundBook.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
