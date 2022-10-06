using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JuegoPelota : MonoBehaviour
{

    public GameObject player1;
    public CharacterController player1cc;
    public GameObject pelota;

    public Transform player1Spawn;

    public Text scoreText;
    private int score1 = 0;
    private int score2 = 0;


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

        pelota.transform.position = new Vector3(10, 1, -3);
    }
}
