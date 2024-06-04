using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Almohada : MonoBehaviour
{
    public GameObject particulaExplosion;
    public float delay = 3f;
    public float radius = 20f;
    public float FuerzaExplosion = 30f;


    void Start()
    {
        Invoke("ExplotarAlmohada", delay);
    }

    void Update()
    {

    }

    void ExplotarAlmohada()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider cercano in colliders)
        {
            Rigidbody rb = cercano.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(FuerzaExplosion, transform.position, radius, 1f, ForceMode.Impulse);
            }
            Instantiate(particulaExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }


}
