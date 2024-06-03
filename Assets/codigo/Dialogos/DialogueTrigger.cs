using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public dialogue Dialogo;
    public GameObject ImagenDialogos;
    // Start is called before the first frame update
    public void DialogoTrigger()
    {
        ImagenDialogos.SetActive(true);
        FindObjectOfType<DialogoManager>().StartDialogue(Dialogo);
    }

    public void TriggerSalir()
    {
        ImagenDialogos.SetActive(false);
    }
}
