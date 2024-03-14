using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Vertical"))
        {
            anim.SetBool("Caminando", true);
        }

        if(Input.GetButtonUp("Vertical"))
        {
            anim.SetBool("Caminando", false);
        }

    }
}
