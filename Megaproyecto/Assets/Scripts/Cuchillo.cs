using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchillo : MonoBehaviour
{
    public Nivel2 manager;
    public AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ant")
        {
            StartCoroutine(manager.TimeEnd());
            audioManager.Play("KnifeHit");
        }
    }
}
