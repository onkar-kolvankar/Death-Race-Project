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

	public void CheckCurrentBestLapTime()
	{
		if (lapStartTime < bestTime)
		{
			bestTime = lapStartTime;
		}

		// Set the lapStartTime = 0 so you can cal lap time of this lap
		lapStartTime = 0f;
		UpdateLapTimeUI();
	}

	private void UpdateLapTimeUI()
	{
		// Update the Lap time UI
		currentLapTimeBox.text = lapStartTime.ToString();
		bestLapTimeBox.text = bestTime.ToString();
	}

	void Update()
	{
		CalUpdateLapTime();
	}

	private void CalUpdateLapTime()
	{
		// Here we are adding the time to the lapStartTime
		lapStartTime += Time.deltaTime;

		// Update the Lap time UI
		currentLapTimeBox.text = lapStartTime.ToString();
	}
}
