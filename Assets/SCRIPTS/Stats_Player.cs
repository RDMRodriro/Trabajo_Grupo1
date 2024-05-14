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
            Destroy(collision.transform.gameObject);
            if (vidaActual == 0)
            {
                panel.SetActive(true);
                Time.timeScale = 0;
            }
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
}
