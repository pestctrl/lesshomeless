using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMixer : MonoBehaviour
{
    public AudioSource AS;
    public AudioClip[] Clips = new AudioClip[1];
 
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    void PlayAudio()
    {
        int r = Random.Range(0, Clips.Length);
        AS.clip = Clips[r];
        AS.Play();
    }
}
