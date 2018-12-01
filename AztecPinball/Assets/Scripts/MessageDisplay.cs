using UnityEngine;
using UnityEngine.UI;

public class MessageDisplay : MonoBehaviour {


    public bool messagingIsRandom = false;
    int indexMessage = 0;
    public Messages scriptableMessages;
    public Text message;
    public AudioSource audi;
    public int disableMessageTime = 6;
    public GameObject disableCanvas;


    
    private void OnEnable()
    {
        audi.Play();
        
        
        //when enabled message gets shown for few seconds
        message = GetComponent<Text>();


        if (messagingIsRandom)
        {
            message.text = scriptableMessages.messageToDisplay[Random.Range(0,scriptableMessages.messageToDisplay.Length)];
            Invoke("DisableMessage", disableMessageTime);
        }
        else if (!messagingIsRandom)
        {
            message.text = scriptableMessages.messageToDisplay[indexMessage];
            Invoke("DisableMessage", disableMessageTime);
        }
         
    }

    void DisableMessage()
    {
       

        //if its random it shows random onew and index is not necesarry
        if (messagingIsRandom == false)
            //increments index for next message
            indexMessage++;
        {
            //sets index to 0 and messages will loop once again
            if (indexMessage == scriptableMessages.messageToDisplay.Length)
            {
                indexMessage = 0;
            }
        }


        //hides message and delets input,,, not necessary but to cover if bugs
        message.text = "";
        this.gameObject.SetActive(false);
        disableCanvas.SetActive(false);
    }

}
