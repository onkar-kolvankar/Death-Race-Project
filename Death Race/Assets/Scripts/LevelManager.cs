using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GameManager o_GameManager;
    private void Awake()
    {   
        // Here we take the gamemanager obj and then initialize the instantiate Environment prefab named in it.
        o_GameManager = FindObjectOfType<GameManager>();



    }
}
