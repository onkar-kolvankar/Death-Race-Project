using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapPosCalculator : MonoBehaviour
{ 

    public int n_PlayerNo;          // Atached on the car prefab and it has player no as 1,2,....
    int n_totalTriggersInTrack;

    public int n_prevTrigger;
    public int n_nextTrigger = 1;

    public int n_wrongWayCount;
    public int n_totalTriggersCollided;

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
        Debug.Log("Total Triggers in Track : Awake() - " + n_totalTriggersInTrack);
    }
    private void OnTriggerEnter(Collider other)
    {
         //if (gameManager.o_gameMode == "Multiplayer" && other.gameObject.CompareTag("Checkpoints"))
         if (other.gameObject.CompareTag("Checkpoints"))

         {
        
            int n_triggerCollided = int.Parse(other.gameObject.name.ToString());

            if (n_triggerCollided == n_nextTrigger)
            {
                Debug.Log("In the condition n_triggerCollided = n_nextTrigger");

                n_totalTriggersCollided++;

                Debug.Log("-- n_totalTriggersCollided = "+ n_totalTriggersCollided);
                // correct path
                if (n_triggerCollided == 0 && n_totalTriggersCollided == n_totalTriggersInTrack)
                {
                    Debug.Log("-- In the If condition n_triggerCollided = 0 and n_totaltriggerCollided = n_totalTriggersInTrack");
                    // you have collided finish line after completing the track and collection all colliders -> increase Lap count
                    gameStatus.n_LapsCompleted[n_PlayerNo - 1] = gameStatus.n_LapsCompleted[n_PlayerNo - 1] + 1;
                    n_totalTriggersCollided = 0;
                }
                // need to save the totalTriggersCollided of each player to the Lap manager script where it will compare both players data and decide their position.
                // Here we save it to LapPosGameStatus.cs file.
                gameStatus.n_TriggersCollected[n_PlayerNo - 1] = n_totalTriggersCollided;
                Debug.Log("----> n_nextTrigger = " + n_nextTrigger );
                n_nextTrigger++;
                Debug.Log("----> n_nextTrigger = " + n_nextTrigger);
                Debug.Log("----> n_totalTriggersInTrack = " + n_totalTriggersInTrack);


                if (n_nextTrigger >= n_totalTriggersInTrack)
                {
                    Debug.Log("------ In if conditionn_nextTrigger >= n_totaltriggersInTrack");

                    Debug.Log("------> n_nextTrigger = " + n_nextTrigger);

                    n_nextTrigger = 0;
                }
            }
            else if (n_triggerCollided < n_nextTrigger - 1)
            {
                Debug.Log("In the condition n_triggerCollided < n_nextTrigger");

                Debug.Log("Wrong Direction");
                n_wrongWayCount++;

                if (n_wrongWayCount >= 5)
                {
                    // now we will set the car to its needed collider position i.e nextTrigger

                    GameObject nextTriggerObj = GameObject.Find(n_nextTrigger.ToString());
                    

                    gameObject.transform.position = nextTriggerObj.transform.position;
                    gameObject.transform.rotation = nextTriggerObj.transform.rotation;

                    n_wrongWayCount = 0;

                }
            }

            // this happens when you collide with first 2,3 tirggers and then travel in back direction and collide with 0(finish line ) and then collide with 8th trigger.
            // the wrongWayCount won't increase if only above 2 conditions are kept
            else if (n_triggerCollided > n_nextTrigger)
            {
                // now we will set the car to its needed collider position i.e nextTrigger
                // we need to disable the car first so that it does not move in air while falling down at the next trigger.

                Debug.Log("In the condition n_triggerCollided > n_nextTrigger");

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



    }   
}
