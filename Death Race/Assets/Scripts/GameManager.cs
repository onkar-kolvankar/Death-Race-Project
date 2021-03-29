using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int o_lapCountTotal = 3;

    public string o_gameMode;           // Singleplayer or Multiplayer
    public int o_totalPlayerCount = 1;  // This field will be initialized when we select Singleplayer/Multiplayer.

    public string o_trackSelected;      // Track 1 / Track 2 /                      // FOR BOTH SP & MP
    public string o_carSelected;        // Cargo Van / Mini Cooper / Mustang        // FOR SINGLEPLAYER

    public string[] o_carsSelectedMP;   // will be initialized when we select the cars.
    public string[] o_playerNames;      // will be used to store player names later on.

    //------ For Multiplayer ------

    private void Awake()
    {
        // Here we take the gamemanager obj and then initialize singleplayer/ multiplayer accr.
        // Also we take what car the user has choosen in GameManager and then Instantiate it here at the spawn area.

        int o_gameManagerCount = FindObjectsOfType<GameManager>().Length;

        if (o_gameManagerCount > 1)
        {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }
}
