using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cilindro : MonoBehaviour
{
    public int numero1;
    public int numero2;
    private int resultado;
    public string nombre;
    void Start()
    {
        resultado = numero1 + numero2;
        Debug.Log("Hola" + nombre + "este es mi ejercicio");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(resultado , 0 , 0);
    }
}
