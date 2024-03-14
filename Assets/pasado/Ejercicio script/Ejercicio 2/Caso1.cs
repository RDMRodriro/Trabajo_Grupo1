using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caso1 : MonoBehaviour
{
    public GameObject Cubodeprueba1 , Esferadeprueba1 ;
    public float valor1 , valor2 , valor3 ;

    // Start is called before the first frame update
    void Start()
    {
        mensaje();
    }

    // Update is called once per frame
    void Update()
    {
        Suma();
    }

    void Suma()
    {
        valor3 = valor1 + valor2;
        Cubodeprueba1.transform.Translate(valor3 , 0 , 0);
    }

    void mensaje()
    {
        Debug.Log("Eso Tilin");
    }

}
