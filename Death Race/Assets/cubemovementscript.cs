using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubemovementscript : MonoBehaviour
{
    posLapScript PosLapScript;

    int currentPlayerno;
    

    [SerializeField] int xMoveSpeed = 5;
    [SerializeField] int zMoveSpeed = 5;

    string forwardAxis;
    string turnAxis;

    // Start is called before the first frame update
    void Start()
    {
        PosLapScript = gameObject.GetComponent<posLapScript>();
        currentPlayerno = PosLapScript.n_PlayerNo;

        forwardAxis = "Vertical"+currentPlayerno;
        turnAxis = "Horizontal" + currentPlayerno;
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.Translate(xMoveSpeed * Input.GetAxis(turnAxis) * Time.deltaTime, 0f, zMoveSpeed * Input.GetAxis(forwardAxis) * Time.deltaTime);
        

    }
}
