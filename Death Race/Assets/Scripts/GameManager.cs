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

    //public CarManager[] o_Cars;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
