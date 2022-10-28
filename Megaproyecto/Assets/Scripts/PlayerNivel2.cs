using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNivel2 : MonoBehaviour
{

    public Nivel2 manager;

    public int playerType = 1;
    public GameObject flores;
    public GameObject interaction;
    public Collider antTrigger;

    public AudioManager audioManager;

    bool changed = false;
    bool close = false;
    bool closeJarron = false;
    private float changedTime = 0;
    private string otherType = "ant";

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        if (playerType == 2)
        {
            otherType = "Player";
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (close)
            {
                changed = true;
                if (playerType == 1)
                {
                    interaction.SetActive(false);
                    manager.changeToAnt();
                }
                else
                {
                    manager.changeToPlayer();

                }
            }
            if (closeJarron && manager.itemsCollected == 4)
            {
                flores.SetActive(true);
                StartCoroutine(WinGame());

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

    IEnumerator WinGame()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(manager.WonGame());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Jarron")
        {
            closeJarron = true;
        }
        if (other.gameObject.name == "activate")
        {
            antTrigger.enabled = true;
        }
        if (other.gameObject.name == "deactivate")
        {
            antTrigger.enabled = false;
        }
        if (other.gameObject.tag == otherType)
        {
            close = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Jarron")
        {
            closeJarron = false;
        }
        if (other.gameObject.tag == otherType)
        {
            close = false;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "knife")
        {
            audioManager.Play("KnifeHit");
            StartCoroutine(manager.TimeEnd());
        }
    }





}
