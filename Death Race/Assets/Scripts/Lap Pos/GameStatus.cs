using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    // This script is used to keep track of the each car in the game of their position/lap/wrong turn etc

    private GameManager n_GameManager;

    public int n_totalLaps;
    public int n_totalPlayers;
    public int n_totalTriggers = 12;

    private void OnEnable()
    {
        n_GameManager = FindObjectOfType<GameManager>();
        n_totalLaps = n_GameManager.o_lapCountTotal;
        n_totalPlayers = n_GameManager.o_totalPlayerCount;
        n_totalTriggers = n_GameManager.o_track1PosTriggersTotal;
    }
    void start()
    {


    }
}
