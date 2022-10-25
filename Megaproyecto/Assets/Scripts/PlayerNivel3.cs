using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class PlayerNivel3 : MonoBehaviour
{

    public Nivel3 manager;
    public CharacterController controller;
    public bool safe;
    private NavMeshObstacle navObstacle;

    public bool usedDodge;
    private float dodgedTime = 0;

    private void Start()
    {
        navObstacle = gameObject.GetComponent<NavMeshObstacle>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !usedDodge)
        {
            safe = true;
            navObstacle.enabled = true;
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
        navObstacle.enabled = false;
        safe = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "safezone")
        {
            navObstacle.enabled = true;
            safe = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "safezone")
        {
            navObstacle.enabled = false;
            safe = false;
        }
    }





}
