using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject TutorialMenu;
    public GameObject MainUI;
    public GameObject Derrota;
    public Slider audioSlider;
    public Animator fade;
    public AudioManager audioManager;
    public bool mainMenu = false;
    private bool paused;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audioSlider.value = audioManager.volume;
        if (mainMenu)
            Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !mainMenu)
        {
            if (!paused)
            {
                audioManager.Play("Click");
                Pause();
            }
            else
            {
                audioManager.Play("Click");
                Resume();

            }
        }
    }


    public void Defeat()
    {
        MainUI.SetActive(false);
        Derrota.SetActive(true);
        Time.timeScale = 0;
    }
    public void Pause()
    {
        audioManager.Play("Click");
        PauseMenu.SetActive(true);
        MainUI.SetActive(false);
        Time.timeScale = 0;
        paused = true;
    }

    public void Tutorial()
    {
        audioManager.Play("Click");
        TutorialMenu.SetActive(true);
        MainUI.SetActive(false);
        Time.timeScale = 0;
        paused = true;
    }

    public void ChangeVolume()
    {
        audioManager.ChangeVolume(audioSlider.value);
    }

    public void Resume()
    {
        audioManager.Play("Click");
        paused = false;
        Time.timeScale = 1;
        MainUI.SetActive(true);
        TutorialMenu.SetActive(false);
        PauseMenu.SetActive(false);
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        audioManager.Play("Credits");
    }

    public void StartGCoroutine()
    {
        StartCoroutine(StartGame());
    }

    public IEnumerator StartGame()
    {
        fade.SetTrigger("Start");
        audioManager.Stop("Credits");
        yield return new WaitForSeconds(1);
        Nivel1();
    }

    public void Nivel1()
    {
        
        Time.timeScale = 1;
        SceneManager.LoadScene("Nivel1");
        if (audioManager.currentVideo == 1)
        audioManager.Play("Nivel1");
    }
    public void Nivel2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Nivel2");
        if (audioManager.currentVideo == 2)
            audioManager.Play("Nivel2");

    }
    public void Nivel3()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Nivel3");
        if (audioManager.currentVideo == 3)
        audioManager.Play("Nivel3");

    }

    public void JuegoPelota()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("JuegoPelota");
        audioManager.Play("Pelota1");
    }

    public void NextLevel()
    {
        int curr = audioManager.currentScene;
        if (audioManager.wonPelota)
            curr++;
        if (curr == 0)
        {
            StartGCoroutine();
            audioManager.Stop("Credits");
        }
        else if (curr == 1)
            Nivel1();
        else if (curr == 2)
            Nivel2();
        else if (curr == 3)
            Nivel3();
        else
        {
            SceneManager.LoadScene("Videos");
            audioManager.Stop("Home");
        }
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Nivel" + audioManager.currentScene);
    }

    public void Quit()
    {
        Application.Quit();
    }




}
