using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationTrigger : MonoBehaviour
{
    [SerializeField] private GameObject activationTrigger;
    [SerializeField] private GameObject doll;
    [SerializeField] private GameObject moveDoll;

    private void OnTriggerEnter(Collider other)
    {
        activationTrigger.SetActive(true);
        doll.SetActive(false);
        moveDoll.SetActive(true);
    }
}
