using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LapPosCalculator : MonoBehaviour
{ 

    public int n_PlayerNo;          // Atached on the car prefab via LevelManager.cs and it has player no as 1,2,....
    int n_totalTriggersInTrack;

    public int n_prevTrigger;
    public int n_nextTrigger = 1;

    public int n_wrongWayCount;
    public int n_totalTriggersCollided;

    private string n_gameMode;

    GameStatus gameStatus;
    GameManager gameManager;

 

    private void Awake()
    {
        /*gameStatus = FindObjectOfType<GameStatus>();
        n_totalTriggersInTrack = gameStatus.n_totalTriggersInTrack;
        Debug.Log("Total Triggers in Track : Awake() - " + n_totalTriggersInTrack);*/

        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start() {
        gameStatus = FindObjectOfType<GameStatus>();
        n_totalTriggersInTrack = gameStatus.n_totalTriggersInTrack;
        //   Debug.Log("Total Triggers in Track : Awake() - " + n_totalTriggersInTrack);
        n_gameMode = gameManager.o_gameMode;
    }
    private void OnTriggerEnter(Collider other)
    {
         //if (gameManager.o_gameMode == "Multiplayer" && other.gameObject.CompareTag("Checkpoints"))
         if (other.gameObject.CompareTag("Checkpoints"))
         {
        
            int n_triggerCollided = int.Parse(other.gameObject.name.ToString());

            if (n_triggerCollided == n_prevTrigger + 1) {
                // Diable the wrong way msg
                gameStatus.DisableWrongWayMsg(n_PlayerNo);
                if (n_wrongWayCount > 0) {
                    n_wrongWayCount--;
                }
                
            }

            n_prevTrigger = n_triggerCollided;

            if (n_triggerCollided == n_nextTrigger)
            {
                // Debug.Log("In the condition n_triggerCollided = n_nextTrigger");


                gameStatus.DisableWrongWayMsg(n_PlayerNo);

                n_totalTriggersCollided++;

                n_wrongWayCount = 0;

               // Debug.Log("-- n_totalTriggersCollided = "+ n_totalTriggersCollided);
                // correct path
                if (n_triggerCollided == 0 && n_totalTriggersCollided == n_totalTriggersInTrack)
                {
                    //Debug.Log("-- In the If condition n_triggerCollided = 0 and n_totaltriggerCollided = n_totalTriggersInTrack");
                    // you have collided finish line after completing the track and collection all colliders -> increase Lap count
                    gameStatus.n_LapsCompleted[n_PlayerNo - 1] = gameStatus.n_LapsCompleted[n_PlayerNo - 1] + 1;
                    n_totalTriggersCollided = 0;
                }
                // need to save the totalTriggersCollided of each player to the Lap manager script where it will compare both players data and decide their position.
                // Here we save it to LapPosGameStatus.cs file.
                gameStatus.n_TriggersCollected[n_PlayerNo - 1] = n_totalTriggersCollided;
               // Debug.Log("----> n_nextTrigger = " + n_nextTrigger );
                n_nextTrigger++;
               // Debug.Log("----> n_nextTrigger = " + n_nextTrigger);
               // Debug.Log("----> n_totalTriggersInTrack = " + n_totalTriggersInTrack);


                if (n_nextTrigger >= n_totalTriggersInTrack)
                {
                   // Debug.Log("------ In if conditionn_nextTrigger >= n_totaltriggersInTrack");

                    //Debug.Log("------> n_nextTrigger = " + n_nextTrigger);

                    n_nextTrigger = 0;
                }
            }
            else if (n_triggerCollided < n_nextTrigger - 1)
            {
                //Debug.Log("In the condition n_triggerCollided < n_nextTrigger");

               // Debug.Log("Wrong Direction");
                n_wrongWayCount++;

                // Display wrong way txt.
                gameStatus.ShowWrongWayMsg(n_PlayerNo);

                if (n_wrongWayCount >= 5)
                {
                    // Now we need to respawn the car to the prev checkpoint/trigger.

                    RespawnAtPrevPos();

                    // Disable wrong way text.
                    gameStatus.DisableWrongWayMsg(n_PlayerNo);

                }
            }

            // this happens when you collide with first 2,3 tirggers and then travel in back direction and collide with 0(finish line ) and then collide with 8th trigger.
            // the wrongWayCount won't increase if only above 2 conditions are kept
            else if (n_triggerCollided > n_nextTrigger)
            {
                // now we will set the car to its needed collider position i.e nextTrigger
                // we need to disable the car first so that it does not move in air while falling down at the next trigger.

                /**/Debug.Log("In the condition n_triggerCollided > n_nextTrigger");

                gameObject.GetComponent<Rigidbody>().isKinematic = true;

                GameObject nextTriggerObj = GameObject.Find(n_nextTrigger.ToString());


                gameObject.transform.position = nextTriggerObj.transform.position;
                gameObject.transform.rotation = nextTriggerObj.transform.rotation;

                gameObject.GetComponent<Rigidbody>().isKinematic = false;

                n_wrongWayCount = 0;
            }

            if (gameManager.o_gameMode.Equals("Multiplayer"))
            {
                gameStatus.CalPlayersPositions();
            }
            else if (gameManager.o_gameMode.Equals("Singleplayer")) {

                gameStatus.UpdatePlayerStatsUI();
            }

            gameStatus.CheckWiningStatus();
         }

        // Here is code if the car colliders with death Trigger.
        if (other.CompareTag("DeathTrigger"))
        {

            // Stop the car movement
            gameObject.GetComponent<Rigidbody>().isKinematic = true;

            // after 3 sec respawn it at the previous checkpoint. 
            // 1) Reduce the Trigger collected by 1
            // 2) Reduce the nextTrigger by 1
            // 3) respawning it the the now nextTrigger.


            // Calling the RespawnAtPrevPos() using Invoke created this issue -
            // - It would set the position of the car to the last Trigger but that trigger would not be registered.
            // - means when player position is set to the last trigger(11 here) and he moves forward towards next trigger(12 here) he would have missed the last trigger(11 here)
            // So calling the method directly here without any delay.

            /*-Had bug when calling RespawnAtPrevPos() while calling it from Invoke().
                - resulted in the calling of the RespawnAtPrevPos() twice once in beginning and then after all the calculation correct calculations.
                - which resulted in the reduction of the triggersCollected and also the nextTrigger by 1.*/

           // Invoke("RespawnAtPrevPos", 2f);

           RespawnAtPrevPos();
        }
    }


    public void RespawnAtPrevPos()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
       /* Debug.Log("-------------------------------In RespawnPrevAtPos-------------------------------");
        Debug.Log("------> n_nextTrigger = "+n_nextTrigger + " n_totalTriggersCollided = "+ n_totalTriggersCollided);*/
        n_nextTrigger--;
       /* Debug.Log("------> n_nextTrigger = " + n_nextTrigger);*/
        n_totalTriggersCollided--;
       /* Debug.Log("------> n_totalTriggersCollided = " + n_totalTriggersCollided);*/

        GameObject nextTriggerObj = GameObject.Find(n_nextTrigger.ToString());

        /*Debug.Log("------> nextTriggerObj = " + nextTriggerObj.name);*/

        gameObject.transform.position = nextTriggerObj.transform.position;
        gameObject.transform.rotation = nextTriggerObj.transform.rotation;

        Debug.Log("-------------------------------RespawnPrevAtPos END------------------------------");
    }
}
