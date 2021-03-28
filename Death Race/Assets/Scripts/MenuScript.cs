using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    GameManager o_gameManager;

    void Start() {
        o_gameManager = FindObjectOfType<GameManager>();
    }

    // --------------- Main Menu -----------------
    public void o_SetModeSinglePlayer()
    {
        o_gameManager.o_gameMode = "Singleplayer";
        o_gameManager.o_totalPlayerCount = 1;
    }

    public void o_SetModeMultiPlayer() {
        o_gameManager.o_gameMode = "Multiplayer";
        o_gameManager.o_totalPlayerCount = 2;

    }

    public void o_LoadOptionsPanel() {
        // Here we load options panel and hide main panel
        Debug.Log("Loading options panel");
    }

    public void o_ExitGame()
    {
        // Here we Exit the game.

    }



}
