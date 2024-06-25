using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loki_Trigge_Vida : MonoBehaviour
{
    public GameObject BarraLoki;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BarraLoki.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BarraLoki.SetActive(false);
        }
    }
}
