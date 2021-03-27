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
    [SerializeField] GameObject playerObj;
    CarMovement playerCarMovementScript;

     
    void Start()
    {
        playerCarMovementScript = playerObj.GetComponent<CarMovement>();
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
        yield return new WaitForSeconds(0.5f);
        countDownUItext.text = null;
        

    }

    void EnablePlayerCarMovementScript() {
        playerCarMovementScript.enabled = true;
    }


}
