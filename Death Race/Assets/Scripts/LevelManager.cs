using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    GameManager o_GameManager;

    [SerializeField] GameObject singlePlayerPanel;
    [SerializeField] GameObject multiPlayerPanel;

    [SerializeField] Transform singlePlayerSpawnPoint;

    // Initialize the prefabs of the all cars.
    public GameObject o_carCargoVanPrefab;
    public GameObject o_carMiniCooperPrefab;
    public GameObject o_carMustangPrefab;


    private void OnEnable()
    {
       o_GameManager = FindObjectOfType<GameManager>();

        if (o_GameManager.o_gameMode.Equals("Singleplayer")) {
            singlePlayerPanel.SetActive(true);
            multiPlayerPanel.SetActive(false);

            if (o_GameManager.o_carSelected.Equals("Cargo Van"))
            {
                Instantiate(o_carCargoVanPrefab, singlePlayerSpawnPoint.position, singlePlayerSpawnPoint.rotation);
            }
            else if (o_GameManager.o_carSelected.Equals("Mini Cooper")) {
                Instantiate(o_carMiniCooperPrefab, singlePlayerSpawnPoint.position, singlePlayerSpawnPoint.rotation);

            }
            else if(o_GameManager.o_carSelected.Equals("Mustang")){
                Instantiate(o_carMustangPrefab, singlePlayerSpawnPoint.position, singlePlayerSpawnPoint.rotation);

            }
        }
    }
}
