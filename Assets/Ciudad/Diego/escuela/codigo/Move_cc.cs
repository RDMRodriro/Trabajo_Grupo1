using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_cc : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    public Transform cam;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    Vector3 velocity;
    public float gravedad = -9.8f;
    public Transform groundCheck;
    public float groundDistance = 0.45f;
    public LayerMask groundMask;
    public bool isGrounded;
    public float JumpHeigt = 3f;
    void Update()
    {
        

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.localEulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moverDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moverDir.normalized * speed * Time.deltaTime);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -9.8f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeigt * -2f * gravedad);
        }
        velocity.y += gravedad * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
