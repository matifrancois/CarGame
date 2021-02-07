/*******************************************************************************
  @file     UIController.cs
  @brief    This file controls wat is showed in the UI Panel
  @author   Matias Francois
 ******************************************************************************/

/*******************************************************************************
 *							USING FILES
 ******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*******************************************************************************
*					CLASSES WITH GLOBAL SCOPE
******************************************************************************/

public class UIController : MonoBehaviour
{
    //--------------------------------------------------------------
    //                Variables with public scope
    //--------------------------------------------------------------

    /*
     * UIRacePanel: Allow the class to use the UIPanel created in unity by the user
     * 
     * UITextCurrentLap: Allow the class to change the Current lap number
     * UITextCurrentTime: Allow the class to change the Current lap time
     * UITextLastLapTime: Allow the class to change the last lap time
     * UITextBestLapTime: Allow the class to change the best lap time
     * 
     * UpdateUIForPlayer: get access to the player class to know the information inside
     */

    public GameObject UIRacePanel;

    public Text UITextCurrentLap;
    public Text UITextCurrentTime;
    public Text UITextLastLapTime;
    public Text UITextBestLapTime;

    public Player UpdateUIForPlayer;

    //--------------------------------------------------------------
    //                Variables with private scope
    //--------------------------------------------------------------

    /*
     * These variables facilitate the task of showing the values on the display
     */

    private int currentLap = -1;
    private float currentTime = -1.0F;
    private float lastLapTime;
    private float bestLapTime;

    //---------------------------------------------------------------
    //                           Methods
    //----------------------------------------------------------------

    /*
     * @brief  Update is called once per frame
     * here we modify the Texts that are showed inside the UI Panel
     */
    void Update()
    {
        if(UpdateUIForPlayer == null)
            return;
        if (UpdateUIForPlayer.currentLap != currentLap)
        {
            currentLap = UpdateUIForPlayer.currentLap;
            UITextCurrentLap.text = $"Lap: {currentLap}";
        }

        if (UpdateUIForPlayer.CurrentLapTime != currentTime)
        {
            currentTime = UpdateUIForPlayer.CurrentLapTime;
            UITextCurrentTime.text = $"Time: {(int)currentTime / 60}:{(currentTime) % 60:00.000}";
        }

        if(UpdateUIForPlayer.LastLapTime != lastLapTime)
        {
            lastLapTime = UpdateUIForPlayer.LastLapTime;
            UITextLastLapTime.text = $"Last Lap: {(int)lastLapTime / 60}:{(lastLapTime) % 60:00.000}";
        }

        if (UpdateUIForPlayer.BestLapTime != bestLapTime)
        {
            bestLapTime = UpdateUIForPlayer.BestLapTime;
            UITextBestLapTime.text = UpdateUIForPlayer.BestLapTime == Mathf.Infinity ? $"Best Lap: {(int)0.0F / 60}:{(0.0F) % 60:00.000}" : $"Best Lap: {(int)bestLapTime / 60}:{(bestLapTime) % 60:00.000}";
        }
    }
}
