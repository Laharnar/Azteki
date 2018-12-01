using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    //Main camera must have ListenerMainCamera attached to check if it has to turn off sound


    private void Start()
    {
        //if listener is 1 this means that sound is on...
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
            Debug.Log(PlayerPrefs.GetInt("listener"));
        }
        else
        {
            PlayerPrefs.SetInt("listener", 1);
            Debug.Log(PlayerPrefs.GetInt("listener"));
        }
       
    }
}
