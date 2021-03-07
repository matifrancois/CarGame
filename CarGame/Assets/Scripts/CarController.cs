/*******************************************************************************
  @file     CarController.cs
  @brief    This file access to the car's rigibody and controls the car's wheels
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

public class CarController : MonoBehaviour
{
    //--------------------------------------------------------------
    //                Variables with public scope
    //--------------------------------------------------------------
    /*
     * centerOfMass: Allow the user to change the center of mass of the object
     * motorTorque: Allow the user to change the car's torque
     * maxSteer: Allow the user to change the angle of the steer's rotation
     */
    public Transform centerOfMass;
    public float motorTorque = 1500f;
    public float maxSteer = 20f;

    public float Steer { get; set; }
    public float Throttle { get; set; }

    //--------------------------------------------------------------
    //                Variables with private scope
    //--------------------------------------------------------------
    /*
     * _rigibody: allow to the class to work with it own rigibody information
     * Wheels: allow to the class to work with their own wheels
     */
    private Rigidbody _rigibody;
    private Wheel[] wheels;

    //---------------------------------------------------------------
    //                           Methods
    //----------------------------------------------------------------

    /*
     * @brief  Start is called before the first frame update
     * here we get the information of the wheels and the rigibody of the car
     */
    private void Start()
    {
        //get the wheel components of their children
        wheels = GetComponentsInChildren<Wheel>();
        _rigibody = GetComponent<Rigidbody>();
        _rigibody.centerOfMass = centerOfMass.localPosition;
    }


    /*
     * @brief  Update is called once per frame
     * here we modify the steerAngle and the torque of the car.
     */
    void Update()
    {
        foreach (var wheel in wheels)
        {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Throttle * motorTorque;
        }
    }

}


