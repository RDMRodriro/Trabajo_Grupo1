using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlmohadaLauncher : MonoBehaviour
{
    public GameObject Almohada;
    public Transform PointAlmohada;
    public float rango = 20f;
    //public Vector3 ejes;
    //public Vector3 Direccion;
    public float speed;
   
   

    void Start()
    {

    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.G))
        {
            InstanciarAlmohada();
        }*/
    }

    void InstanciarAlmohada()
    {
        GameObject copiaAlmohada = Instantiate(Almohada, PointAlmohada.position, PointAlmohada.rotation);

        copiaAlmohada.GetComponent<Rigidbody>().AddForce(PointAlmohada.forward * rango, ForceMode.Impulse);

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Almohada")
        {
            InstanciarAlmohada();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }
}

