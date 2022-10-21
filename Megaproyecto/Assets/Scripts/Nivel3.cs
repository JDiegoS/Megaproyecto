using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nivel3 : MonoBehaviour
{

    public PlayerNivel3 player;
    public GameManager manager;
    public AudioManager audioManager;
    public List<GameObject> zones;


    public Text timeText;

    private float timeRemaining = 60;
    private bool ended = false;

    private float changedTime = 15f;
    private int currentZone;

    private void Start()
    {
        Time.timeScale = 1;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        currentZone = 0;
        zones[currentZone].gameObject.SetActive(true);

    }

    void Update()
    {
        if (!ended)
        {
            timeRemaining -= Time.deltaTime;
            timeText.text = Mathf.FloorToInt(timeRemaining % 60).ToString();
        }
        if (timeRemaining <= 0)
        {
            WonGame();

        }

        if (changedTime > 0)
        {
            changedTime -= Time.deltaTime;

        }
        else
        {
            newZone();
        }

    }

    public void LostGame()
    {
        manager.Defeat();
        ended = true;

    }

    public void WonGame()
    {
        ended = true;
        manager.Victory();


    }

    public void newZone()
    {
        zones[currentZone].gameObject.SetActive(false);
        int tempZone = currentZone;
        while (tempZone == currentZone)
            currentZone = Random.Range(0, zones.Count);
        zones[currentZone].gameObject.SetActive(true);
        changedTime = 15;
        player.safe = false;

    }


}
