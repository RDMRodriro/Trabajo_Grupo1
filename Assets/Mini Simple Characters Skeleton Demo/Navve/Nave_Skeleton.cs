using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nave_Skeleton : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform pointer;
    public float LookRadius = 80f;

    //Animación
    public Animator animator;
    public float DistanceShoot = 30f;
    //Bala
    //public GameObject Bala;
    public Transform PointerEspada;
    //vida
    public int vida = 40;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        MovimientoSkeleton();
    }

    public void MovimientoSkeleton()
    {
        float distancia = Vector3.Distance(pointer.position, transform.position);
        if(distancia <= LookRadius)
            {
                FaceTarget();
                Agent.SetDestination(pointer.position);
                animator.SetBool("Correr", true);
                Agent.speed = 5f;

                if(distancia<= DistanceShoot)
                {
                    animator.SetBool("Ataque", true);
                    Agent.speed = 0;
                    
                }
                else
                {
                    animator.SetBool("Ataque", false);
                }
            }
        else
            {
                animator.SetBool("Correr", false);
                Agent.speed = 0;
            } 
        Debug.Log(distancia);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, LookRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, DistanceShoot);
    }


    void FaceTarget ()
    {
        Vector3 direction = (pointer.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1f);
    }

    private void OnCollisionEnter (Collision collision)
    {
        if(collision.transform.tag == "AttackPlayer")
        {
            vida = vida - 8;
            if (vida <= 0)
            {
                EsqueletosContador.PuntosEsq += 1;
                Destroy(gameObject);
            }
        }
        if(collision.transform.tag == "Almohada")
        {
            vida = vida - 4;
            if (vida <= 0)
            {
                EsqueletosContador.PuntosEsq += 1;
                Destroy(gameObject);
            }
        }
    }

}
