using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NaveEnemigo : MonoBehaviour 
{
private NavMeshAgent Agent;
public Transform pointer;
public float LookRadius = 80f;

//Animación
public Animator animator;
public float DistanceShoot = 30f;
//Bala
public GameObject Bala;
public Transform PointerBala;
    public float tiempo;
    public float tiempoRestante;
//vida
public int vida = 40;
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        
    }
    void Update()
    {
        float distancia = Vector3.Distance(pointer.position, transform.position);
        if(distancia <= LookRadius)
            {
                FaceTarget();
                Agent.SetDestination(pointer.position);
                animator.SetBool("Walk", true);
                Agent.speed = 5f;

                if(distancia<= DistanceShoot)
                {
                    animator.SetBool("Shoot", true);
                    Agent.speed = 0;
                    DispararBala();
                }
                else
                {
                    animator.SetBool("Shoot", false);
                }
            }
        else
            {
                animator.SetBool("Walk", false);
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

    void DispararBala ()
    {
        tiempoRestante = tiempoRestante - Time.deltaTime;
        if(tiempoRestante <= 0f)
        {
            Instantiate(Bala, PointerBala.position, transform.rotation);
            Resetear();
        }
    }
    void Resetear()
    {
        tiempoRestante = tiempo;
    }
    private void OnCollisionEnter (Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            vida = vida - 20;
            if (vida == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
