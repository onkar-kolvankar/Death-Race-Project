using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapPosGameStatus : MonoBehaviour
{
    public int n_totalTriggersInTrack;
    [SerializeField] int n_totalPlayers;        // To be taken from the GameManager in Start method.

    

    public int[] n_LapsCompleted;
    public int[] n_TriggersCollected;

    public int[] n_pos;

    void OnEnable() {
        // Take the total players from the gamemanager
        // Using default

        // Create array storing laps completed by the players. Index represent the player no.
        n_LapsCompleted = new int[n_totalPlayers];
        // Create array for storing the no. of triggers passed via / collected
        n_TriggersCollected = new int[n_totalPlayers];
        
        n_pos = new int[n_totalPlayers];

        n_totalTriggersInTrack = GameObject.FindGameObjectsWithTag("Checkpoints").Length;

    }
    private void Update()
    {
        // check if the any player has completed 3 laps.

       // CheckWiningStatus();

       // CalPlayersPositions();

    }

    public void CalPlayersPositions()
    {
        // This code has issue with when both cars have collected same amt of trigger since SortedList can't have duplicate key, i.e key values are unique.
        /*SortedList sortedListTriggersCollectedPlayers = new SortedList();

        for (int i = 0; i < n_totalPlayers; i++)
        {
            // here we are storing the triggers and their player no in SortedList with key = triggers , value = playerNo so that they are given in sorted form.
            sortedListTriggersCollectedPlayers.Add((n_LapsCompleted[i] * n_totalTriggersInTrack) + n_TriggersCollected[i], i);

        }

        for (int i = 0; i < n_totalPlayers; i++)
        {
            // set the positions of the vechicles.
            n_pos[i] = (int)sortedListTriggersCollectedPlayers.GetByIndex(i);
        }*/

        // The above method would be usefull if you had too many players BUT since we might have only 2 or max 4 players so we calculate it simply.

        int trigcol1 = (n_LapsCompleted[0] * n_totalTriggersInTrack) + n_TriggersCollected[0];
        int trigcol2 = (n_LapsCompleted[1] * n_totalTriggersInTrack) + n_TriggersCollected[1];

        if (trigcol1 > trigcol2)
        {
            n_pos[0] = 1;
            n_pos[1] = 2;

        }
        else if (trigcol1 < trigcol2)
        {
            n_pos[0] = 2;
            n_pos[1] = 1;
        }
        else {
            n_pos[0] = Random.Range(1, 3);      // gives the random pos of 1/2
            n_pos[1] = 3 - n_pos[0];            // sub from 3 the position of player 1 to get its position i.e P1 = 2 => P2 = 3-2 = 1
        } 
    }

    public void CheckWiningStatus()
    {
        for (int i = 0; i < n_LapsCompleted.Length; i++)
        {
            if (n_LapsCompleted[i] == 3)
            {
                Debug.Log("Player " + i + " Won");
            }
        }
    }
}
