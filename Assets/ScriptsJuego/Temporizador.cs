using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{

    public Text gameTimerText;
    float gamerTimer = 0f;

    void Update()
    {
        gamerTimer += Time.deltaTime;

        int seconds = (int)(gamerTimer % 60);
        int minutes = (int)(gamerTimer / 60) % 60;
        int hours = (int)(gamerTimer / 3600) % 24;

        string timerString = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);

        gameTimerText.text = timerString;
    }


}
