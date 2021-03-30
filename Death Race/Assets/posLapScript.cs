using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class posLapScript : MonoBehaviour
{
    [SerializeField] int n_PlayerNo;
    int n_totalTriggersInTrack;
    public int n_triggerCollided;
    public int n_prevTriggerCollided;

    public int n_wrongWayCount;
    public int n_totalTriggersCollided;

    LapPosGameStatus lapPosGameStatus;

    private void Awake()
    {
        lapPosGameStatus = FindObjectOfType<LapPosGameStatus>();
        n_totalTriggersInTrack = lapPosGameStatus.n_totalTriggersInTrack;
    }

    private void OnTriggerEnter(Collider other)
    {
        n_triggerCollided = int.Parse(other.name);

        if (n_triggerCollided < n_prevTriggerCollided && n_triggerCollided != 0)
        {
            // This means user is driving in wrong direction.
            // Display wrong direction sign.
            // Increase n_WrongWayCount;
            // Also decrease the prevTriggerCollided.

            Debug.Log("WRONG WAY! TURN BACK!");
            n_wrongWayCount++;
            n_totalTriggersCollided--;

            n_prevTriggerCollided = n_triggerCollided;
           
            if (n_wrongWayCount >= 5) {
                // gameObject.transform.position = 
                Debug.Log("n_wrongWayCount = " + n_wrongWayCount + " put you back on the last collider in correct direction.");
            }





        }
        else if (n_triggerCollided > n_prevTriggerCollided) {
            // user in right direction.
            // increase n_totalTriggersCollided

            n_prevTriggerCollided = n_triggerCollided;
            n_totalTriggersCollided++;

            if (n_wrongWayCount > 0) {
                n_wrongWayCount =0;
            }


        }

        else if(n_triggerCollided == 0)
        {
            // This is finish line trigger.
            // Check if triggers collected is equal to total triggers.

            if (n_totalTriggersCollided == n_totalTriggersInTrack) 
            {
                lapPosGameStatus.n_LapsCompleted[n_PlayerNo - 1] = lapPosGameStatus.n_LapsCompleted[n_PlayerNo -1] + 1;

                n_prevTriggerCollided = n_triggerCollided;
                n_totalTriggersCollided = 0;

                /*n_LapsCompleted++;
                if (n_LapsCompleted == 3) 
                {
                    Debug.Log("You won");
                }*/
            }

        }
    }
}
