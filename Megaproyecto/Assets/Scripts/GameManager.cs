using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject PauseMenu;
    public Slider audioSlider;

    private string currentScene;
    private bool paused;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && currentScene != "MainMenu")
        {
            if (!paused)
            {
                canvas.SetActive(true);
                PauseMenu.SetActive(true);
                Time.timeScale = 0;
                paused = true;
            }
            else
            {
                canvas.SetActive(false);
                paused = false;
                Time.timeScale = 1;

            }
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = audioSlider.value;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        currentScene = "MainMenu";
    }

    public void Nivel1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Nivel1");
        currentScene = "Nivel1";
    }
    public void Nivel2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Nivel2");
        currentScene = "Nivel2";
    }
    public void Nivel3()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Nivel3");
        currentScene = "Nivel3";
    }

    public void JuegoPelota()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("JuegoPelota");
        currentScene = "JuegoPelota";
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene);
    }




}
