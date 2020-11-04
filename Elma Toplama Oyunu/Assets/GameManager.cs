using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject elma;
    bool oyunDurduruldu;



    void Start()
    {

        InvokeRepeating("elmaOlustur", 0.0f, 0.9f);


    }


    void elmaOlustur() {


        float rand = Random.Range(-1, 11.4f);

        
       
       GameObject yeniElma = Instantiate(elma, new Vector3(rand, 10, -6.83f),Quaternion.identity);


    }

    public void pauseBtn()
    {

        oyunDurduruldu = !oyunDurduruldu;

        if (oyunDurduruldu==true)
        {

            Time.timeScale = 0.0f;

        }
        else
        {
            Time.timeScale = 1.0f;
        }

    }

    public void oyunuTekrarBaslat()
    {

        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1.0f;


    }

}
