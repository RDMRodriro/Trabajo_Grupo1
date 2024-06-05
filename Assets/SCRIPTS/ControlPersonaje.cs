using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControlPersonaje : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    private Transform protagonista;

    public float distanciaSeguir = 10f;
    public float distanciaDetenerse = 5f;
    public float distanciaAtaque = 2f;
    public LayerMask enemigoLayer;

    public int vida = 100;


    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        protagonista = GameObject.FindGameObjectWithTag("Player").transform;

        agent.speed = 3f;
    }

    void Update()
    {
        if (protagonista == null)
            return;

        float distanciaProtagonista = Vector3.Distance(transform.position, protagonista.position);

        if (distanciaProtagonista <= distanciaSeguir)
        {
            agent.SetDestination(protagonista.position);

            if (distanciaProtagonista <= distanciaDetenerse)
            {
                agent.isStopped = true;
                animator.SetBool("IsWalking", false);
            }
            else
            {
                agent.isStopped = false;
                animator.SetBool("IsWalking", true);
            }
        }
        else
        {
            agent.isStopped = true;
            animator.SetBool("IsWalking", false);
        }

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, distanciaAtaque, enemigoLayer);
        if (hitColliders.Length > 0)
        {
            animator.SetTrigger("Attack");
        }
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, distanciaSeguir);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanciaDetenerse);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaAtaque);
    }
}
