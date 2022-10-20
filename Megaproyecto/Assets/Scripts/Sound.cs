using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    public float volume=1;
    public float pitch = 1;
        
    public bool loop=false;

    public AudioSource source;
}
