using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{
    /*//
    public float lapStartTime;
    // we set bestTime to infinity so that first round will have best time.
    public float bestTime = 1000000000f;

    public Text currentLapTimeBox;
    public Text bestLapTimeBox;
    //*/

    // obj to Lap timer
    GameObject o_countDownObj;
    LapTimeManager o_lapTimeManager;


    // used to identify which car it is and accordingly use Vertical and Horizontal axis.
    public int o_playerNumber  = 1; // default value for single player mode.

    public int o_lapRem = 3;

    float o_verticalAxisInput, o_horizontalAxisInput;
    [SerializeField] float o_maxTorque = 1000f;
    [SerializeField] float o_maxSteer = 1400f;
    [SerializeField] float o_constantMultipleFactorTorque = 100f;

    private string o_torqueAxis, o_turningAxis;

    [SerializeField] WheelCollider o_wheelColliderLF;
    [SerializeField] WheelCollider o_wheelColliderRF;
    [SerializeField] WheelCollider o_wheelColliderLB;
    [SerializeField] WheelCollider o_wheelColliderRB;

    [SerializeField] Transform o_meshWheelLF;
    [SerializeField] Transform o_meshWheelRF;
    [SerializeField] Transform o_meshWheelLB;
    [SerializeField] Transform o_meshWheelRB;

    [SerializeField] Transform o_centerOfMassObj;

    GameManager o_gameManager;

    bool isSinglePlayer;
    

    private void Awake()
    {
        o_gameManager = FindObjectOfType<GameManager>();
        // required only if 
        //currentLapTimeBox = FindObjectOfType<Text>().name.Equals("LapTimeBestSecs");
        o_lapTimeManager = FindObjectOfType<LapTimeManager>();

        isSinglePlayer = o_gameManager.o_gameMode.Equals("Singleplayer");

    }

    void Start()
    {
        Rigidbody o_rigidbodyCar = gameObject.GetComponent<Rigidbody>();
        o_rigidbodyCar.centerOfMass = o_centerOfMassObj.localPosition;

        o_torqueAxis = "Vertical" + o_playerNumber;
        o_turningAxis = "Horizontal" + o_playerNumber;

    }

    void Update()
    {
        // commented to check if we can separate the lap counting code from the car code.
        //CalUpdateLapTime(); 
        GetInput();
    }

    // ----------------LapTimeManager-------------
    private void OnTriggerEnter(Collider other)
    {
        // Here you need to check if it is first lap or not
        if (other.CompareTag("StartLineTrigger"))
        {
            // Here you need to give the ref to the Lap counter Obj. if it is Single player and Time lapse mode.

            //CheckCurrBestLapTime();

            if (isSinglePlayer) {
                o_lapTimeManager.CheckCurrentBestLapTime();
            }
        }
    }

    // commented to check if we can separate the lap counting code from the car code.

    /*    private void CheckCurrBestLapTime()
        {
            // Here check if the lapStartTime is less than Best time
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

        private void CalUpdateLapTime()
        {
            // Here we are adding the time to the lapStartTime
            lapStartTime += Time.deltaTime;

            // Update the Lap time UI
            currentLapTimeBox.text = lapStartTime.ToString();
        }*/

    //------------------------------------

    private void FixedUpdate()
    {
       // GetInput();
        AddTorqueSteer();
        AlignWheelMeshToCollider();

    }

    private void GetInput()
    {
        o_verticalAxisInput = Input.GetAxis(o_torqueAxis);
        o_horizontalAxisInput = Input.GetAxis(o_turningAxis);
    }
   

    private void AddTorqueSteer()
    {
        o_wheelColliderLB.motorTorque = o_verticalAxisInput * o_maxTorque * Time.deltaTime * o_constantMultipleFactorTorque;
        o_wheelColliderRB.motorTorque = o_verticalAxisInput * o_maxTorque * Time.deltaTime * o_constantMultipleFactorTorque;

        o_wheelColliderLF.steerAngle = o_horizontalAxisInput * o_maxSteer * Time.deltaTime;
        o_wheelColliderRF.steerAngle = o_horizontalAxisInput * o_maxSteer * Time.deltaTime;
    }
    private void AlignWheelMeshToCollider()
    {
        AlignSingleWheelMesh(o_meshWheelLF, o_wheelColliderLF);
        AlignSingleWheelMesh(o_meshWheelLB, o_wheelColliderLB);
        AlignSingleWheelMesh(o_meshWheelRF, o_wheelColliderRF);
        AlignSingleWheelMesh(o_meshWheelRB, o_wheelColliderRB);
    }

    private void AlignSingleWheelMesh(Transform wheelMesh, WheelCollider wheelCollider)
    {
        wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion quat);
        wheelMesh.position = pos;
        wheelMesh.rotation = quat;
    }
}
