using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpscongravedad : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float speedW = 3f;
    public float speedR = 10f;

    Vector3 velocity;
    public float gravedad = -9.8f;
    public Transform groundCheck;
    public float groundDistance = 0.45f;
    public LayerMask groundMask;
    public bool isGrounded;
    public float JumpHeigt = 3f;

    void Update()
    {
         isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButton("Jump")&& isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeigt * -2f * gravedad);
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.RightShift))
            {
                speed = speedR;
            }
            else
            {
                speed = speedW;
            }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravedad * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
    }
        
}
