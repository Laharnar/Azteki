using UnityEngine;

public class MessageTrigger : MonoBehaviour {

    public GameObject message;
    private void OnEnable()
    {
        message.SetActive(true);
    }
}
