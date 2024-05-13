using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comida : MonoBehaviour
{
    public GameObject panelComida;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            panelComida.SetActive(true);
            Destroy(gameObject);
        }
    }
}
