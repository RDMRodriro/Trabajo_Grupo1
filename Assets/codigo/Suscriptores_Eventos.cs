using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suscriptores_Eventos : MonoBehaviour
{
    public GameObject player;
    public Vector3 escala;
    public Vector3 escalaNormal;
    
    public void EscalaPlayer()
    {
        player.transform.localScale = escala;
    }
    public void EscalaNormalPlayer()
    {
        player.transform.localScale = escalaNormal;
    }

    public void RotacionCubitoON()
    {
        GetComponent<Rotate_cubo>().enabled = true;
    }

    public void RotacionCubitoOFF()
    {
        GetComponent<Rotate_cubo>().enabled = false;
    }

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
