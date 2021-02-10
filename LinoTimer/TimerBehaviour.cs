using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class TimerBehaviour : MonoBehaviour
{
    public float duration;
    public float timeRemaining;
    public bool isCooldown;
    public Timer timer;
    public Timer timer2;
    public UnityEvent OnTimerEnd;

    private void Start()
    {
        timer = new Timer(duration, isCooldown);
        timer.OnTimerEnd += OnFinish;
    }

    private void Update()
    {
        timer.PassTime(Time.deltaTime);
        timer.CountTime(Time.deltaTime);
        timeRemaining = timer.duration;
    }

    public void OnFinish()
    {
        Debug.Log("Timer end!!!");
    }

}
