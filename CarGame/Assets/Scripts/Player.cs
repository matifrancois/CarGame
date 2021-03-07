/*******************************************************************************
  @file     Player.cs
  @brief    This file store the information of the user and controls things like 
            the best lap time and the checkPoints passed etc.
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

public class Player : MonoBehaviour
{
    //--------------------------------------------------------------
    //                Variables with public scope
    //--------------------------------------------------------------
    /*
     * ControlType: enum to select if there is an human or an AI who controls the user.
     * controlType: variable to select the enum controlType
     */
    public enum ControlType { HumanInput, AI }
    public ControlType controlType = ControlType.HumanInput;

    /*
     * BestLapTime: best lap time, start with infinity to facilitate the comparison after with the new lap time.
     * LastLapTime: last lap time, start in 0 and update every lap
     * CurrentLapTime: current lap time, start in 0 and update every frame
     * currentLap: current lap's number, update every lap
     */
    //we set the variable to infinity, that makes easy to compare later.
    public float BestLapTime { get; private set; } = Mathf.Infinity;
    public float LastLapTime { get; private set; } = 0.0F;
    public float CurrentLapTime { get; private set; } = 0.0F;
    public int currentLap { get; private set; } = 0;

    //--------------------------------------------------------------
    //                Variables with private scope
    //--------------------------------------------------------------
    /*
     * lapTimerStamp: Facilitate the control of the time in every lap
     * lastCheckpointPassed: store the last checkpoint to know if the gamer cheated
     * checkPointsParent: get the checkpoints 
     * checkPointCount: get the number of checkpoints
     * checkPointLayer: all the checkpoins are in the same layer
     * carController: instance of a CarController class
     */
    private float lapTimerStamp = 0.0F;
    private int lastCheckpointPassed = 0;

    private Transform checkPointsParent;
    private int checkPointCount;
    private int checkPointLayer;
    private CarController carController;

    //---------------------------------------------------------------
    //                           Methods
    //----------------------------------------------------------------
    /*
     * awake runs before than start, we want that appens as soon as posible
     * here we use it to find the checkpoints and the information of unity, like
     * the number of checkpoints, the layer and the CarController. 
     */
    private void Awake()
    {
        checkPointsParent = GameObject.Find("CheckPoints").transform;
        checkPointCount = checkPointsParent.childCount-1;
        //converts the strings checkpoints to number
        checkPointLayer = LayerMask.NameToLayer("CheckPoints");
        carController = GetComponent<CarController>();
    }

    /*
     * @brief  this method is called in every new lap
     */
    void StartLap()
    {
        Debug.Log("Start Lap");
        currentLap++;
        lapTimerStamp = Time.time;
    }

    /*
    * @brief  this method is called when a lap is completed.
    */
    void EndLap()
    {
        LastLapTime = Time.time - lapTimerStamp;
        lapTimerStamp = Time.time;
        BestLapTime = Mathf.Min(LastLapTime, BestLapTime);
        currentLap++;
        lastCheckpointPassed = 0;
        //Debug.Log("End Lap: Lap Time was: " + LastLapTime + "seconds");
    }

    /*
     * @brief you would be here if the object collides with another object, 
     * we use it to controll the checkpoints passed
     */
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

    /*
     * @brief  Update is called once per frame
     * here we modify the current lap time and the steer and throttle of the instance of the CarController class
     */
    void Update()
    {
        CurrentLapTime = lapTimerStamp > 0.0F ? Time.time - lapTimerStamp : 0.0F;

        if (controlType == ControlType.HumanInput)
        {
            carController.Steer = GameManager.Instance.InputController.SteerInput;
            carController.Throttle = GameManager.Instance.InputController.ThroattelInput;
        }
    }
}
