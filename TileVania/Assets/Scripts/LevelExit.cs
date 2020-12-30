using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{   
    [SerializeField] ParticleSystem levelFinishEffect;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        levelFinishEffect.Play();
        yield return new WaitForSecondsRealtime(2f);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
