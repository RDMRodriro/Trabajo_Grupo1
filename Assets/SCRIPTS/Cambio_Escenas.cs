using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambio_Escenas : MonoBehaviour
{
    public GameObject PanelOptions;
    public GameObject PanelAudio;
    public GameObject PanelGraficos;


    public void Menuoptions()
    {
        PanelOptions.SetActive(true);
    }

    public void Menuoptionsclose()
    {
        PanelOptions.SetActive(false);
    }

    public void MenuAudio()
    {
        PanelAudio.SetActive(true);
    }

    public void MenuAudioClose()
    {
        PanelAudio.SetActive(false);
    }

    public void MenuGraficos()
    {
        PanelGraficos.SetActive(true);
    }

    public void MenuGraficosClose()
    {
        PanelGraficos.SetActive(false);
    }

    public void CargarEscena1()
    {
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }
}
