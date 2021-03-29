using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAxisTesting : MonoBehaviour
{
    [SerializeField] int playerNo;
    String HorizontalInputAxis, VerticalInputAxis;


    float inputHorizontal, inputVertical;
    void Start()
    {
        HorizontalInputAxis = "Horizontal" + playerNo.ToString();
        VerticalInputAxis = "Vertical" + playerNo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis(HorizontalInputAxis);
        inputVertical = Input.GetAxis(VerticalInputAxis);
        Debug.Log("Player NO = "+playerNo + " | Horizontal = " + inputHorizontal + " Vertical = " + inputVertical);
    }
}
