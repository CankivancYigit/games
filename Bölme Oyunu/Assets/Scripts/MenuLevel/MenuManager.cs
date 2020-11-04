using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startBtn, exitBtn;
    // Start is called before the first frame update
    void Start()
    {
        FadeOut();
    }
    
    void FadeOut() {

        
     }

    public void ExitGame() {
        Application.Quit();
    }

    public void StartGame() {

        SceneManager.LoadScene("GameLevel");
    }

}
