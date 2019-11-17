using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [HideInInspector]
    public SoundManager item;
    public Sound[] sounds;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (item == null)
        {
            item = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.music;
            s.source.playOnAwake = false;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }
    public void Play(string name)
    {
        Sound found = Array.Find(sounds, sound => sound.name == name);
        if (found != null)
        {
            found.source.Play();
        }
    }
    public void Stop(string name)
    {
        Sound found = Array.Find(sounds, sound => sound.name == name);
        if (found != null)
        {
            found.source.Stop();
        }
    }
}
