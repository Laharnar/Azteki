using UnityEngine;

public class CharacterTorso : MonoBehaviour {

    public int torsoConnectors = 6;
    public Transform replacement;
    public void jointBreak()
    {
        torsoConnectors--;
        if (torsoConnectors == 0)
        {
            Instantiate(replacement, transform.position, transform.rotation);
            Destroy(gameObject);

            CallGameManager();
        }
    }


    public  void CallGameManager()
    {
        Debug.Log("YOU WON");
    }

    
}
