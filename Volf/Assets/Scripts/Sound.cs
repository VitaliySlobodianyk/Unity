using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip music;
    [Range(0,1)]
    public float volume;
    [Range(1, 3)]
    public float pitch;
    public bool loop;
    [HideInInspector]
    public bool isPlayng;
    [HideInInspector]
    public AudioSource source;
}
