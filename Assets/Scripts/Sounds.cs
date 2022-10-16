using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private static Sounds _instance;

    public static Sounds Instance
    {
        get
        {
            return _instance;
        }
    }

    public AudioSource audioSource;

    public List<AudioClip> clips;

    void Awake()
    {
        _instance = this;
    }

    public void Play(string key)
    {
        var clip = clips.FirstOrDefault(c => c.name.Contains(key));
        audioSource.PlayOneShot(clip);
    }
    
}
