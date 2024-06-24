using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpsPlayer : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (transform.position == pointA.position)
            {
                Teleport(other.transform, pointB.position);
            }
            else if (transform.position == pointC.position)
            {
                Teleport(other.transform, pointD.position);
            }
        }
    }

    private void Teleport(Transform player, Vector3 targetPosition)
    {
        player.position = targetPosition;
    }
}
