using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public AudioSource audio;
    public Animator anima;
    public string animationToPlay;

	public void AnimateObstacle()
    {
        
        anima.StopPlayback();
        anima.Play(animationToPlay);
        audio.Play();
    }
}
