using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evaluacion : MonoBehaviour
{
    public int Numero1, Numero2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Numero1 == Numero2)
        {
            Debug.Log("Los Numeros son iguales");
        }
    }
}
