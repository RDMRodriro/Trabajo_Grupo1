using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilinAnimación : MonoBehaviour
{
    Animator animator;
    const float AnimationSmoothTime = 0.05f;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(x, 0f, z).normalized;

        float Magnitud = Mathf.Clamp01(move.magnitude);

        if (Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.RightShift))
            {
                Magnitud /= 0.5f;
            }

        animator.SetFloat("SpeedPercent", Magnitud, AnimationSmoothTime, Time.deltaTime);
        
        /*if (Input.GetButton("Fire1"))
        {
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }*/
    }

}