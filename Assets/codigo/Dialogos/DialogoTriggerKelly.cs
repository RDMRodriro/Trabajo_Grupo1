using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoTriggerKelly : MonoBehaviour
{
    public dialogue Dialogo;
    public GameObject ImagenDialogos;
    public void DialogoTrigger()
    {
        ImagenDialogos.SetActive(true);
        FindObjectOfType<DialogoManagerKelly>().StartDialogue(Dialogo);
    }

    public void TriggerSalir()
    {
        ImagenDialogos.SetActive(false);
        //DestroyTrigger();
    }

    /*public void DestroyTrigger()
    {
        Destroy(gameObject);
    }*/
}
