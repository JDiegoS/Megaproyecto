using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public string playingBackground;
    public int currentScene=0;
    public int currentVideo=0;
    public bool wonPelota = false;

    public float volume = 1;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(gameObject.name);
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if(instance != this) {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        Play("Credits");


    }

    public void Play(string name)
    {
        Sound s =  Array.Find(sounds, sound => sound.name == name);
        if (s == null || s.source == null)
            return;
        if (name == "Nivel1" || name == "Nivel2" || name == "Nivel3" || name == "Pelota1" || name == "Credits")
        {
            if (playingBackground == "Nivel1" || playingBackground == "Nivel2" || playingBackground == "Nivel3" || playingBackground == "Pelota1" || playingBackground == "Credits")
            {
                Sound b = Array.Find(sounds, sound => sound.name == playingBackground);
                b.source.Stop();

            }
            playingBackground = name;
        }
        s.source.Play();

    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null || s.source == null)
            return;
        
        s.source.Stop();

    }

    public void ChangeVolume(float value)
    {
        volume = value;
        foreach (Sound s in sounds)
        {
            s.source.volume = value;
        }
    }
}
