using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Tilin : MonoBehaviour
{
    public CharacterController controller;
    public float velocidad = 20f;
    Vector3 velocity;
    public float gravedad = -9.8f;
    public Transform groundCheck;
    public float groundDistance = 0.45f;
    public LayerMask groundMask;
    public bool isGrounded;
    public float JumpHeigh = 3f;
    //camaras
    public GameObject cam1;
    public GameObject cam2;
    public Animator animator;
    public GameObject BalaPlayer;
    public Transform PointerBala;
    public float tiempo;
    public float tiempoRestante;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        
    }

    
    void Update()
    {
        CambioCamaras();
    }

    void CambioCamaras()
    {
        if(Input.GetButton("Fire2"))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            GetComponent<TP_Script>().enabled = false;
            Movimiento();
        }
        else
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            GetComponent<TP_Script>().enabled = true;

        }
    }
    void Movimiento ()
    {
        if(Input.GetButton("Fire1"))
        {
            animator.SetBool("AttackMagic",true);
            Disparo();
        }
        else
        {
            animator.SetBool("AttackMagic",false);
        }

        
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input. GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * velocidad * Time.deltaTime);

            if(Input.GetButtonDown("Jump") && isGrounded)
                {
                    velocity.y = Mathf.Sqrt(JumpHeigh * -2f * gravedad);
                }

        velocity.y += gravedad * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Disparo()
    {
        tiempoRestante = tiempoRestante - Time.deltaTime;
        if(tiempoRestante <= 0f)
        {
            Instantiate(BalaPlayer, PointerBala.position, transform.rotation);
            Resetear();
        }

    void Resetear()
    {
        tiempoRestante = tiempo;
    }
    }







}
