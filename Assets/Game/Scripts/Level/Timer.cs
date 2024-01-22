using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public float timerTime;
    public GameManager gmRef;

    private int minutes, seconds;

    private void Start()
    {
        timerText = GetComponent<TMP_Text>();

        TimerFunction();
    }

    void Update()
    {
        if (gmRef.startParty)
        {
            TimerFunction();
        }
    }

    private void TimerFunction()
    {
        if (timerTime <= 0)
        {
            gmRef.ResetLevel();
            timerTime = 61f;
        }
        timerTime -= Time.deltaTime;

        minutes = (int)(timerTime / 60f);
        seconds = (int)(timerTime - minutes * 60f);

        timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
    }
}
