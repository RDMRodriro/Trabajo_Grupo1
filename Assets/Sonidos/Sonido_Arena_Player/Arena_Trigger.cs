using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena_Trigger : MonoBehaviour
{
    public AudioClip arenaClip;
    private AudioSource audioSource;
    private bool isInArena = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on the player.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arena"))
        {
            isInArena = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Arena"))
        {
            isInArena = false;
        }
    }

    public void PlayArenaSound()
    {
        if (isInArena && audioSource != null && arenaClip != null)
        {
            audioSource.PlayOneShot(arenaClip);
        }
    }
}
