using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    public int level;
    public AudioManager audioManager;
    public GameManager manager;
    public GameObject video1;
    public GameObject video2;
    public GameObject video3;
    public GameObject video4;
    public GameObject video5;
    public GameObject video6;
    public GameObject video7;
    public GameObject video8;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        if (audioManager.currentScene == 0)
            StartCoroutine(Nivel1());
        else if (audioManager.currentScene == 1)
            StartCoroutine(Nivel2());
        else if (audioManager.currentScene == 2)
            StartCoroutine(Nivel3());
        else
            StartCoroutine(Final());
    }

    public IEnumerator Nivel1()
    {
        video1.SetActive(true);
        yield return new WaitForSeconds(58);
        video1.SetActive(false);
        video2.SetActive(true);
        yield return new WaitForSeconds(5);
        video2.SetActive(false);
        video3.SetActive(true);
        yield return new WaitForSeconds(31);
        manager.Nivel1();
    }

    public IEnumerator Nivel2()
    {
        video4.SetActive(true);
        yield return new WaitForSeconds(12);
        video4.SetActive(false);
        video5.SetActive(true);
        yield return new WaitForSeconds(24);
        manager.Nivel2();
    }

    public IEnumerator Nivel3()
    {
        video6.SetActive(true);
        yield return new WaitForSeconds(5);
        video6.SetActive(false);
        video7.SetActive(true);
        yield return new WaitForSeconds(8);
        manager.Nivel3();
    }

    public IEnumerator Final()
    {
        video8.SetActive(true);
        yield return new WaitForSeconds(63);
        manager.Home();
        audioManager.currentScene = 0;
        audioManager.currentVideo = 0;
        audioManager.wonPelota = false;
    }
}
