using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    //horizontal reffers to the predefined variables that you can see in project settings->input
    public string inputSteerAxis = "Horizontal";
    public string inputThroattleAxis = "Vertical";

    public float ThroattelInput { get; private set; }
    public float SteerInput { get; private set; }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SteerInput = Input.GetAxis(inputSteerAxis);
        ThroattelInput = Input.GetAxis(inputThroattleAxis);
    }
}
