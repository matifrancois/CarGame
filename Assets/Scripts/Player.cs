using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum ControlType { HumanInput, AI }
    public ControlType controlType = ControlType.HumanInput;

    //we set the variable to infinity, that makes easy to compare later.
    public float BestLapTime { get; private set; } = Mathf.Infinity;
    public float LastLapTime { get; private set; } = 0.0F;
    public float CurrentLapTime { get; private set; } = 0.0F;
    public int currentLap { get; private set; } = 0;

    private float lapTimer;
    private int lastCheckpointPassed = 0;

    private Transform checkPointsParent;
    private int checkPointCount;
    private int checkPointLayer;
    private CarController carController;

    private void Awake()
    {
        checkPointsParent = GameObject.Find("CheckPoints").transform;
        checkPointCount = checkPointsParent.childCount;
        //converts the strings checkpoints to number
        checkPointLayer = LayerMask.NameToLayer("CheckPoints");
        carController = GetComponent<CarController>();
    }


    // Update is called once per frame
    void Update()
    {
        if (controlType == ControlType.HumanInput)
        {
            carController.Steer = GameManager.Instance.InputController.SteerInput;
            carController.Throttle = GameManager.Instance.InputController.ThroattelInput;
        }
    }
}
