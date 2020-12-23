using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 2f;

    public static void SetMasterVolume(float volume)
    {
        if (volume <= MAX_VOLUME && volume >= MIN_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            //Debug.LogError("No Volume");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    } 

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty <= MAX_DIFFICULTY && difficulty >= MIN_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            //Debug.LogError("No dif");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
