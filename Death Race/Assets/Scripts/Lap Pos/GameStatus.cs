using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // This script is used to keep track of the each car in the game of their position/lap/wrong turn etc

    private GameManager n_GameManager;

    public int n_totalLaps;
    public int n_totalPlayers;

    public int n_totalTriggersInTrack;

    public int[] n_LapsCompleted;
    public int[] n_TriggersCollected;

    public int[] n_pos;


    [SerializeField] TMP_Text ui_textLapvalueSP;
    [SerializeField] TMP_Text ui_textLapvalueMP1;
    [SerializeField] TMP_Text ui_textLapvalueMP2;

    [SerializeField] TMP_Text ui_textPosValueMP1;
    [SerializeField] TMP_Text ui_textPosValueMP2;

        

    private void Awake()
    {
        n_GameManager = FindObjectOfType<GameManager>();
        n_totalLaps = n_GameManager.o_lapCountTotal;
        n_totalPlayers = n_GameManager.o_totalPlayerCount;

        // Create array storing laps completed by the players. Index represent the player no.
        n_LapsCompleted = new int[n_totalPlayers];
        // Create array for storing the no. of triggers passed via / collected
        n_TriggersCollected = new int[n_totalPlayers];

        n_pos = new int[n_totalPlayers];

        n_totalTriggersInTrack = GameObject.FindGameObjectsWithTag("Checkpoints").Length;
    }


    public void CalPlayersPositions()
    {

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
        else
        {
            n_pos[0] = Random.Range(1, 3);      // gives the random pos of 1/2
            n_pos[1] = 3 - n_pos[0];            // sub from 3 the position of player 1 to get its position i.e P1 = 2 => P2 = 3-2 = 1
        }

        UpdatePlayerStatsUI();
    }

    public void CheckWiningStatus()
    {
        for (int i = 0; i < n_LapsCompleted.Length; i++)
        {
            if (n_LapsCompleted[i] == n_totalLaps)
            {
                // Here will be code to display the "YOU WON" msg on appropriate panel.
                // Also you will make the player car stop and not movable.

                // ------------------------CODE GOES HERE -------------------------


                Debug.Log("Player " + (i + 1) + " Won");
            }
        }
    }

    public void UpdatePlayerStatsUI()                                                   // Method called after the Player positions are updated.
    {
        if (n_totalPlayers == 1)        // SinglePlayer
        {
            ui_textLapvalueSP.text = (n_LapsCompleted[0] + 1).ToString() + " / 3";             // SinglePlayer 
        } 
        else if (n_totalPlayers == 2)                      // Multiplayer 
        {
            
            ui_textLapvalueMP1.text = (n_LapsCompleted[0] + 1).ToString() + " / 3";     // Added 1 in lapCompleted as it must show ongoing lap. i.e
            ui_textLapvalueMP2.text = (n_LapsCompleted[1] + 1).ToString() + " / 3";     // i.e 1/3 , 2/3 , 3/3 etc.

            ui_textPosValueMP1.text = n_pos[0].ToString() + " / " + n_totalPlayers;
            ui_textPosValueMP2.text = n_pos[1].ToString() + " / " + n_totalPlayers;


        }
    }
}
