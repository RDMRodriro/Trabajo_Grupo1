using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsqueletosContador : MonoBehaviour
{
    public static int score = 0;
    
    public GameObject Cubo;
    public GameObject CuboTrigger;

    void Start()
    {
       
    }

    void Update()
    {
        if (score >= 25)
        {
            Cubo.SetActive(false);
            CuboTrigger.SetActive(true);
        }

        EnemyFast();
    }

    public void ActualizarScore()
    {
        score++;
    }

    public void EnemyFast()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            score = 24;
        }
    }
}
