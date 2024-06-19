using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento_Animacion_Protagonista : MonoBehaviour
{
    public AudioSource AudioSource;
    public Transform PointerParticulas;
    public AudioClip ClipAtaque;
   // public AudioClip ClipCorrer;
    public GameObject particulaAtaque;
    //public GameObject particulaCorrer;
    //public Transform PointerParticulasCorrer;

    public void EfectoAtaque()
    {
        AudioSource.PlayOneShot(ClipAtaque);
        Instantiate(particulaAtaque, PointerParticulas);
    }

     /*private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Arena")
        {
            AudioSource.PlayOneShot(ClipCorrer);
            //Instantiate(particulaCorrer, PointerParticulasCorrer);
        }
    }*/

}
