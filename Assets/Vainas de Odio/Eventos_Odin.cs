using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Eventos_Odin : MonoBehaviour
{
    [SerializeField] private UnityEvent EnterTrigger;
    [SerializeField] private UnityEvent ExitTrigger;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            EnterTrigger.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            ExitTrigger.Invoke();
        }
    }
}
