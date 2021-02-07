/*******************************************************************************
  @file     CameraFollow.cs
  @brief    This file controls the movement of the camarae in order to follow
            the movement of the car
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
public class CameraFollow : MonoBehaviour
{
    //--------------------------------------------------------------
    //                Variables with public scope
    //--------------------------------------------------------------

    /*
     * Target allow the user to select the object to follow
     */
    public Transform Target;

    /*
     * Offset and EulerRotation allow the user to set the position of the camara 
     * according with the position of the Target Object
     */
    public Vector3 offset;
    public Vector3 eulerRotation;
    /*
     * Damper allow the user to select the following speed of the camara
     */
    public float damper;

    //---------------------------------------------------------------
    //                           Methods
    //----------------------------------------------------------------

    /*
     * @brief  Start is called before the first frame update
     * here we use it to get the rotation
     */
    void Start()
    {
        transform.eulerAngles = eulerRotation;
    }
    /*
    * @brief  FixedUpdate is called 100 times per second
    * We use it to set the position of the camara (is important to be here and 
    * not in start method because we dont want to see the camera movement with lag
    */
    void FixedUpdate()
    {
        if (Target == null)
            return;
        transform.position = Vector3.Lerp(transform.position, Target.position + offset, damper * Time.deltaTime); 
    }
}
