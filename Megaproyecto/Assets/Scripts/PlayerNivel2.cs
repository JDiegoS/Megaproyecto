using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNivel2 : MonoBehaviour
{

    public Nivel2 manager;

    public int playerType = 1;


    bool changed = false;
    bool close = false;
    private float changedTime = 0;
    private string otherType = "ant";

    private void Start()
    {
        if (playerType == 2)
        {
            otherType = "Player";
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && close)
        {
            
            changed = true;
            if (playerType == 1)
            {
                manager.changeToAnt();
            }
            else
            {
                manager.changeToPlayer();

            }

        }

        if (changed)
        {
            changedTime += Time.deltaTime;
        }

        if (changedTime > 1f)
        {
            changed = false;
            changedTime = 0;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == otherType)
        {
            close = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == otherType)
        {
            close = false;
        }
    }




}
