using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambio_Escenas : MonoBehaviour
{
    public GameObject PanelOptions;
    public GameObject PausaMenu;
    public GameObject PanelAudio;
    public GameObject PanelGraficos;

    public void MenuPausa()
    {
        PausaMenu.SetActive(true);
        Time.timeScale = 0f;

    }

    public void MenuPausaClose()
    {
        PausaMenu.SetActive(false);
        Time.timeScale = 1f;
    }

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
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            SceneManager.LoadScene(1);
        }
    }

    public void Cerrar()
    {
        Debug.Log("Cerrando juego");
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
