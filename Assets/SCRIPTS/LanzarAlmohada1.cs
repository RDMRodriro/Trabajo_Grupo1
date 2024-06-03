using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlmohadaLauncher : MonoBehaviour
{
    public GameObject Almohada;
    public Transform PointAlmohada;
    public float rango = 20f;
    public float speed;
    public float tiempoEntreLanzamientos = 2f;
    private float tiempoRestante;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void InstanciarAlmohada()
    {
        GameObject copiaAlmohada = Instantiate(Almohada, PointAlmohada.position, PointAlmohada.rotation);

        copiaAlmohada.GetComponent<Rigidbody>().AddForce(PointAlmohada.forward * rango, ForceMode.Impulse);

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Enemigo")
        {
            tiempoRestante -= Time.deltaTime;

            if (tiempoRestante <= 0f)
            {
                InstanciarAlmohada();
                ResetearTiempo();
            }
        }
    }

    void ResetearTiempo()
    {
        tiempoRestante = tiempoEntreLanzamientos;
    }

}

