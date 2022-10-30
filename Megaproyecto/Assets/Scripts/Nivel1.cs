using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Nivel1 : MonoBehaviour
{

    public GameObject timer;
    //public TMP_Text timeText;
    public TMP_Text counterText;

    public int totalItems = 5;
    public AudioManager audioManager;
    public Animator fade;
    public GameManager manager;

    private int itemsCollected = 0;
    private float timeRemaining = 30;
    //private float totalTime= 20;
    private bool ended = false;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        Time.timeScale = 1;
        audioManager.wonPelota = false;

        if (audioManager.currentScene != 1)
        {
            if (audioManager.currentVideo != 1)
            {
                audioManager.Stop("Nivel1");
                audioManager.currentVideo = 1;
                SceneManager.LoadScene("Videos");
            }
            else
                StartCoroutine(PlayTutorial());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!ended)
        {
            //totalTime -= Time.deltaTime;
            timeRemaining -= Time.deltaTime;
            timer.transform.Rotate(0, 0, (6f * Time.deltaTime));
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

    IEnumerator PlayTutorial()
    {
        yield return new WaitForSeconds(1);
        audioManager.currentScene = 1;
        manager.Tutorial();
    }

    public void AddTime()
    {
        audioManager.Play("Pluma");

        timeRemaining += 10;
        timer.transform.Rotate(0, 0, -60f);
        itemsCollected += 1;
        counterText.text = itemsCollected + "/" + totalItems;
        if (itemsCollected == 5)
        {
            StartCoroutine(WonGame());
        }
    }

    IEnumerator TimeEnd()
    {
        ended = true;
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + 2f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;
        manager.Defeat();

    }

    IEnumerator WonGame()
    {
        ended = true;
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + 2f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        fade.SetTrigger("Start");
        pauseEndTime = Time.realtimeSinceStartup + 1f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;
        manager.JuegoPelota();
    }
}
