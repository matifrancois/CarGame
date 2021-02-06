using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject UIRacePanel;

    public Text UITextCurrentLap;
    public Text UITextCurrentTime;
    public Text UITextLastLapTime;
    public Text UITextBestLapTime;

    public Player UpdateUIForPlayer;

    private int currentLap = -1;
    private float currentTime = -1.0F;
    private float lastLapTime;
    private float bestLapTime;

    // Update is called once per frame
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
