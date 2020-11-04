using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    List<GameObject> toplar;
    public GameObject top;

    int kucuk_top_ilk_y_koordinati = -4;
    int level;

    public TMPro.TextMeshProUGUI level_txt;

    public GameObject tekrar_paneli;
    public GameObject gelecek_bolum_paneli;

    public Camera kamera;

    public bool kaybetmek=false;


    // Start is called before the first frame update
    void Start()
    {
        toplar = new List<GameObject>();

        seviye_kontrolu();
        kucuk_top_olustur();

    }

    void seviye_kontrolu() {

        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }
        else 
        {
            level = 1;
            PlayerPrefs.SetInt("level", level);
        }

        level_txt.text = level.ToString();

    }

    void kucuk_top_olustur() {

        int toplam_top = level * 2;

        for (int i = toplam_top; i > 0; i--)
        {
           
            GameObject yeni_top = Instantiate(top, new Vector2(0, kucuk_top_ilk_y_koordinati), Quaternion.identity);
            
            yeni_top.GetComponent<TopManager>().sayi_txt.text = i.ToString();
            
            toplar.Add(yeni_top);
           
            kucuk_top_ilk_y_koordinati--;
            
        }

    
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && toplar.Count > 0)
        {

            toplar[0].GetComponent<TopManager>().hareket_et = true;
            toplar.RemoveAt(0);

            foreach (GameObject top in toplar)
            {

                top.transform.position  -= new Vector3(0, -1, 0);

            }

        }

        if (toplar.Count == 0)
        {
            kamera.backgroundColor = Color.green;
            Invoke("sonraki_bolum", 0.5f);
        }

        if (kaybetmek == true) {

            kamera.backgroundColor = Color.red;
            CancelInvoke("sonraki_bolum");
            Invoke("bolum_tekrari", 0.5f);

        }

    }

    void sonraki_bolum()
    {

        gelecek_bolum_paneli.SetActive(true);
        Time.timeScale = 0.0f;
        level++;
        PlayerPrefs.SetInt("level", level);

    }

    void bolum_tekrari()
    {

        tekrar_paneli.SetActive(true);
        Time.timeScale = 0.0f;

    }

    public void tekrar_buton() {

        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
    
    }

    public void devam_buton()
    {

        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;

    }

    public void bastan_oyna()
    {
       
            PlayerPrefs.DeleteAll();
            level = 1;
            PlayerPrefs.SetInt("level", level);
            PlayerPrefs.GetInt("level");
        
            SceneManager.LoadScene("SampleScene");
            Time.timeScale = 1.0f;
  
    }
}
