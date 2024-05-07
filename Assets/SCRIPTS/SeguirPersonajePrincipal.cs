using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SeguirPersonajePrincipal : MonoBehaviour
{
    public Transform protagonista;
    public float rangoSeguimiento = 10f;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        SeguirProtagonista();
    }

    void SeguirProtagonista()
    {
        if (protagonista == null)
            return;

        float distancia = Vector3.Distance(protagonista.position, transform.position);

        if (distancia < rangoSeguimiento)
        {
            agent.SetDestination(protagonista.position);
        }
    }
}
