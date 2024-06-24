using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stats_Player : MonoBehaviour
{
    public Image barradevida;
    public float vidaActual = 100;
    public float vidaMaxima = 100;
    public GameObject panel;

    //del xavi
    public GameObject Tpmuerte;

    void Start()
    {
        
    }

    
    void Update()
    {
        barradevida.fillAmount = vidaActual / vidaMaxima;
    }

    private void OnCollisionEnter (Collision collision)
    {
        if(collision.transform.tag == "BalaEnemigo")
        {
            vidaActual = vidaActual - 10;
            if (vidaActual == 0)
            {
                panel.SetActive(true);
                Time.timeScale = 0;
            }
        }
        /*if(collision.transform.tag == "EspadaSkeleton")
        {
            vidaActual = vidaActual - 5;
            if (vidaActual == 0)
            {
                panel.SetActive(true);
                Time.timeScale = 0;
            }
        }*/
    }
    private void OnTriggerEnter (Collider other)
    {
        if(other.transform.tag == "EspadaSkeleton")
        {
            vidaActual = vidaActual - 5;
            if (vidaActual == 0)
            {
                panel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    public void ComidaDaño (float Daño)
    {
        vidaActual -= Daño;
        if (vidaActual == 0)
        {
            panel.SetActive(true);
                Time.timeScale = 0;
        }
    }
    public void ComidaCura (float cura)
    {
        vidaActual += cura;
        if (vidaActual > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
    }

    //Xavier hizo codigo aqui uwu

    public void ContinuarPartida()
    {
        vidaActual = 100;
        panel.SetActive(false);
        Time.timeScale = 1;
        Tpmuerte.SetActive(false);
    }

    public void CuboGuardado()
    {
        if (vidaActual == 0)
        {
            Tpmuerte.SetActive(true);
        }
    }
}
