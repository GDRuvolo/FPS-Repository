using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public void OnClickLocal()
    {
        //Load offline local play scene
        SceneManager.LoadScene("LocalPlayMenu", LoadSceneMode.Single);
    }

    public void OnClickOnline()
    {
        //Load Online Login Menu scene
        SceneManager.LoadScene("LoginMenu", LoadSceneMode.Single);
    }

    public void OnClickExitApp()
    {
        Application.Quit();
    }

}
