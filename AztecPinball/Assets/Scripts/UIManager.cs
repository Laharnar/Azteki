using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    //Main camera must have ListenerMainCamera attached to check if it has to turn off sound

    public Button soundBtn;
    public GameObject tutorialCanvas;
    bool toggleActivator;


    private void Start()
    {
        bool toggleActivator = false;
        //if listener is 1 this means that sound is on...otherwise the sound is off
        if (PlayerPrefs.GetInt("listener") == 1)
        {
            soundBtn.image.color = Color.white;
        }
        else if (PlayerPrefs.GetInt("listener") == 0)
        {
            soundBtn.image.color = Color.red;
        }

    }

    public void SceneLoader(string SceneToLoad)
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void ExitToMainMenu(string mainMenu)
    {
        SceneManager.LoadScene(mainMenu);
    }
    public void SoundDisabler()
    {


        if(PlayerPrefs.GetInt("listener") == 1)
        {
            PlayerPrefs.SetInt("listener", 0);
            soundBtn.image.color = Color.red;


            Debug.Log(PlayerPrefs.GetInt("listener"));
        }
        else
        {
            PlayerPrefs.SetInt("listener", 1);
            soundBtn.image.color = Color.white;


            Debug.Log(PlayerPrefs.GetInt("listener"));
        }
       
    }

    public void TutorialEnabler()
    {
        toggleActivator = !toggleActivator;
        tutorialCanvas.SetActive(toggleActivator);
    }

}
