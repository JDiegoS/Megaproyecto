using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nivel3 : MonoBehaviour
{

    public PlayerNivel3 player;
    public List<GameObject> zones;


    public Text timeText;

    private float timeRemaining = 20;
    private bool ended = false;

    private float changedTime = 5f;
    private int currentZone;

    private void Start()
    {
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
        timeText.text = "DERROTA";
        ended = true;

    }

    public void WonGame()
    {
        ended = true;
        timeText.text = "VICTORIA";

    }

    public void newZone()
    {
        zones[currentZone].gameObject.SetActive(false);
        int tempZone = currentZone;
        while (tempZone == currentZone)
            currentZone = Random.Range(0, zones.Count);
        zones[currentZone].gameObject.SetActive(true);
        changedTime = 5;
        player.safe = false;

    }


}
