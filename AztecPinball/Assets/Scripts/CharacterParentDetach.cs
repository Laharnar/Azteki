using UnityEngine;

public class CharacterParentDetach : MonoBehaviour {

        void Start()
    {
        Transform[] childObjects = gameObject.transform.GetComponentsInChildren<Transform>();



        foreach(Transform child in childObjects)
        {
            child.gameObject.transform.parent = null;
            Destroy(this.gameObject);
        }
    }
}
