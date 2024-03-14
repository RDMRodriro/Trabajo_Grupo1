using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public CharacterController controller;
    public float velocidad = 12f;

    Vector3 velocity;
    public float gravedad = -9.8f;
    public Transform groundCheck;
    public float groundDistance = 0.45f;
    public LayerMask groundMask;
    public bool isGrounded;
    public float JumpHeigh = 3f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * velocidad * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeigh * -2f * gravedad);
        }

        velocity.y += gravedad * Time.deltaTime;
    }

}
