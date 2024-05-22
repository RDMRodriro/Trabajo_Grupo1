using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subs_Odin : MonoBehaviour
{
    public GameObject Panel;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarCanvas()
    {
        Panel.SetActive(true);
    }

    public void DesactivarCanvas()
    {
        Panel.SetActive(false);
    }
}
