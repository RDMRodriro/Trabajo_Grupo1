using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerstats1 : MonoBehaviour
{
    public int vida = 100;
    public GameObject panel;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "BalaEnemigo")
        {
            vida = vida - 10;
            Destroy(collision.transform.gameObject);

            if (vida == 0)
            {
                panel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

}
