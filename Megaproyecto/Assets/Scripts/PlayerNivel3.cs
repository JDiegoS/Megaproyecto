using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class PlayerNivel3 : MonoBehaviour
{

    public Nivel3 manager;
    public CharacterController controller;
    public Animator animator;
    public bool safe;
    public Image cooldown;
    public Slider danger;
    public GameObject[] bats;
    public AudioManager audioManager;
    public NavMeshObstacle navObstacle;

    public bool usedDodge;
    public bool inZone = true;
    private float dodgedTime = 0;
    private float dangerVal = 0;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        navObstacle = gameObject.GetComponent<NavMeshObstacle>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !usedDodge)
        {
            animator.SetBool("crouch", true);
            audioManager.Play("Evadir");
            safe = true;
            navObstacle.enabled = true;
            usedDodge = true;
            StartCoroutine(DodgeEffect());

        }
        if (usedDodge)
        {
            dodgedTime += Time.deltaTime;
            cooldown.fillAmount = dodgedTime / 7;
        }

        if (dodgedTime > 7f)
        {
            usedDodge = false;
            dodgedTime = 0;
            cooldown.fillAmount = 1;
        }

        if (!safe)
        {
            dangerVal = GetClosestEnemy(bats);
            if (dangerVal <= 13)
            {
                danger.value = 1;
            }
            else
                danger.value = 13/dangerVal;
        }
        else
        {
            danger.value = 0;
        }

    }

    float GetClosestEnemy(GameObject[] enemies)
    {
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject g in enemies)
        {
            Vector3 t = g.transform.position;
            float dist = Vector3.Distance(t, currentPos);
            if (dist < minDist)
            {
                minDist = dist;
            }
        }
        return minDist;
    }

    IEnumerator DodgeEffect()
    {
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("crouch", false);
        yield return new WaitForSeconds(1.5f);
        if (!inZone)
        {
            navObstacle.enabled = false;
            safe = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "safezone")
        {
            navObstacle.enabled = true;
            safe = true;
            inZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "safezone")
        {
            navObstacle.enabled = false;
            safe = false;
            inZone = false;
        }
    }





}
