using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eeventos_Animation : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip Clip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }
}
