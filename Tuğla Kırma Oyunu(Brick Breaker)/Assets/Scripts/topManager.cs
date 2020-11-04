using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class topManager : MonoBehaviour
{

    public TextMeshProUGUI can_txt;
    public TextMeshProUGUI skor_txt;
    public TextMeshProUGUI tugla_txt;

    public Rigidbody topRigi;

    Vector3 baslangic_noktasi;

    GameObject[] tuglalar;

    float hiz = 7.0f;
    int toplam_tugla;
    int kirilan_tugla = 0;
    int skor = 0;
    int toplam_can = 3;


    // Start is called before the first frame update
    void Start()
    {

        tuglalar = GameObject.FindGameObjectsWithTag("tugla");
        toplam_tugla = tuglalar.Length;

        tugla_txt.text = toplam_tugla + "/" + kirilan_tugla;

        baslangic_noktasi = transform.position;

        baslangic_vurusu();

    }

    void baslangic_vurusu() {

        topRigi.velocity = Vector3.zero;
        transform.position = baslangic_noktasi;
        topRigi.velocity = new Vector3(hiz, 0, hiz);

    
    }

    void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == "tugla")
        {

            Destroy(collision.gameObject);
            skor += 100;
            kirilan_tugla++;

            skor_txt.text = "SKOR" + skor;
            tugla_txt.text = toplam_tugla + "/" + kirilan_tugla;

            if (kirilan_tugla == toplam_tugla)
            {
                Debug.Log("Tebrikler. Oyunu Kazandiniz...");
            }

        }

        if (collision.gameObject.name == "sol_duvar")
        {

            topRigi.velocity = new Vector3(hiz, 0, topRigi.velocity.z);

        }
        
        if (collision.gameObject.name == "sag_duvar")
        {

            topRigi.velocity = new Vector3(-hiz, 0, topRigi.velocity.z);

        } 
        
        if (collision.gameObject.name == "üst_duvar")
        {

            topRigi.velocity = new Vector3(topRigi.velocity.x, 0, -hiz);

        }
        
        if (collision.gameObject.name == "oyuncu")
        {

            topRigi.velocity = new Vector3(topRigi.velocity.x, 0, hiz);

        }
        
        if (collision.gameObject.name == "cikis")
        {

            toplam_can--;
            can_txt.text = toplam_can.ToString();

            if (toplam_can ==0)
            {
                SceneManager.LoadScene("Bolum1");
            }

            baslangic_vurusu();
        }
    
    }
}
