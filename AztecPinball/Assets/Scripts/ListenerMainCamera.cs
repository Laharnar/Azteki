using UnityEngine;

public class ListenerMainCamera : MonoBehaviour {

    int volume;
    AudioListener al;

    void Awake()
    {
        volume = PlayerPrefs.GetInt("listener");
        al = GetComponent<AudioListener>();


        if (volume == 0)
        {
            al.enabled = !enabled;
        }
    }
	
}
