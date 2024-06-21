using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eeventos_Animation : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FOOD"))
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
