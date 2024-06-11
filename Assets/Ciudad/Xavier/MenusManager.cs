using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusManager : MonoBehaviour
{
    [SerializeField] public GameObject menuPausa;
    [SerializeField] public GameObject botonPausa;
    [SerializeField] public GameObject panelMuerte;

    public void Pausa()
    {
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
        botonPausa.SetActive(false);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
        botonPausa.SetActive(true);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        menuPausa.SetActive(false);
        botonPausa.SetActive(true);
        panelMuerte.SetActive(false);
    }

    public void Cerrar()
    {
        Debug.Log("Cerrando juego");
        Application.Quit();
    }
}
