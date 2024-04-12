using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_cubo : MonoBehaviour
{
    public GameObject cubito;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cubito.transform.Rotate(0, 20, 0);
    }
}
