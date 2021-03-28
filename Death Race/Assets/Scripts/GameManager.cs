using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // This field will be initialized when we select Single player/ multiplayer.
    public int o_totalPlayerCount = 1;

    public int o_lapCountTotal = 3;

    // Initialize the prefabs of the all cars.
    public GameObject o_car1Prefab;
    public GameObject o_car2Prefab;
    public GameObject o_car3Prefab;

    public string o_gameMode;
    public string o_trackSelected;
    public string o_carSelected;

    //public CarManager[] o_Cars;



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
