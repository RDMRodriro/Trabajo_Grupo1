using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public float Velocidad;
    float MoverHorizontal;
    float MoverVertical;
    float RotarHorizontal;
    public float Sensibilidad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
    }

    void Mover()
    {
        MoverHorizontal = (Input.GetAxis("Horizontal"));
        MoverVertical = (Input.GetAxis("Vertical"));
        RotarHorizontal = Input.GetAxis("Mouse X");

        Vector3 Movimiento = new Vector3(MoverHorizontal, 0, MoverVertical);
        Vector3 RotacionX = new Vector3(0, RotarHorizontal, 0);

        transform.Translate(Movimiento * Velocidad);
        transform.Rotate(RotacionX * Sensibilidad);
    }
}
