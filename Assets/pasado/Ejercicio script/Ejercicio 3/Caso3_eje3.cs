using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caso3_eje3 : MonoBehaviour
{
    public GameObject Cubo;
    public int Numero1, Numero2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Instancia();
        }

        Rotacion();
    }

    void Instancia()
    {
        Cubo = Instantiate(Cubo, transform.position, transform.rotation);
    }

    void Rotacion()
    {
        if(Numero1 == Numero2)
        {
            Cubo.transform.Rotate(5, 0, 0);
        }
    }
}
