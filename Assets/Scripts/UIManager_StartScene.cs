using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager_StartScene : MonoBehaviour
{
   
    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void ONQuitButtonPressed()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
}
