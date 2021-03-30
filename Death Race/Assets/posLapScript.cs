using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class posLapScript : MonoBehaviour
{
    [SerializeField] int n_PlayerNo;
    int n_totalTriggersInTrack;
   // public int n_triggerCollided;
    public int n_prevTrigger;
    public int n_nextTrigger = 1;

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
        int n_triggerCollided = int.Parse(other.name);

        if (n_triggerCollided == n_nextTrigger)
        {
            n_totalTriggersCollided++;
            // correct path
            if (n_triggerCollided == 0 && n_totalTriggersCollided == n_totalTriggersInTrack)
            {
                // you have collided finish line after completing the track and collection all colliders -> increase Lap count
                lapPosGameStatus.n_LapsCompleted[n_PlayerNo - 1] = lapPosGameStatus.n_LapsCompleted[n_PlayerNo - 1] + 1;
                n_totalTriggersCollided = 0;
            }

            n_nextTrigger++;

            if (n_nextTrigger >= n_totalTriggersInTrack)
            {
                n_nextTrigger = 0;
            }
        }
        else if (n_triggerCollided < n_nextTrigger - 1)
        {
            Debug.Log("Wrong Direction");
            n_wrongWayCount++;

            if (n_wrongWayCount >= 5)
            {
                // now we will set the car to its needed collider position i.e nextTrigger

                GameObject nextTriggerObj = GameObject.Find(n_nextTrigger.ToString());


                gameObject.transform.position = nextTriggerObj.transform.position;
              //  gameObject.transform.rotation = nextTriggerObj.transform.rotation;

                n_wrongWayCount = 0;

            }
        }

        // this happens when you collide with first 2,3 tirggers and then travel in back direction and collide with 0(finish line ) and then collide with 8th trigger.
        // the wrongWayCount won't increase if only above 2 conditions are kept
        else if (n_triggerCollided > n_nextTrigger) { 
            // now we will set the car to its needed collider position i.e nextTrigger

                GameObject nextTriggerObj = GameObject.Find(n_nextTrigger.ToString());


                gameObject.transform.position = nextTriggerObj.transform.position;
              //  gameObject.transform.rotation = nextTriggerObj.transform.rotation;

                n_wrongWayCount = 0;
        }

        /*if (n_triggerCollided < n_prevTrigger && n_triggerCollided != 0)
        {
            // This means user is driving in wrong direction.
            // Display wrong direction sign.
            // Increase n_WrongWayCount;
            // Also decrease the prevTriggerCollided.

            Debug.Log("WRONG WAY! TURN BACK!");
            n_wrongWayCount++;
            if (n_totalTriggersCollided > 0) {
                n_totalTriggersCollided--;
            }

            n_prevTrigger = n_triggerCollided;
           
            if (n_wrongWayCount >= 5) {
                // gameObject.transform.position = 
                Debug.Log("n_wrongWayCount = " + n_wrongWayCount + " put you back on the last collider in correct direction.");
            }





        }
        else if (n_triggerCollided > n_prevTrigger) {
            // user in right direction.
            // increase n_totalTriggersCollided

            n_prevTrigger = n_triggerCollided;
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

                n_prevTrigger = n_triggerCollided;
                n_totalTriggersCollided = 0;

                *//*n_LapsCompleted++;
                if (n_LapsCompleted == 3) 
                {
                    Debug.Log("You won");
                }*//*
            }
            else if(n)

        }*/
    }
}
