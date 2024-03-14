using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caminar : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 20f;
     
    Vector3 velocity;
    public float gravedad = -9.8f;
    public Transform groundCheck;
    public float groundDistance = 0.45f;
    public LayerMask groundMask;
    public bool isGrounded;
    public float JumpHeigt = 3f;

   
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

        if (Input.GetButton("Jump")&& isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeigt * -2f * gravedad);
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravedad * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
