using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    float RotacionVertical;
    public float Sensibilidad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotacionVertical = Input.GetAxis("Mouse Y");
        Vector3 RotacionX = new Vector3(RotacionVertical, 0, 0);
        transform.Rotate(RotacionX * Sensibilidad);
    }
}
