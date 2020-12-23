using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{   
    [Tooltip("Our Level Time in SECONDS")]
    [SerializeField] float levelTime = 10f;
    bool triggeredLevelFinished = false;

    void Update()
    {
        if (triggeredLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool timeIsFinished = (Time.timeSinceLevelLoad > levelTime);
        if (timeIsFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
