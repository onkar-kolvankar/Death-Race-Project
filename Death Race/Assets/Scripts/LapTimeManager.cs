using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour
{
	public float lapStartTime;
	// we set bestTime to infinity so that first round will have best time.
	public float bestTime = 1000000000f;
	
	public Text currentLapTimeBox;
	public Text bestLapTimeBox;

	private void OnTriggerEnter(Collider other)
	{
		// Here you need to check if it is first lap or not
		if(other.CompareTag("StartLineTrigger")){
			// Here check if the lapStartTime is less than Best time

			Debug.Log("Checking if lap time is less that best time");
			if (lapStartTime < bestTime) {
				Debug.Log("lap time is less that best time");
				bestTime = lapStartTime;
			}

			// Set the lapStartTime = 0 so you can cal lap time of this lap
			lapStartTime = 0f;

			// Update the Lap time UI
			currentLapTimeBox.text = lapStartTime.ToString();
			bestLapTimeBox.text = bestTime.ToString();


			
		}
	}


	void Update()
	{
		// Here we are adding the time to the lapStartTime
		lapStartTime += Time.deltaTime;

		// Update the Lap time UI
		currentLapTimeBox.text = lapStartTime.ToString();


	}
}
