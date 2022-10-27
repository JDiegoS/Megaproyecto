using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nivel3 : MonoBehaviour
{

    public GameObject timer;
    public PlayerNivel3 player;
    public GameManager manager;
    public AudioManager audioManager;
    public List<GameObject> zones;
    public float speed = 2;


    //public Text timeText;

    private float timeRemaining = 90;
    private bool ended = false;

    private float changedTime = 15f;
    float degrees = 0;
    private int currentZone;
    private bool first = true;

    private void Start()
    {
        Time.timeScale = 1;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        currentZone = 0;
        StartCoroutine(newZone());

    }

    void Update()
    {
        if (!ended)
        {
            timeRemaining -= Time.deltaTime;
            timer.transform.Rotate(0, 0,(speed * Time.deltaTime));
        }
        if (timeRemaining <= 0)
        {
            StartCoroutine(WonGame());

        }

        if (changedTime > 0)
        {
            changedTime -= Time.deltaTime;

        }
        else
        {
            StartCoroutine(newZone());
        }

    }

    public IEnumerator LostGame()
    {
        yield return new WaitForSeconds(2);
        audioManager.Play("Hit");
        manager.Defeat();
        ended = true;

    }

    IEnumerator WonGame()
    {
        ended = true;
        yield return new WaitForSeconds(2);
        manager.JuegoPelota();
    }

    public IEnumerator newZone()
    {
        if (!first)
        {

            zones[currentZone].gameObject.SetActive(false);
            int tempZone = currentZone;
            while (tempZone == currentZone)
                currentZone = Random.Range(0, zones.Count);
        }
        else
            first = false;

        zones[currentZone].gameObject.SetActive(true);
        Light light = zones[currentZone].gameObject.GetComponent<Light>();
        changedTime = 15;
        player.safe = false;

        yield return new WaitForSeconds(11.5f);

        
        light.enabled = false;
        yield return new WaitForSeconds(0.5f);
        light.enabled = true;
        yield return new WaitForSeconds(0.5f);

        light.enabled = false;
        yield return new WaitForSeconds(0.5f);
        light.enabled = true;
        yield return new WaitForSeconds(0.5f);

        light.enabled = false;
        yield return new WaitForSeconds(0.5f);
        light.enabled = true;



    }


}
