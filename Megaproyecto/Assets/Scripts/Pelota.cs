using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    public JuegoPelota manager;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ring1")
        {
            manager.scoreTeam2();
        }
        else if (collision.gameObject.name == "Ring2")
        {
            manager.scoreTeam1();
        }
    }
}
