using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Almohada : MonoBehaviour
{
    public Vector3 Direccion;
    public float speed;

    void Start()
    {
        Destroy(gameObject, 2f);
    }


    void Update()
    {
        transform.Translate(Direccion * speed * Time.deltaTime);
    }

}
