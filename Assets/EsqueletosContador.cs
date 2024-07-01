using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsqueletosContador : MonoBehaviour
{
    public static EsqueletosContador instance;
    public static int PuntosEsq = 0;
    public BoxCollider PuertaEntrada;

    void Start()
    {
        PuertaEntrada = GetComponent<BoxCollider>();
    }

    void Update()
    {
        
    }

    public void Contador()
    {
        if (PuntosEsq == 30) 
        {
            PuertaEntrada.isTrigger = true;
        }
    }
}
