using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraPickUp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI firstTaskText;
    [SerializeField] private TextMeshProUGUI secondTaskText;
    [SerializeField] private TextMeshProUGUI booksValueText;
    [SerializeField] private GameObject soundTakeCamera;

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
        Destroy(gameObject);
        firstTaskText.gameObject.SetActive(false);
        booksValueText.gameObject.SetActive(true);
        secondTaskText.gameObject.SetActive(true);

    }
    private void PlaySound()
    {
        if (soundTakeCamera != null)
        {
            AudioSource audioSource = soundTakeCamera.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
