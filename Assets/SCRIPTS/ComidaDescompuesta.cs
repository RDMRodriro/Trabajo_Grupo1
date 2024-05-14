using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComidaDescompuesta : MonoBehaviour
{
    public float cantidadDaño;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && other.GetComponent<Stats_Player>())
        {
            other.GetComponent<Stats_Player>().ComidaDaño(cantidadDaño);

            Destroy(gameObject);
        }
    }
}
