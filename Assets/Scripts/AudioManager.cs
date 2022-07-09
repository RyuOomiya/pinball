using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audio;
    public AudioClip sound01;
    void Start()
    {
        _audio = gameObject.AddComponent<AudioSource>();
        
    }

    private void OnCollisionEnter(Collision other)
    {


        _audio.PlayOneShot(sound01, 0.5f);
        
        
    }
}