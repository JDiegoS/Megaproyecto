using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject MainUI;
    public GameObject Derrota;
    public Slider audioSlider;
    public AudioManager audioManager;
    public bool mainMenu = false;

    private int currentScene;
    private bool paused;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !mainMenu)
        {
            if (!paused)
            {
                Pause();
            }
            else
            {
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

    public void ChangeVolume()
    {
        AudioListener.volume = audioSlider.value;
    }

    public void Resume()
    {
        audioManager.Play("Click");
        paused = false;
        Time.timeScale = 1;
        MainUI.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        audioManager.Play("Credits");
    }

    public void Nivel1()
    {
        Debug.Log("cal Nivel1");
        
        audioManager.Play("Nivel1");
        currentScene = 1;
        Time.timeScale = 1;
        SceneManager.LoadScene("Nivel1");
    }
    public void Nivel2()
    {
        Time.timeScale = 1;
        currentScene = 2;
        audioManager.Play("Nivel2");
        SceneManager.LoadScene("Nivel2");
    }
    public void Nivel3()
    {
        Time.timeScale = 1;
        currentScene = 3;
        audioManager.Play("Nivel3");
        SceneManager.LoadScene("Nivel3");
    }

    public void JuegoPelota()
    {
        Time.timeScale = 1;
        audioManager.Play("Pelota1");
        SceneManager.LoadScene("JuegoPelota");
    }

    public void NextLevel()
    {
        if (currentScene == 1)
            Nivel2();
        else if (currentScene == 2)
            Nivel3();
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene);
    }

    public void Quit()
    {
        Application.Quit();
    }




}
