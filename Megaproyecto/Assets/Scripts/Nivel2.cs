using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Nivel2 : MonoBehaviour
{
    //public TMP_Text timeText;
    public GameObject timer;
    public TMP_Text counterText;
    public CameraController camera;
    public GameObject ant;
    public AudioManager audioManager;
    public GameManager manager;
    public GameObject player1;
    public GameObject firstObjective;
    public GameObject secondObjective;
    public int totalItems = 4;
    public GameObject interaction;
    public Animator fade;

    private CharacterController player1cc;
    private CharacterController ant1cc;
    private PlayerController player1script;
    private PlayerController antscript;
    private PlayerNivel2 player1lvl;
    private PlayerNivel2 antlvl;



    public int itemsCollected = 0;
    public float timeRemaining = 100;
    float degrees = 0;
    private bool ended = false;


    private void Start()
    {
        Time.timeScale = 1;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audioManager.wonPelota = false;

        player1cc = player1.GetComponent<CharacterController>();
        ant1cc = ant.GetComponent<CharacterController>();
        player1script = player1.GetComponent<PlayerController>();
        antscript = ant.GetComponent<PlayerController>();
        player1lvl = player1.GetComponent<PlayerNivel2>();
        antlvl = ant.GetComponent<PlayerNivel2>();

        if (audioManager.currentScene != 2)
        {
            if (audioManager.currentVideo != 2)
            {
                audioManager.Stop("Nivel2");
                audioManager.currentVideo = 2;
                SceneManager.LoadScene("Videos");
            }
            else
                StartCoroutine(PlayTutorial());
        }
    }




    void Update()
    {
        if (!ended)
        {
            timeRemaining -= Time.deltaTime;

            timer.transform.Rotate(0, 0, (1.33f * Time.deltaTime));

            //transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime))
            /*
            int minutes = Mathf.FloorToInt(timeRemaining / 60F);
            int seconds = Mathf.FloorToInt(timeRemaining - minutes * 60);
            timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
            */
        }
        if (timeRemaining <= 0)
        {
            ended = true;
            StartCoroutine(TimeEnd());

        }

    }

    IEnumerator PlayTutorial()
    {
        yield return new WaitForSeconds(1);
        audioManager.currentScene = 2;
        manager.Tutorial();
    }

    public void changeToAnt()
    {
        player1script.animator.SetFloat("speed", 0);
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
        antscript.animator.SetFloat("speed", 0);
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
        audioManager.Play("Collect");
        itemsCollected += 1;
        counterText.text = itemsCollected + "/" + totalItems;
        if (itemsCollected >= totalItems)
        {
            interaction.SetActive(true);
            firstObjective.SetActive(false);
            secondObjective.SetActive(true);
        }
    }

    public IEnumerator TimeEnd()
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

    public IEnumerator WonGame()
    {
        ended = true;
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + 2f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;
        manager.JuegoPelota();


    }


}
