using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectFalling : MonoBehaviour {


    AudioSource audio;
    public AudioClip[] screamClips;
    public AudioClip[] fallClips;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            //here he will scream
            audio.clip = screamClips[Random.Range(0, fallClips.Length-1)];
                audio.Play();
           
        }
        else
        {
            if (audio.isPlaying == false)
            {
                audio.clip = fallClips[Random.Range(0, fallClips.Length-1)];
                audio.Play();
            }
        }
    }
}
