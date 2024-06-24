using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpsPlayer : MonoBehaviour
{
    public Transform Target;
    public GameObject ThePlayer;

    private void OnTriggerEnter(Collider other)
    {
        ThePlayer.transform.position = Target.transform.position;
    }
}