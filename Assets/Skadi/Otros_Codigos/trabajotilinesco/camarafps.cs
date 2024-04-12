using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camarafps : MonoBehaviour
{
     public float sensibilidad = 90f;
    public Transform PlayerBody;
    public float xRotacion = 0f;
    

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        xRotacion -= mouseY;
        xRotacion = Mathf.Clamp(xRotacion, -90f, 90f);
        PlayerBody.Rotate(Vector3.up * mouseX);

        transform.localRotation = Quaternion.Euler(xRotacion, 0f, 0f);
    }
}
