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
            Instantiate(o_carCargoVanPrefab, singlePlayerSpawnPoint.position, singlePlayerSpawnPoint.rotation);
        }
        else if (o_GameManager.o_carSelected.Equals("Mini Cooper"))
        {
            Instantiate(o_carMiniCooperPrefab, singlePlayerSpawnPoint.position, singlePlayerSpawnPoint.rotation);

        }
        else if (o_GameManager.o_carSelected.Equals("Mustang"))
        {
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
                Instantiate(o_carCargoVanPrefab, o_multiPlayerSpawnPoints[playerCount].position, o_multiPlayerSpawnPoints[playerCount].rotation);
            }
            else if (o_GameManager.o_carsSelectedMP[playerCount].Equals("Mini Cooper"))
            {
                Instantiate(o_carMiniCooperPrefab, o_multiPlayerSpawnPoints[playerCount].position, o_multiPlayerSpawnPoints[playerCount].rotation);

            }
            else if (o_GameManager.o_carsSelectedMP[playerCount].Equals("Mustang"))
            {
                Instantiate(o_carMustangPrefab, o_multiPlayerSpawnPoints[playerCount].position, o_multiPlayerSpawnPoints[playerCount].rotation);

            }
        }
    }

    
}
