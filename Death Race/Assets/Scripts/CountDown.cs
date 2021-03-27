using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public GameObject countDownUI;
    //public AudioSource GetReady;
    //public AudioSource GoAudio;
    //public GameObject LapTimer;
    //public GameObject CarControls;
    public Text countDownUItext;

     
    void Start()
    {
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
        yield return new WaitForSeconds(0.5f);
        countDownUItext.text = null;
        

    }


}
