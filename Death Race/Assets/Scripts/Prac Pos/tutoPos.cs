using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoPos : MonoBehaviour
{
    [SerializeField] int n_PlayerNo;
    int n_totalTriggersInTrack;

    public int n_prevTriggerCollided;
    public int n_nextTrigger;

    public int n_wrongWayCount;
    public int n_totalTriggersCollided;

    LapPosGameStatus lapPosGameStatus;


    public int lap = 0;
    public int checkPoint = -1;

    private void Awake()
    {
        lapPosGameStatus = FindObjectOfType<LapPosGameStatus>();
    }

    void Start() {
        n_totalTriggersInTrack = GameObject.FindGameObjectsWithTag("Checkpoints").Length;
    }

    private void OnTriggerEnter(Collider checkpointCollider)
    {
        if (checkpointCollider.tag == "Checkpoints") {

            int n_triggerCollided = int.Parse(checkpointCollider.name);
            if (n_triggerCollided == n_nextTrigger) {
                checkPoint = n_triggerCollided;

                if (checkPoint == 0) {
                    lap++;
                }

                n_nextTrigger++;

                if (n_nextTrigger >= n_totalTriggersInTrack) {
                    n_nextTrigger = 0;
                }
            }
        }
    }



}
