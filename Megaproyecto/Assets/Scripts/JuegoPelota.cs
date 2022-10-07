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

    public Transform player1Spawn;
    public Transform enemySpawn;

    public Text scoreText;
    private int score1 = 0;
    private int score2 = 0;


    private void Start()
    {
        rbPelota = pelota.GetComponent<Rigidbody>();
    }
    public void updateScore()
    {
        if(score1 == 3)
        {
            scoreText.text = "GANO EQUIPO 1";
            return;
        }
        else if(score2 == 3){
            scoreText.text = "GANO EQUIPO 2";
            return;
        }
        scoreText.text = score1 + "-" + score2;


    }
    public void scoreTeam1()
    {
        score1 += 1;
        updateScore();
        resetPositions();

    }
    public void scoreTeam2()
    {
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
        Debug.Log("Inside PauseGame()");
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + 2f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;
        Debug.Log("Done with my pause");
    }
}
