using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionTriggers : MonoBehaviour
{
    [SerializeField] Sprite directionSignTexture;
    // [SerializeField] RawImage directionsRawImage;
    [SerializeField] Image directionsImage;


    private void Start()
    {
        directionsImage.GetComponent<Image>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            directionsImage.enabled = true;
            directionsImage.sprite = directionSignTexture;

            Invoke("setDirectionsNone", 2f);
        }
    }

    private void setDirectionsNone() {
        directionsImage.sprite = null;
        directionsImage.enabled = false;
    }
}
