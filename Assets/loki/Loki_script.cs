using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Loki_script : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform pointer;
    public float LookRadius = 20f;
    public float DistanciaMagia = 10f;
    public float ataque = 5f;
    public Animator animator;
    public GameObject Magia;
    public Transform PointerMagia;
    public GameObject ColliderAttack;
    public float tiempo;
    public float tiempoRestante;

    //public int vida;
    public GameObject comida;
    public GameObject OdinDialogo;
    public GameObject Escuela;
    public GameObject EscuelaEnemigos;
    public GameObject LokiVidaDestroy;
    // Start is called before the first frame update

    public Image barradevida;
    public float vidaActual = 200;
    public float vidaMaxima = 200;

    //Xavier

    public GameObject Cubo;
    public GameObject CuboTrigger;



    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        barradevida.fillAmount = vidaActual / vidaMaxima;
        MovimientoNaveMesh();
        
    }
    public void  MovimientoNaveMesh()
    {
        float distancia = Vector3.Distance(pointer.position, transform.position);

        if (distancia <= LookRadius)
        {
            FaceTarget();
            Agent.SetDestination(pointer.position);
            animator.SetBool("Correr", true);
            Agent.speed = 5f;

            if (distancia <= DistanciaMagia)
            {
                animator.SetBool("Ataque", true);
                Agent.speed = 0f;
                DisparaMagia();
            }
            else
            {
                animator.SetBool("Ataque", false);
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
        Gizmos.DrawWireSphere(transform.position, DistanciaMagia);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, ataque);

    }

    void FaceTarget()
    {
        Vector3 direction = (pointer.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1f);
    }

    void DisparaMagia()
    {
        tiempoRestante = tiempoRestante - Time.deltaTime;

        if (tiempoRestante <= 0f)
        {
            Instantiate(Magia, PointerMagia.position, transform.rotation);
            Resetear();
        }

    }

    private void Resetear()
    {
        tiempoRestante = tiempo;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            vidaActual = vidaActual - 20;

            if (vidaActual <= 0)
            {
                Destroy(gameObject);
                comida.SetActive(true);
                OdinDialogo.SetActive(true);
                EscuelaEnemigos.SetActive(true);
                Escuela.SetActive(false);
                Destroy(LokiVidaDestroy);
            }
            if (vidaActual <= 0)
            {
                Cubo.SetActive(false);
                CuboTrigger.SetActive(true);
            }
        }

        if (collision.transform.tag == "Almohada")
        {
            vidaActual = vidaActual - 10;

            if (vidaActual <= 0)
            {
                Destroy(gameObject);
                comida.SetActive(true);
                OdinDialogo.SetActive(true);
                EscuelaEnemigos.SetActive(true);
                Escuela.SetActive(false);
            }
        }

    }

}
