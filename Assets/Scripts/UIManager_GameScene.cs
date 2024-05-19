using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager_GameScene : MonoBehaviour
{
    public GameObject[] gameSceneUI;  //0 - pausebutton, 1 - pause panel
    void Start()
    {
        gameSceneUI[0].SetActive(true);
        gameSceneUI[1].SetActive(false);
    }
    public void OnPauseButtonPressed()
    {
        Debug.Log("Pause");
        gameSceneUI[0].SetActive(false);
        gameSceneUI[1].SetActive(true);
        Time.timeScale = 0;      
    }
    public void OnResumeButtonPressed()
    {
        Time.timeScale = 1;
        gameSceneUI[0].SetActive(true);
        gameSceneUI[1].SetActive(false);
    }

    public void OnRestartButtonPressed()
    {
        SceneManager.LoadScene(1);
        gameSceneUI[0].SetActive(true);
        gameSceneUI[1].SetActive(false);
    }

    public void ONQuitButtonPressed()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
}
