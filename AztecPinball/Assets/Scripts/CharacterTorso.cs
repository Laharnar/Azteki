using UnityEngine;

public class CharacterTorso : MonoBehaviour {


    public int torsoConnectors = 6;

    public void jointBreak()
    {
        torsoConnectors--;
        if (torsoConnectors == 0)
        {
            CallGameManager();
        }
    }


    public  void CallGameManager()
    {
        Debug.Log("YOU WON");
    }

    
}
