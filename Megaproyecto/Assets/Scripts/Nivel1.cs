using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nivel1 : MonoBehaviour
{

    public Text timeText;

    private float timeRemaining = 5;
    private float totalTime= 20;
    private bool ended = false;

    // Update is called once per frame
    void Update()
    {
        if (!ended)
        {
            totalTime -= Time.deltaTime;
            timeRemaining -= Time.deltaTime;
            timeText.text = Mathf.FloorToInt(timeRemaining % 60).ToString();
        }
        if (timeRemaining <= 0)
        {
            ended = true;
            TimeEnd();

        }
        if (totalTime <= 0)
        {
            ended = true;
            WonGame();
        }

    }

    public void AddTime()
    {
        timeRemaining += 5;
    }

    public void TimeEnd()
    {
        timeText.text = "DERROTA";

    }

    public void WonGame()
    {
        timeText.text = "VICTORIA";

    }
}
