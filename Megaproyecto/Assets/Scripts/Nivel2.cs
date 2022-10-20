using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nivel2 : MonoBehaviour
{

    public CameraController camera;
    public GameObject ant;
    public GameManager manager;
    public GameObject player1;
    private CharacterController player1cc;
    private CharacterController ant1cc;
    private PlayerController player1script;
    public AudioManager audioManager;
    private PlayerController antscript;
    private PlayerNivel2 player1lvl;
    private PlayerNivel2 antlvl;


    public Text timeText;

    private int itemsCollected = 0;
    private float timeRemaining = 20;
    private bool ended = false;


    private void Start()
    {
        player1cc = player1.GetComponent<CharacterController>();
        ant1cc = ant.GetComponent<CharacterController>();
        player1script = player1.GetComponent<PlayerController>();
        antscript = ant.GetComponent<PlayerController>();
        player1lvl = player1.GetComponent<PlayerNivel2>();
        antlvl = ant.GetComponent<PlayerNivel2>();
        audioManager.Play("Nivel2");
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
            ended = true;
            TimeEnd();

        }

    }

    public void changeToAnt()
    {
        player1cc.enabled = false;
        player1script.enabled = false;
        player1lvl.enabled = false;
        ant1cc.enabled = true;
        antscript.enabled = true;
        antlvl.enabled = true;
        camera.ChangeTarget(2);
    }

    public void changeToPlayer()
    {
        player1cc.enabled = true;
        player1script.enabled = true;
        player1lvl.enabled = true;
        ant1cc.enabled = false;
        antscript.enabled = false;
        antlvl.enabled = false;
        camera.ChangeTarget(1);

    }

    public void CollectItem()
    {
        itemsCollected += 1;
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
        ended = true;
        manager.Victory();


    }


}
