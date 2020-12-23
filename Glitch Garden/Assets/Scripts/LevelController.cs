using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitToLoad = 4f;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);    
    }

    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void LoseConditionDisplay()
    {
        loseLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        Time.timeScale = 0;
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

}