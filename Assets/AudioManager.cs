using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicAudioSource;

    public AudioClip musicClip;

    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.Play();
    }
   
}
