using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Canvas : MonoBehaviour
{
    public static Manager_Canvas unicaInstancia;
    private void Awake()
    {
        if (Manager_Canvas.unicaInstancia == null)
        {
            Manager_Canvas.unicaInstancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
