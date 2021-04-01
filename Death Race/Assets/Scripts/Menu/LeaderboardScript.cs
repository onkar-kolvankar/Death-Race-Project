using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LeaderboardScript : MonoBehaviour
{
    [SerializeField] TMP_Text[] n_scoreTrack;
   
    [SerializeField] string[] n_trackNames = {"Track 1" , "Track 2"};

    // Start is called before the first frame update
    void Start()
    {
        n_DisplayBestTime();
    }

    public void n_DisplayBestTime() {
        float score;
        for (int i = 0; i < n_trackNames.Length; i++)
        {
            score = PlayerPrefs.GetFloat(n_trackNames[i], 10000f);
            if (score == 10000f)
            {
                n_scoreTrack[i].text = "---";
            }
            else
            {
                n_scoreTrack[i].text = score.ToString() + " SEC";
            }
        }
    }

    public void n_ResetLeaderboardTimes() {
        PlayerPrefs.DeleteAll();
        n_DisplayBestTime();
    }

}
