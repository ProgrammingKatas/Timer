using System;

public class Timer {

    public float duration { get; private set; }
    private float targetTime;
    private bool isCooldown;
    public event Action OnTimerEnd;

    public Timer(float duration, bool isCooldown) {

        this.isCooldown = isCooldown;

        if (isCooldown) this.duration = duration;
        else
        {
            this.duration = 0;
            targetTime = duration;
        }      

    }

    public void PassTime(float currentTime) {

        if(duration == 0 || !isCooldown) return;

        duration -= currentTime;

        if (duration > 0) return;

        duration = 0;
        OnTimerEnd?.Invoke(); 

    }

    public void CountTime(float currentTime) {

        if (targetTime == duration || isCooldown) return;

        duration += currentTime;

        if(duration < targetTime) return;

        duration = targetTime;
        OnTimerEnd?.Invoke();

    }

}