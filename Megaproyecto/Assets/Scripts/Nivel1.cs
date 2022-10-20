using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Nivel1 : MonoBehaviour
{

    public TMP_Text timeText;
    public TMP_Text counterText;

    public int totalItems = 5;
    public AudioManager audioManager;
    public GameManager manager;

    private int itemsCollected = 0;
    private float timeRemaining = 20;
    //private float totalTime= 20;
    private bool ended = false;


    private void Start()
    {
        audioManager.Play("Nivel1");

    }
    // Update is called once per frame
    void Update()
    {
        if (!ended)
        {
            //totalTime -= Time.deltaTime;
            timeRemaining -= Time.deltaTime;
            timeText.text = Mathf.FloorToInt(timeRemaining % 60).ToString();
        }
        if (timeRemaining <= 0)
        {
            ended = true;
            TimeEnd();

        }
        /*
        if (totalTime <= 0)
        {
            ended = true;
            WonGame();
        }
        */

    }

    public void AddTime()
    {
        audioManager.Play("Collect");

        timeRemaining += 10;
        itemsCollected += 1;
        counterText.text = itemsCollected + "/" + totalItems;
        if (itemsCollected == 5)
        {
            WonGame();
        }
    }

    public void TimeEnd()
    {

        manager.Defeat();
    }

    public void WonGame()
    {
        manager.Victory();

    }
}
