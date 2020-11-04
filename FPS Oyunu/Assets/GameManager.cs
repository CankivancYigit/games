using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI zaman_txt;
    int saniye = 300;
    public GameObject zombi;
    GameObject[] dogma_noktalari;

    // Start is called before the first frame update
    void Start()
    {

        dogma_noktalari = GameObject.FindGameObjectsWithTag("dogma_noktasi");
        InvokeRepeating("saniye_azalt", 0.0f, 1.0f);
        InvokeRepeating("zombi_olustur", 0.0f, 5.0f);

    }

    void saniye_azalt() {

        saniye--;
        zaman_txt.text = saniye.ToString();

        if (saniye <= 0)
        {

            Debug.Log("Twbrikler. Oyunu kazandiniz...");

        }
    
    }

    void zombi_olustur() {

        int rast = Random.Range(0, dogma_noktalari.Length);

        GameObject yeni_zombi = Instantiate(zombi, dogma_noktalari[rast].transform.position, Quaternion.identity);
    
    }
}
