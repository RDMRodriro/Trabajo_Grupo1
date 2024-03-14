using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float mouseSense = 100f;
    public Transform PlayerBody;
    public float RotationX = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseY = -Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime; // Invertir mouseY

        RotationX -= mouseY;
        RotationX = Mathf.Clamp(RotationX, -90, 90f);

        transform.localRotation = Quaternion.Euler(RotationX, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }

}
