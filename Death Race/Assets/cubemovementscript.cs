using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubemovementscript : MonoBehaviour
{

    string forwardAxis = "Vertical1";
    string turnAxis = "Horizontal1";

    [SerializeField] int xMoveSpeed = 5;
    [SerializeField] int zMoveSpeed = 5; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.Translate(xMoveSpeed * Input.GetAxis("Horizontal1") * Time.deltaTime, 0f, zMoveSpeed * Input.GetAxis("Vertical1") * Time.deltaTime);
        

    }
}
