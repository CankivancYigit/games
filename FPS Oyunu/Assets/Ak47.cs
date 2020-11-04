using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ak47 : MonoBehaviour
{
    AudioSource silah_sesi;
    Animator silah_anim;
    Camera kamera;

    public GameObject kan_efekti;
    public GameObject ates_efekti;

    public TextMeshProUGUI kursun_txt;

    float ates_etme_araligi = 0.1f;
    float ates_etme_zamani= 0.0f;

    int sarjordeki_kursun = 30;
    int toplam_kursun = 240;


    // Start is called before the first frame update
    void Start()
    {

        silah_sesi = GetComponent<AudioSource>();
        silah_anim = GetComponent<Animator>();
        kamera = GameObject.Find("Gun Camera").GetComponent<Camera>();

        kalan_kursunlari_goster();
    }

    // Update is called once per frame
    void Update()
    {

        silah_animasyonlari();

        if (Input.GetKeyDown(KeyCode.R))
        {

            if (toplam_kursun>0)
            {

                sarjor_degistir();

            }

        }

        if (Input.GetMouseButton(0))
        {

            if (Time.time >= ates_etme_zamani)
            {

                if (sarjordeki_kursun > 0)
                {

                    ates();
                    ates_etme_zamani = Time.time + ates_etme_araligi;
                }
                else
                {

                    ates_kes();

                }

            }

        }

        if (Input.GetMouseButtonUp(0))
        {

            ates_kes();

        }

    }

    void kalan_kursunlari_goster() {

        kursun_txt.text = sarjordeki_kursun + "/" + toplam_kursun;
    
    }

    void silah_animasyonlari() {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {

            silah_anim.SetBool("Run", true);

        }
        else
        {

            silah_anim.SetBool("Run", false);

        }
    
    }

    void sarjor_degistir() {

        silah_anim.SetTrigger("Reload");
        sarjordeki_kursun = 30;
        toplam_kursun -= 30;

        kalan_kursunlari_goster();
    
    }

    void ates() {

        sarjordeki_kursun--;
        kalan_kursunlari_goster();

        

            silah_sesi.Play();
            ates_efekti.SetActive(true);
            silah_anim.SetBool("Shoot", true);

        
        

        Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.gameObject.tag == "dusman")
            {

                hit.collider.gameObject.GetComponent<Zombi>().zombi_can_azalt(20);
                GameObject yeni_kan_efekti = Instantiate(kan_efekti, hit.point, Quaternion.identity);
                Destroy(yeni_kan_efekti, 0.5f);

            }

        }


    }

    void ates_kes() {

        silah_anim.SetBool("Shoot", false);
        silah_sesi.Stop();
        ates_efekti.SetActive(false);
    
    }

}
