using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionTriggers : MonoBehaviour
{
    [SerializeField] Sprite directionSignTexture;
    [SerializeField] Image directionsImageSP;

    [SerializeField] Image directionsImageMP1;
    [SerializeField] Image directionsImageMP2;

    GameManager gameManager;


    private void Start()
    {
        directionsImageSP.GetComponent<Image>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.o_gameMode == "Singleplayer")
        {
            // Directions code for single player
            DisplayDirectinsOnTurns(other);
        }
        else if (gameManager.o_gameMode == "Multiplayer") {
            // Directions code to display the sign on the respective Image Component.

            if (other.CompareTag("Player")) 
            {
                if (other.gameObject.GetComponent<CarMovement>().o_playerNumber == 1)
                {
                    directionsImageMP1.enabled = true;
                    directionsImageMP1.sprite = directionSignTexture;


                    Invoke("setDirectionsImageNoneMP1", 2f);
                }
                else if (other.gameObject.GetComponent<CarMovement>().o_playerNumber == 2)
                {
                    directionsImageMP2.enabled = true;
                    directionsImageMP2.sprite = directionSignTexture;


                    Invoke("setDirectionsImageNoneMP2", 2f);
                }
            }
        }
   
    }

    // --------------------------- This method displays the directions on the Image UI component------------
    private void DisplayDirectinsOnTurns(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            directionsImageSP.enabled = true;
            directionsImageSP.sprite = directionSignTexture;
            Invoke("setDirectionsNone", 2f);
        }
    }
    
    private void setDirectionsNone() {
        // This methods turn off the directions after 2 sec.
        directionsImageSP.sprite = null;
        directionsImageSP.enabled = false;
    }

    private void setDirectionsImageNoneMP1()
    {
        // This methods turn off the directions after 2 sec.
        directionsImageMP1.sprite = null;
        directionsImageMP1.enabled = false;
    }
    private void setDirectionsImageNoneMP2()
    {
        // This methods turn off the directions after 2 sec.
        directionsImageMP2.sprite = null;
        directionsImageMP2.enabled = false;
    }
    // ------------------------------------------------------------------------------------------------------
}
