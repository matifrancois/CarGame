/*******************************************************************************
  @file     GameManager.cs
  @brief    This file connects the Game Manager and the InputController 
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

public class GameManager : MonoBehaviour
{

    //--------------------------------------------------------------
    //                Variables with public scope
    //--------------------------------------------------------------

    public static GameManager Instance { get; private set; }
    public InputController InputController { get; private set; }

    //---------------------------------------------------------------
    //                           Methods
    //----------------------------------------------------------------

    /*
     *awake runs before than start, we want that appens as soon as posible
     */
    void Awake()
    {
        Instance = this;
        InputController = GetComponentInChildren<InputController>();
    }
}
