using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{

    Rigidbody o_rigidbodyCar;
    // obj to Lap timer
    GameObject o_countDownObj;
    LapTimeManager o_lapTimeManager;
    GameStatus o_gameStatus;


    // used to identify which car it is and accordingly use Vertical and Horizontal axis.
    public int o_playerNumber  = 1; // default value for single player mode.

    float o_verticalAxisInput, o_horizontalAxisInput , o_brakeTorqueInput;
    [SerializeField] float o_maxTorque = 1000f;
    [SerializeField] float o_maxSteer = 1400f;
    [SerializeField] int o_brakeTorque = 1000;

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

    bool o_gamePaused = false;
    

    private void Awake()
    {
        o_gameManager = FindObjectOfType<GameManager>();
        // required only if 
        //currentLapTimeBox = FindObjectOfType<Text>().name.Equals("LapTimeBestSecs");
        o_lapTimeManager = FindObjectOfType<LapTimeManager>();
        o_gameStatus = FindObjectOfType<GameStatus>();

        isSinglePlayer = o_gameManager.o_gameMode.Equals("Singleplayer");

    }

    void Start()
    {
        o_rigidbodyCar = gameObject.GetComponent<Rigidbody>();
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
        if (other.CompareTag("Checkpoints") && other.name == "0")
        {
            // Here you need to give the ref to the Lap counter Obj. if it is Single player and Time lapse mode.

            //CheckCurrBestLapTime();

            if (isSinglePlayer) {
                o_lapTimeManager.CheckCurrentBestLapTime();
            }

            
        }

        if (other.CompareTag("Finish")) {
            if (o_gameStatus.n_LapsCompleted[o_playerNumber - 1] >= 3) {
                // if the player has completed the race then stop it / make it kinematic
                o_rigidbodyCar.isKinematic = true;
            }
        }

       
    }

    private void FixedUpdate()
    {
       // GetInput();
        AddTorqueSteer();
        AlignWheelMeshToCollider();
        AddBrakeTroqueSteer();

    }

    private void GetInput()
    {
        o_verticalAxisInput = Input.GetAxis(o_torqueAxis);
        o_horizontalAxisInput = Input.GetAxis(o_turningAxis);
        o_brakeTorqueInput = Input.GetAxis("Brake" + o_playerNumber);

    }
   

    private void AddTorqueSteer()
    {
        o_wheelColliderLB.motorTorque = o_verticalAxisInput * o_maxTorque * Time.deltaTime * o_constantMultipleFactorTorque;
        o_wheelColliderRB.motorTorque = o_verticalAxisInput * o_maxTorque * Time.deltaTime * o_constantMultipleFactorTorque;

        o_wheelColliderLF.steerAngle = o_horizontalAxisInput * o_maxSteer * Time.deltaTime;
        o_wheelColliderRF.steerAngle = o_horizontalAxisInput * o_maxSteer * Time.deltaTime;
    }

    private void AddBrakeTroqueSteer() {
        o_wheelColliderLB.brakeTorque = o_brakeTorqueInput * o_brakeTorque * Time.deltaTime * 1000000f;
        o_wheelColliderRB.brakeTorque = o_brakeTorqueInput * o_brakeTorque * Time.deltaTime * 1000000f;
       // o_wheelColliderLF.brakeTorque = o_brakeTorqueInput * o_brakeTorque * Time.deltaTime * 1000000f;
       // o_wheelColliderRF.brakeTorque = o_brakeTorqueInput * o_brakeTorque * Time.deltaTime * 1000000f;


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
