using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZeminManager : MonoBehaviour
{

    float fullCan = 100.0f;
    float suankiCan = 100.0f;
    public Image canBari;
    public GameObject gameOverPanel;

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "elma")
        {

            Destroy(col.gameObject);

            suankiCan -= 10.0f;
            canBari.fillAmount = suankiCan / fullCan;

            if (suankiCan <= 0)
            {

                gameOverPanel.SetActive(true);
                Time.timeScale = 0;

            }


        }

    }

}
