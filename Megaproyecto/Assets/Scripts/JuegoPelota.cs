using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JuegoPelota : MonoBehaviour
{

    public GameObject enemy;
    public GameObject player1;
    public CharacterController player1cc;
    public GameObject pelota;
    private Rigidbody rbPelota;
    public AudioManager audioManager;

    public Transform player1Spawn;
    public Transform enemySpawn;

    public Text scoreText;
    private int score1 = 0;
    private int score2 = 0;


    private void Start()
    {
        Time.timeScale = 1;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        rbPelota = pelota.GetComponent<Rigidbody>();
        StartCoroutine(PlayMusic());
    }

    IEnumerator PlayMusic()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        audioManager.Play("Pelota1");
    }
    public void updateScore()
    {
        if(score1 == 3)
        {
            scoreText.text = "GANO EQUIPO 1";
            Time.timeScale = 0f;
            return;
        }
        else if(score2 == 3){
            scoreText.text = "GANO EQUIPO 2";
            Time.timeScale = 0f;
            return;
        }
        scoreText.text = score1 + "-" + score2;


    }
    public void scoreTeam1()
    {
        audioManager.Play("Collect");
        score1 += 1;
        updateScore();
        resetPositions();

    }
    public void scoreTeam2()
    {
        audioManager.Play("Collect");
        score2 += 1;
        updateScore();
        resetPositions();
    }
    public void resetPositions()
    {
        player1cc.enabled = false;
        player1.transform.position = player1Spawn.position;
        player1cc.enabled = true;

        enemy.transform.position = enemySpawn.position;

        rbPelota.velocity = Vector3.zero;
        rbPelota.angularVelocity = Vector3.zero;
        pelota.transform.position = new Vector3(10, 1, -3);

        StartCoroutine(GamePauser());

    }

    public IEnumerator GamePauser()
    {
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + 2f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;
    }
}
