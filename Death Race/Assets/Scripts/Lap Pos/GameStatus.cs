using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    public bool[] n_raceCompleted;             // it stores if a certain player has completed the race or not. // USED FOR MULTIPLAYER

    string n_SceneTrackName;
 
    

    [SerializeField] TMP_Text ui_textLapvalueSP;
    [SerializeField] TMP_Text ui_textLapvalueMP1;
    [SerializeField] TMP_Text ui_textLapvalueMP2;

    [SerializeField] Text ui_textBestTimevalueSP;

    [SerializeField] TMP_Text ui_textPosValueMP1;
    [SerializeField] TMP_Text ui_textPosValueMP2;

    // fields for displaying Won , Lost Message.
    [SerializeField] TMP_Text ui_textWinLooseMsgSP;

    [SerializeField] TMP_Text[] ui_textWinLooseMsgMP;


  


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
        n_raceCompleted = new bool[n_totalPlayers];

        n_totalTriggersInTrack = GameObject.FindGameObjectsWithTag("Checkpoints").Length;


    }

    private void Start()
    {
        ui_textWinLooseMsgSP.enabled = false;

        n_SceneTrackName = n_GameManager.o_trackSelected;
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

    public void CheckWiningStatus()             // It will display the "YOU WON" msg if any player wins.
    {
        if (n_GameManager.o_gameMode == "Singleplayer")
        {
            Debug.Log("Inside Singleplayer condition");
            if (n_LapsCompleted[0] == n_totalLaps)
            {
                // Stop the car movement and Inputs ------CODE HERE --------


                // Display The players Best Time for now
                // The Best Time of player would have been displayed on the Text in Panel so take it and set it.
                ui_textWinLooseMsgSP.enabled= true;           // to disable/enable the text.
                ui_textWinLooseMsgSP.text = "YOUR TIME : " + ui_textBestTimevalueSP.text + " SECS ";
                ui_textWinLooseMsgSP.color = Color.white;
                Debug.Log(" SINGLE PLAYER GAME OVER");

                // Store the Time in the PlayerPrefs respectively TrackName/SceneName  |  Time float
                // Only if the earlier stored time is greater than currnt best Time
                // 10000f is the default time returned when no value is present for the given key.
                if (PlayerPrefs.GetFloat(n_SceneTrackName,10000f) > float.Parse(ui_textBestTimevalueSP.text)) {
                    PlayerPrefs.SetFloat(n_SceneTrackName, float.Parse(ui_textBestTimevalueSP.text));
                }
                
                // Display a new GAME OVER panel / GAME OVER SCENE after 2 sec.
                Invoke("ShowGameOverScene", 5f);


            }

        }
        else if (n_GameManager.o_gameMode == "Multiplayer" && n_totalPlayers == 2)      // display "YOU WON" on the required screen. and will let the other car finish race.
        {
            for (int i = 0; i < n_totalPlayers ; i++)
            {
                if (n_LapsCompleted[i] == n_totalLaps)        
                {
                    // check if other vechile has already completed the race or not.
                    Debug.Log("n_raceCompleted[1 - i] = " + n_raceCompleted[1 - i] + " | " + "n_raceCompleted[i] = " + n_raceCompleted[i]);
                    if (n_raceCompleted[1 - i] == true && n_raceCompleted[i] == false)
                    {
                        // You have lost so it will display the "YOU LOOSE" msg.
                        ui_textWinLooseMsgMP[i].enabled = true;
                        ui_textWinLooseMsgMP[i].text = "YOU LOOSE!";
                        ui_textWinLooseMsgMP[i].color = Color.white;

                        Debug.Log("Player " + i + 1 + " YOU LOOSE");
                        // set n_raceCompleted[] values
                        n_raceCompleted[i] = true;
                        // Stop you car movement and Input
                        // wrote the code for it in the CarMovement script.
                        // requires addition of a Finish trigger after the start line.

                        // Now send the user to the GameOver Scene.
                        Invoke("ShowGameOverScene", 5f);

                    }
                    else if (n_raceCompleted[1 - i] == false )
                    {
                        // you have won the race so display the 'YOU WON' msg.
                        ui_textWinLooseMsgMP[i].enabled = true;
                        ui_textWinLooseMsgMP[i].text = "YOU WON!";
                        ui_textWinLooseMsgMP[i].color = Color.white;
                        Debug.Log("Player " + i + 1 + " YOU WON");
                        // set n_raceCompleted[] values
                        n_raceCompleted[i] = true;
                        // Stop you car movement and Input
                        // wrote the code for it in the CarMovement script.
                        // requires addition of a Finish trigger after the start line.

                    }
                }
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

    public void ShowGameOverScene() {
        SceneManager.LoadScene("GameOver Scene");
    }

    public void ShowWrongWayMsg(int playerNo) {

        if (n_GameManager.o_gameMode == "Singleplayer")
        {
            ui_textWinLooseMsgSP.text = "WRONG WAY! TURN BACK!";
            ui_textWinLooseMsgSP.color = Color.red;
            ui_textWinLooseMsgSP.enabled = true;
        }
        else if (n_GameManager.o_gameMode == "Multiplayer")
        {
            ui_textWinLooseMsgMP[playerNo - 1].text = "WRONG WAY! TURN BACK!";
            ui_textWinLooseMsgMP[playerNo - 1].color = Color.red;
            ui_textWinLooseMsgMP[playerNo - 1].enabled = true;
        }
    }

    public void DisableWrongWayMsg(int playerNo) {
        if (n_GameManager.o_gameMode == "Singleplayer")
        {
           
            ui_textWinLooseMsgSP.color = Color.white;
            ui_textWinLooseMsgSP.enabled = false;
        }
        else if (n_GameManager.o_gameMode == "Multiplayer")
        {
            ui_textWinLooseMsgMP[playerNo - 1].color = Color.white;
            ui_textWinLooseMsgMP[playerNo - 1].enabled = false;
        }
    }

}
