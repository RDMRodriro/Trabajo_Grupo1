using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Audio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    public void AttackEnemigo()
    {
        audioSource.PlayOneShot(clip);
    }
}
