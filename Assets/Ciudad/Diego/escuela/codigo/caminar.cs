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

    Animator animator;

    public GameObject cam1;
    public GameObject cam2;

    public GameObject BalaPlayer;
    public Transform pointerBala;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CambioCamaras();
    }

    void CambioCamaras()
    {
        if (Input.GetButton("Fire2"))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            GetComponent<thirdperson>().enabled = false;
            movimiento();
        }
        else
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            GetComponent<thirdperson>().enabled = true;
        }
    }

    void movimiento()
    {
        if (Input.GetButton("Fire1"))
        {
            animator.SetBool("AttackMagic", true);
            Disparo();
        }
        else
        {
            animator.SetBool("AttackMagic", false);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButton("Jump") && isGrounded)
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

    void Disparo()
    {
        Instantiate(BalaPlayer, pointerBala.position, transform.rotation);
    }
  }
