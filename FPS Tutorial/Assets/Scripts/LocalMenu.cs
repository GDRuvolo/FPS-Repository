using UnityEngine.SceneManagement;
using UnityEngine;

public class LocalMenu : MonoBehaviour {

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }


}
