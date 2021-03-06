﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    //public Text timerText;
    private float startTime;
    bool timeStarted;
    public void StartTime()
    {
        startTime = Time.time;
        timeStarted = true;
    }
    // Start is called before the first frame update
    void Start()
    {

        timeStarted = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (timeStarted)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            timerText.text = minutes + ":" + seconds;
        }
    }
}
