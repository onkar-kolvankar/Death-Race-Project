using System;
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
    [SerializeField] Transform o_multiPlayerSpawnPoint1;
    [SerializeField] Transform o_multiPlayerSpawnPoint2;
    [SerializeField] Transform[] o_multiPlayerSpawnPoints;       // array for the spawn points initialized in inspector 

    // Initialize the prefabs of the all cars.
    public GameObject o_carCargoVanPrefab;
    public GameObject o_carMiniCooperPrefab;
    public GameObject o_carMustangPrefab;

    // array to store the PosLapTriggers name.
    


    private void OnEnable()
    {
       o_GameManager = FindObjectOfType<GameManager>();

        if (o_GameManager.o_gameMode.Equals("Singleplayer"))
        {
            AssignSinglePlayerGameplay();
        }
        else if (o_GameManager.o_gameMode.Equals("Multiplayer")) 
        {
            if (o_GameManager.o_totalPlayerCount == 2)          // It will be default fow now.
            {
                AssignDualPlayerGameplay();
            }
        }
    }


    private void AssignSinglePlayerGameplay()
    {
        singlePlayerPanel.SetActive(true);
        multiPlayerPanel.SetActive(false);

        if (o_GameManager.o_carSelected.Equals("Cargo Van"))
        {
            // giving Player No to the Prefab's CarMovement and LapPosCalculator Script
            o_carCargoVanPrefab.GetComponent<CarMovement>().o_playerNumber = 1;
            o_carCargoVanPrefab.GetComponent<LapPosCalculator>().n_PlayerNo = 1;
            Instantiate(o_carCargoVanPrefab, singlePlayerSpawnPoint.position, singlePlayerSpawnPoint.rotation);
        }
        else if (o_GameManager.o_carSelected.Equals("Mini Cooper"))
        {
            // giving Player No to the Prefab's CarMovement and LapPosCalculator Script
            o_carMiniCooperPrefab.GetComponent<CarMovement>().o_playerNumber =  1;
            o_carMiniCooperPrefab.GetComponent<LapPosCalculator>().n_PlayerNo =  1;
            Instantiate(o_carMiniCooperPrefab, singlePlayerSpawnPoint.position, singlePlayerSpawnPoint.rotation);

        }
        else if (o_GameManager.o_carSelected.Equals("Mustang"))
        {
            // giving Player No to the Prefab's CarMovement and LapPosCalculator Script
            o_carMustangPrefab.GetComponent<CarMovement>().o_playerNumber =  1;
            o_carMustangPrefab.GetComponent<LapPosCalculator>().n_PlayerNo =  1;
            Instantiate(o_carMustangPrefab, singlePlayerSpawnPoint.position, singlePlayerSpawnPoint.rotation);

        }
    }

    private void AssignDualPlayerGameplay()
    {
        multiPlayerPanel.SetActive(true);               // FOr now Multiplayer means 2 players
        singlePlayerPanel.SetActive(false);

        for (int playerCount = 0; playerCount < o_GameManager.o_totalPlayerCount; playerCount++)
        {
            // Instantiate the Player 1 car
            if (o_GameManager.o_carsSelectedMP[playerCount].Equals("Cargo Van"))
            {
                // giving Player No to the Prefab's CarMovement and LapPosCalculator Script
                o_carCargoVanPrefab.GetComponent<CarMovement>().o_playerNumber = playerCount + 1;
                o_carCargoVanPrefab.GetComponent<LapPosCalculator>().n_PlayerNo = playerCount + 1;


                // code to adjust camera visuals accord.
                if (playerCount == 0)
                {
                    o_carCargoVanPrefab.GetComponentInChildren<Camera>().rect = new Rect(0f, 0f, 0.5f, 1f);
                }
                else if(playerCount == 1)
                {
                    o_carCargoVanPrefab.GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 1f);
                }
                


                Instantiate(o_carCargoVanPrefab, o_multiPlayerSpawnPoints[playerCount].position, o_multiPlayerSpawnPoints[playerCount].rotation);
                // need to assign the player no to the prefab so it has the corresponding input axes.
                // However the playerCount starts from 0 but axes from 1 so need to add 1 while assigning.
                //o_carCargoVanPrefab.GetComponent<CarMovement>().o_playerNumber = playerCount + 1;     // THis is ref to the prefabs of prefabs folder which is not setting player no. in scene clones.
                
                // SOL First assign the player no to prefab ref and then instantiate the prefabs in scene.

                
                
            }
            else if (o_GameManager.o_carsSelectedMP[playerCount].Equals("Mini Cooper"))
            {
                // giving Player No to the Prefab's CarMovement and LapPosCalculator Script
                o_carMiniCooperPrefab.GetComponent<CarMovement>().o_playerNumber = playerCount + 1;
                o_carMiniCooperPrefab.GetComponent<LapPosCalculator>().n_PlayerNo = playerCount + 1;


                // code to adjust camera visuals accord.
                if (playerCount == 0)
                {
                    o_carMiniCooperPrefab.GetComponentInChildren<Camera>().rect = new Rect(0f, 0f, 0.5f, 1f);
                }
                else if (playerCount == 1)
                {
                    o_carMiniCooperPrefab.GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 1f);
                }
                Instantiate(o_carMiniCooperPrefab, o_multiPlayerSpawnPoints[playerCount].position, o_multiPlayerSpawnPoints[playerCount].rotation);

            }
            else if (o_GameManager.o_carsSelectedMP[playerCount].Equals("Mustang"))
            {
                // giving Player No to the Prefab's CarMovement and LapPosCalculator Script
                o_carMustangPrefab.GetComponent<CarMovement>().o_playerNumber = playerCount + 1;
                o_carMustangPrefab.GetComponent<LapPosCalculator>().n_PlayerNo = playerCount + 1;

                // code to adjust camera visuals accord.
                if (playerCount == 0)
                {
                    o_carMustangPrefab.GetComponentInChildren<Camera>().rect = new Rect(0f, 0f, 0.5f, 1f);
                }
                else if (playerCount == 1)
                {
                    o_carMustangPrefab.GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 1f);
                }
                Instantiate(o_carMustangPrefab, o_multiPlayerSpawnPoints[playerCount].position, o_multiPlayerSpawnPoints[playerCount].rotation);

            }
        }
    }

    
}
