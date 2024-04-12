using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPlayer : MonoBehaviour
{
    public int vida = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "BalaEnemigo")
        {
            vida = vida - 10;
            Destroy(collision.transform.gameObject);
            if (vida == 0)
            {
                Time.timeScale = 0;
            }
        }
        
    }
}
