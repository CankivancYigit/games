using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bitti_panel : MonoBehaviour
{
   public void evet_btn()
    {

        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SampleScene");

    }

    public void hayir_btn()
    {

        Application.Quit();

    }
}
