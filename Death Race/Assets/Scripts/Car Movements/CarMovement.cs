using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    float verticalAxisInput, horizontalAxisInput;
    [SerializeField] float maxTorque = 1000f;
    [SerializeField] float maxSteer = 1400f;
    [SerializeField] float constantMultipleFactorTorque = 100f;

    string torqueAxis = "Vertical";
    string turningAxis = "Horizontal";

    [SerializeField] WheelCollider wheelColliderLF;
    [SerializeField] WheelCollider wheelColliderLB;
    [SerializeField] WheelCollider wheelColliderRF;
    [SerializeField] WheelCollider wheelColliderRB;

    [SerializeField] Transform meshWheelLF;
    [SerializeField] Transform meshWheelLB;
    [SerializeField] Transform meshWheelRF;
    [SerializeField] Transform meshWheelRB;

    [SerializeField] Transform centerOfMassObj;

    void Start()
    {
        Rigidbody rigidbodyCar = gameObject.GetComponent<Rigidbody>();
        rigidbodyCar.centerOfMass = centerOfMassObj.localPosition;

    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        GetInput();
        AddTorqueSteer();
        AlignWheelMeshToCollider();

    }

    private void GetInput()
    {
        verticalAxisInput = Input.GetAxis(torqueAxis);
        horizontalAxisInput = Input.GetAxis(turningAxis);
    }

    private void AddTorqueSteer()
    {
        wheelColliderLB.motorTorque = verticalAxisInput * maxTorque * Time.deltaTime * constantMultipleFactorTorque;
        wheelColliderRB.motorTorque = verticalAxisInput * maxTorque * Time.deltaTime * constantMultipleFactorTorque;

        wheelColliderLF.steerAngle = horizontalAxisInput * maxSteer * Time.deltaTime;
        wheelColliderRF.steerAngle = horizontalAxisInput * maxSteer * Time.deltaTime;
    }
    private void AlignWheelMeshToCollider()
    {
        AlignSingleWheelMesh(meshWheelLF, wheelColliderLF);
        AlignSingleWheelMesh(meshWheelLB, wheelColliderLB);
        AlignSingleWheelMesh(meshWheelRF, wheelColliderRF);
        AlignSingleWheelMesh(meshWheelRB, wheelColliderRB);
    }

    private void AlignSingleWheelMesh(Transform wheelMesh, WheelCollider wheelCollider)
    {
        wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion quat);
        wheelMesh.position = pos;
        wheelMesh.rotation = quat;
    }
}
