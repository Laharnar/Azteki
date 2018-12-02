using UnityEngine;

public class JointDetacher : MonoBehaviour
{

    public int hitPoints = 100;
    public bool attachedToTorso;
    int counter;
    public CharacterTorso ct;
    bool enabledJoint = true;
    private void Update()
    {
        
    }

    void BreakJoints()
    {
        enabledJoint = false;
        HingeJoint hinge = GetComponent<HingeJoint>();
        if (hinge)
        hinge.connectedBody = null;
        if (attachedToTorso)
        {
            ct.jointBreak();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "stairs")
        {
            hitPoints--;
        }
        if (collision.gameObject.tag == "obstacle")
        {
            hitPoints -= 5;
        }
        if (hitPoints < 0 && enabledJoint )
        {
            //tuki lahko daš kak particle effect tudi ali sound 
            BreakJoints();

           
        }


    }
}

