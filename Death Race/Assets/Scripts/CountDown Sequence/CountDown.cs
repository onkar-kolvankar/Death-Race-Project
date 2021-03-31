using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    //public AudioSource GetReady;
    //public AudioSource GoAudio;
    //public GameObject LapTimer;
    //public GameObject CarControls;
    public Text countDownUItext;
    //[SerializeField] GameObject playerObj;

    CarMovement[] playerCarMovementScripts;





    void Start()
    {
        // this line was used when I had the car in the scene already. so i could have assigned the carObj and then got its CarMovement script
        // But i am using prefabs so i have to use another way. 
        // playerCarMovementScript = playerObj.GetComponent<CarMovement>();

        gameObject.GetComponent<LapTimeManager>().enabled = false;

        playerCarMovementScripts = FindObjectsOfType<CarMovement>();
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown() {
        yield return new WaitForSeconds(0.5f);
        countDownUItext.text = "3";
        yield return new WaitForSeconds(1);
        countDownUItext.text = "2";
        yield return new WaitForSeconds(1);
        countDownUItext.text = "1";
        yield return new WaitForSeconds(1f);
        countDownUItext.text = "GO..";
        EnablePlayerCarMovementScript();
        EnableLapTimeManagerScript();
        yield return new WaitForSeconds(0.5f);
        countDownUItext.text = null;
        

    }

    private void EnableLapTimeManagerScript()
    {
        gameObject.GetComponent<LapTimeManager>().enabled = true;
    }

    void EnablePlayerCarMovementScript() {

        foreach (var carMovementScript in playerCarMovementScripts)
        {
            carMovementScript.enabled = true; 
        }
    }


}
