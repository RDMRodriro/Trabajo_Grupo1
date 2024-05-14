using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comida : MonoBehaviour
{
    public GameObject panelComida;
    public float cantidadCura;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && other.GetComponent<Stats_Player>())
        {
            panelComida.SetActive(true);
            other.GetComponent<Stats_Player>().ComidaCura(cantidadCura);

            Destroy(gameObject);
        }
    }
}
