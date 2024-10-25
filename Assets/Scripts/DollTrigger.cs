using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollTrigger : MonoBehaviour
{
    [SerializeField] private GameObject soundDoll;
    [SerializeField] private GameObject triggerDoll;
    [SerializeField] private Transform moveDoll;
    [SerializeField] private float speed;
    private bool isTrigger = false;

    private void Update()
    {
        if (isTrigger)
        {
            moveDoll.position = Vector3.MoveTowards(moveDoll.position, new Vector3(6.27f, 1.562f, 3), Time.deltaTime * speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrigger = true;
            PlaySound();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerDoll.SetActive(false);
        }
    }
    private void PlaySound()
    {
        if (soundDoll != null)
        {
            AudioSource audioSource = soundDoll.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
