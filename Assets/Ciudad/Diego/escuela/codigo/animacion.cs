using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacion : MonoBehaviour
{
    Animator animator;
    const float AnimationSmoothTime = 0.05f;
    public GameObject ColliderAttack;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(x, 0f, z);

        float Magnitud = Mathf.Clamp01(move.magnitude);
        if (Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.RightShift));
        {
            Magnitud /= 0.5f;
        }

        animator.SetFloat("SpeedPercent", Magnitud, AnimationSmoothTime, Time.deltaTime);

        if (Input.GetButton("Fire1"))
        {
            animator.SetBool("Attack", true);
            ColliderAttack.SetActive(true);
        }
        else
        {
            animator.SetBool("Attack", false);
            ColliderAttack.SetActive(false);
        }



    }
}
