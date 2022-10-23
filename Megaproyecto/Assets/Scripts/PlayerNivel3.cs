using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNivel3 : MonoBehaviour
{

    public Nivel3 manager;
    public CharacterController controller;
    public bool safe;

    public bool usedDodge;
    private float dodgedTime = 0;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !usedDodge)
        {
            safe = true;
            usedDodge = true;
            StartCoroutine(DodgeEffect());

        }
        if (usedDodge)
        {
            dodgedTime += Time.deltaTime;
        }

        if (dodgedTime > 5f)
        {
            usedDodge = false;
            dodgedTime = 0;
        }

    }

    IEnumerator DodgeEffect()
    {
        yield return new WaitForSeconds(2);
        safe = false;
    }

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
            safe = false;
        }
    }





}
