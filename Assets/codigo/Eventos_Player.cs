using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Eventos_Player : MonoBehaviour
{
    [SerializeField] private UnityEvent EntrarTrigger;
    [SerializeField] private UnityEvent ExitTrigger;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            EntrarTrigger.Invoke();
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            ExitTrigger.Invoke();
        }


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
