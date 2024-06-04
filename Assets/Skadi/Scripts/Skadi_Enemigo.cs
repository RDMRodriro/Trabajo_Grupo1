using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skadi_Enemigo : MonoBehaviour
{
    private NavMeshAgent Agent;
    public Transform pointer;
    public float LookRadius = 50f;
    public float Stararrow = 20f;
    public Animator animator;
    public GameObject Flecha;
    public Transform PointerFlecha;

    public float tiempo;
    public float tiempoRestante;

    public int vida;


    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float distancia = Vector3.Distance(pointer.position, transform.position);

        if (distancia <= LookRadius)
        {
            FaceTarget();
            Agent.SetDestination(pointer.position);
            animator.SetBool("Correr", true);
            Agent.speed = 5f;

            if (distancia <= Stararrow)
            {
                animator.SetBool("Flechazo", true);
                Agent.speed = 0f;
                DisparaBala();
            }
            else
            {
                animator.SetBool("Flechazo", false);
            }
        }
        else
        {
            animator.SetBool("Correr", false);
            Agent.speed = 0f;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, LookRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Stararrow);
    }

    void FaceTarget()
    {
        Vector3 direction = (pointer.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1f);
    }

    void DisparaBala()
    {
        tiempoRestante = tiempoRestante - Time.deltaTime;

        if (tiempoRestante <= 0f)
        {
            Instantiate(Flecha, PointerFlecha.position, transform.rotation);
            Resetear();
        }
    }

    void Resetear()
    {
        tiempoRestante = tiempo;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "AttackPlayer")
        {
            vida = vida - 20;

            if (vida == 0)
            {
                Destroy(gameObject);
            }
        }

        if (collision.transform.tag == "Almohada")
        {
            vida = vida - 10;

            if (vida == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}