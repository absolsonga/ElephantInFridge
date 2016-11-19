using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {
    
    public static SoundManager instance;

    public AudioClip audio1,audio2;
    AudioSource source;

    void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
	void Start () {
        source = GetComponent<AudioSource>();
	}

    public void PlaySound1()
    {
        source.PlayOneShot(audio1);
    }

    public void PlaySound2()
    {
        source.PlayOneShot(audio2);
    }
}
