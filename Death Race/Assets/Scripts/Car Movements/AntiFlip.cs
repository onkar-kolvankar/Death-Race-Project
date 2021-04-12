using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiFlip : MonoBehaviour
{
    Rigidbody rb;

    LapPosCalculator lapPosCalculator;

    public float passedTime;

    [SerializeField] WheelCollider o_wheelColliderLB;
    [SerializeField] WheelCollider o_wheelColliderRB;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        lapPosCalculator = gameObject.GetComponent<LapPosCalculator>();

    }

    private void FixedUpdate()
    {
        /* 
            LOGIc - If a vechile is stop and motorTorque on WC is Not zero then the vechile is stuck.
             - if the vechile is stop and motorTorque on WC is Not zero but brake torque == 0 means user is pressing Brake key with the Acceleration key
             - this would have been considered as the vechile stuck thus used the last brakeTorque == 0 condition.

        */
        if (rb.velocity.magnitude < 0.015f && o_wheelColliderLB.motorTorque != 0 && o_wheelColliderLB.brakeTorque == 0)
        {
           // Debug.Log("rb.velocity.magnitude == 0");
            if (rb.transform.up.y < 1f && passedTime >= 3f)
            {
                //gameObject.transform.position += Vector3.up;
                //gameObject.transform.rotation = Quaternion.LookRotation(gameObject.transform.forward * Time.deltaTime);

               // Debug.Log("rb.transform.up.y = " + rb.transform.up.y);

                lapPosCalculator.RespawnAtPrevPos();

                if (rb.transform.up.y < 0.8f)
                {
                    passedTime += Time.deltaTime;
                }
                else
                {
                    passedTime = 0f;
                }
            }
            else if (rb.transform.up.y < 1f && passedTime < 10f)
            {
               // Debug.Log("rb.transform.up.y = " + rb.transform.up.y);
                passedTime += Time.deltaTime;
            }
        }
        else {
           // Debug.Log("rb.velocity.magnitude = " + rb.velocity.magnitude + "  o_wheelColliderLB.motorTorque = " + o_wheelColliderLB.motorTorque);
            passedTime = 0f;
        }
        
    }


}
