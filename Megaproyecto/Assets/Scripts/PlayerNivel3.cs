using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNivel3 : MonoBehaviour
{

    public Nivel3 manager;
    public CharacterController controller;


    public bool safe;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "safezone")
        {
            safe = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "safezone")
        {
            Debug.Log("salio");
            safe = false;
        }
    }





}
