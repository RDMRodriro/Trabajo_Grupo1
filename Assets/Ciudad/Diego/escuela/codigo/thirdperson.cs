using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class thirdperson : MonoBehaviour
{
    public CharacterController controller;
    public float velocidad;
    public float speedW = 3f;
    public float speedR = 10f;

    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public Transform cam;

    Vector3 velocity;
    public float gravedad = -9.8f;
    public Transform groundCheck;
    public float groundDistance = 0.45f;
    public LayerMask groundMask;
    public bool isGrounded;
    public float JumpHeigh = 3f;

    Animator animator;
    bool isJump;
    bool isGround;

    
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    
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

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                velocidad = speedR;
            }
            else
            {
                velocidad = speedW;
            }

            Vector3 moverDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moverDir.normalized * velocidad * Time.deltaTime);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -9.8f;
            animator.SetBool("IsGrounded", true);
            isGround = true;
            animator.SetBool("IsJumping", false);
            isJump = false;
        }
        else 
        {
            animator.SetBool("IsGrounded", false);
            isGround = false;

            if((isJump && velocity.y <0))
            {
                animator.SetBool("IsFalling", true);
            }
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeigh * -2f * gravedad);
            animator.SetBool("IsJumping", true);
            isJump = true;
        }

        velocity.y += gravedad * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
