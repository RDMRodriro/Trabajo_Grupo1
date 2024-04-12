using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    public Vector3 Direccion;
    public float speed;

    void Start()
    {
        Destroy(gameObject, 2f);
        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
    }

    void Update()
    {
        transform.Translate(Direccion * speed * Time.deltaTime);
    }
}