using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionTriggers : MonoBehaviour
{
    [SerializeField] Sprite directionSignTexture;
    [SerializeField] Image directionsImage;


    private void Start()
    {
        directionsImage.GetComponent<Image>();
    }

    private void OnTriggerEnter(Collider other)
    {
        DisplayDirectinsOnTurns(other);
    }

    // --------------------------- This method displays the directions on the Image UI component------------
    private void DisplayDirectinsOnTurns(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            directionsImage.enabled = true;
            directionsImage.sprite = directionSignTexture;
            Invoke("setDirectionsNone", 2f);
        }
    }
    
    private void setDirectionsNone() {
        // This methods turn off the directions after 2 sec.
        directionsImage.sprite = null;
        directionsImage.enabled = false;
    }
    // ------------------------------------------------------------------------------------------------------
}
