using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapPosGameStatus : MonoBehaviour
{
    public int n_totalTriggersInTrack = 8;
    [SerializeField] int n_totalPlayers;        // To be taken from the GameManager in Start method.

    

    public int[] n_LapsCompleted;
    public int[] n_TriggersCollected;

    void OnEnable() {
        // Take the total players from the gamemanager
        // Using default

        // Create array storing laps completed by the players. Index represent the player no.
        n_LapsCompleted = new int[n_totalPlayers];
        // Create array for storing the no. of triggers passed via / collected
        n_TriggersCollected = new int[n_totalPlayers];

    }
    private void Update()
    {
        // check if the any player has completed 3 laps.

        for (int i = 0; i < n_LapsCompleted.Length; i++) {
            if (n_LapsCompleted[i] == 3) {
                Debug.Log("Player " + i + " Won");
            } 
        }
        
    }

}
