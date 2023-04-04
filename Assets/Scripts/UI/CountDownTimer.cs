using UnityEngine.UI;
using UnityEngine;
using System;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] Text countDownTimer;

    private float timeForOneRound = 90f; //90 seconds

    public event EventHandler OnTimeFinished;
   
    void Update()
    {
        if(timeForOneRound > 0)
        {
            timeForOneRound -= Time.deltaTime;
        }
        else
        {
            //Game over.
            timeForOneRound = 0;
            OnTimeFinished?.Invoke(this, EventArgs.Empty);
        }

        DisplayTime(timeForOneRound);
    }

    private void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeForOneRound / 60);
        float seconds = Mathf.FloorToInt(timeForOneRound % 60);
        countDownTimer.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
