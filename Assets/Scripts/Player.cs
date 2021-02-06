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

    private float lapTimerTimerStamp = 0.0F;
    private int lastCheckpointPassed = 0;

    private Transform checkPointsParent;
    private int checkPointCount;
    private int checkPointLayer;
    private CarController carController;

    private void Awake()
    {
        checkPointsParent = GameObject.Find("CheckPoints").transform;
        checkPointCount = checkPointsParent.childCount-1;
        //converts the strings checkpoints to number
        checkPointLayer = LayerMask.NameToLayer("CheckPoints");
        carController = GetComponent<CarController>();
    }

    void StartLap()
    {
        Debug.Log("Start Lap");
        currentLap++;
        lapTimerTimerStamp = Time.time;
    }

    void EndLap()
    {
        LastLapTime = Time.time - lapTimerTimerStamp;
        lapTimerTimerStamp = Time.time;
        BestLapTime = Mathf.Min(LastLapTime, BestLapTime);
        currentLap++;
        lastCheckpointPassed = 0;
        //Debug.Log("End Lap: Lap Time was: " + LastLapTime + "seconds");
    }

    //enter here if the object collides with another object
    private void OnTriggerEnter(Collider collider)
    {
        if ( collider.gameObject.layer != checkPointLayer)
        {
            return;
        }
        //if you pass the finish line
        if (collider.gameObject.name == "start")
        {
            //and if the lastCheckpoint was the last of the checkpoints in the lap
            if (lastCheckpointPassed == checkPointCount)
            {
                EndLap();
            }
            //if you are here it means that passed the start line so we call startLap method
            if (currentLap == 0)
            {
                StartLap();
                Debug.Log("started");
            }
            return;
        }
        if (collider.gameObject.name == (lastCheckpointPassed + 1).ToString())
        {
            lastCheckpointPassed++;
            Debug.Log(lastCheckpointPassed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CurrentLapTime = lapTimerTimerStamp > 0.0F ? Time.time - lapTimerTimerStamp : 0.0F;

        if (controlType == ControlType.HumanInput)
        {
            carController.Steer = GameManager.Instance.InputController.SteerInput;
            carController.Throttle = GameManager.Instance.InputController.ThroattelInput;
        }
    }
}
