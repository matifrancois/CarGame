/*******************************************************************************
  @file     Wheel.cs
  @brief    This file controls the movement of the wheels (rotation and translation)
  @author   Matias Francois
 ******************************************************************************/

/*******************************************************************************
 *							USING FILES
 ******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************************************
*					CLASSES WITH GLOBAL SCOPE
******************************************************************************/
public class Wheel : MonoBehaviour
{
    //--------------------------------------
    //      Variables with public scope
    //--------------------------------------
    /* 
     * Every wheel could choose if it has steer ability, power ability and if it has invertSteer
     * for example in a normal scenario the car would have the two front wheels with streer, the 
     * two back wheels with power and the invertSteer in no one of them, the invert steer allows to the
     * back wheels to be steer, so if you want to steer with the back wheels you must to select the invert steer in those
     */
    public bool steer;
    public bool invertSteer;
    public bool power;

    /*
    * This variables allows the user to select the steer angle and the torque of the vehicle's wheels.
    */
    public float SteerAngle { get; set; }
    public float Torque { get; set; }

    //--------------------------------------
    //      Variables with private scope
    //--------------------------------------

    private WheelCollider wheelCollider;
    private Transform wheelTransform;

    //--------------------------------------
    //              Methods
    //--------------------------------------

    /*
    * @brief  Start is called before the first frame update
    * here we use it to get the child components that we need.
    */
    void Start()
    {
        wheelCollider = GetComponentInChildren<WheelCollider>();
        wheelTransform = GetComponentInChildren<MeshRenderer>().GetComponent<Transform>();
    }

    /*
    * @brief  Update is called once per frame
    * We use it to set the position and rotation of the wheels in every frame.
    */

    void Update()
    {
        wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }

    /*
    * @brief  FixedUpdate is called 100 times per second
    * We use it to set the steerAngle and the Torque in the wheels that has the ability to have those.
    */
    private void FixedUpdate()
    {
        if(steer)
        {
            wheelCollider.steerAngle = SteerAngle * (invertSteer ? -1 : 1);
        }    

        if(power)
        {
            wheelCollider.motorTorque = Torque;
        }
    }
}
