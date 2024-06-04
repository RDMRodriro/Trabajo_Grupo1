using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambio_Escenas : MonoBehaviour
{
    public GameObject PanelOptions;


    public void Menuoptions()
    {
        PanelOptions.SetActive(true);
    }

    public void Menuoptionsclose()
    {
        PanelOptions.SetActive(false);
    }

    public void CargarEscena1()
    {
        SceneManager.LoadScene(1);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }

}
