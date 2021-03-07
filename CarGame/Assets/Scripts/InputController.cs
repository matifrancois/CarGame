/*******************************************************************************
  @file     InputController.cs
  @brief    This file controls the inputs of the user
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
public class InputController : MonoBehaviour
{
    //--------------------------------------------------------------
    //                Variables with public scope
    //--------------------------------------------------------------

    /*
     * horizontal and vertical reffer to the predefined variables that you can 
     * see in project settings->input
     */
    public string inputSteerAxis = "Horizontal";
    public string inputThroattleAxis = "Vertical";

    public float ThroattelInput { get; private set; }
    public float SteerInput { get; private set; }

    //---------------------------------------------------------------
    //                           Methods
    //----------------------------------------------------------------

    /*
     * @brief  Update is called once per frame
     * We use it to set the steerInput and ThroattelInput according to the user input.
     */
    void Update()
    {
        SteerInput = Input.GetAxis(inputSteerAxis);
        ThroattelInput = Input.GetAxis(inputThroattleAxis);
    }
}
