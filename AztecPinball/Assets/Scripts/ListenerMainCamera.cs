using UnityEngine;

public class ListenerMainCamera : MonoBehaviour {

    int volume;
    AudioListener al;
    AudioSource audio;
    public AudioClip[] levelMusic;

    void Awake()
    {
        volume = PlayerPrefs.GetInt("listener");
        al = GetComponent<AudioListener>();


        if (volume == 0)
        {
            al.enabled = !enabled;
        }
    }
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = levelMusic[Random.Range(0, levelMusic.Length)];
        audio.Play();
    }

}
