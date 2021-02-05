using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    public Transform centerOfMass;
    public float motorTorque = 1500f;
    public float maxSteer = 20f;

    public float Steer { get; set; }
    public float Throttle { get; set; }

    private Rigidbody _rigibody;
    private Wheel[] wheels;

    private void Start()
    {
        //get the wheel components of it children
        wheels = GetComponentsInChildren<Wheel>();
        _rigibody = GetComponent<Rigidbody>();
        _rigibody.centerOfMass = centerOfMass.localPosition;
    }

    void Update()
    {
        Steer = GameManager.Instance.InputController.SteerInput;
        Throttle = GameManager.Instance.InputController.ThroattelInput;

        foreach (var wheel in wheels)
        {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Throttle * motorTorque;
        }
    }

}


