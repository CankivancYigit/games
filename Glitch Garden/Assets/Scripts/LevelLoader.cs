using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int waitingTime = 4;
    private int currentSceneIndex;
    void Start(){
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForLoad());
        }
        
    }
    private IEnumerator WaitForLoad()
    {
        yield return new WaitForSeconds(waitingTime);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadYouLoseScreen()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void LoadStartScreen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
