using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapPosTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        int n_playerCollided;
        n_playerCollided = other.GetComponent<CarMovement>().o_playerNumber;
    }
}
