using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Nivel1 : MonoBehaviour
{

    public GameObject timer;
    //public TMP_Text timeText;
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
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ended)
        {
            //totalTime -= Time.deltaTime;
            timeRemaining -= Time.deltaTime;
            timer.transform.Rotate(0, 0, (1.5f * Time.deltaTime));
        }
        if (timeRemaining <= 0)
        {
            ended = true;
            StartCoroutine(TimeEnd());

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
            StartCoroutine(WonGame());
        }
    }

    IEnumerator TimeEnd()
    {
        yield return new WaitForSeconds(2);
        manager.Defeat();

    }

    IEnumerator WonGame()
    {
        ended = true;
        yield return new WaitForSeconds(2);
        manager.JuegoPelota();
    }
}
