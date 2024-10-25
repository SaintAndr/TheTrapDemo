using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FlashlightToggle : MonoBehaviour
{
    [SerializeField] private GameObject lightGO;
    [SerializeField] private AudioClip turnOnSound;
    [SerializeField] private AudioClip turnOffSound;

    private bool isOn = false;
    private AudioSource audioSource;

    void Start()
    {
        lightGO.SetActive(isOn);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;
            if (isOn)
            {
                lightGO.SetActive(true);
                PlaySound(turnOnSound);
            }
            else
            {
                lightGO.SetActive(false);
                PlaySound(turnOffSound);
            }
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
