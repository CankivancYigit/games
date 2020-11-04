using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public LineRenderer cizgi;
    public Camera kamera;

    public Transform beyaz_top;
    public Rigidbody beyaz_top_guc;
    public Transform cubuk;

    public AudioSource ses_dosyasi;
    public AudioClip carpisma_sesi, sayi_sesi;

    float vurus_hizi=0.0f;

    Vector3 cubugun_baslangic_koordinati;
    Vector3 beyaz_top_baslangic_koordinati;

    int oyuncu1_skor = 0;
    int oyuncu2_skor = 0;

    public bool oyuncu_degistir = false; //false ise 1. oyuncu true ise 2.oyuncu oynar.

    public TextMeshProUGUI oyuncu_txt;
    public TextMeshProUGUI oyuncu_skor_txt;
    public TextMeshProUGUI kazanan_txt;

    // Start is called before the first frame update
    void Start()
    {

        beyaz_top_baslangic_koordinati = beyaz_top.position;
        cubugun_baslangic_koordinati = cubuk.localPosition;

    }

    // Update is called once per frame
    void Update()
    {

        cizgiAyari();
        fareKontrol();
        gorunurluk();

    }


    void cizgiAyari()
    {

        RaycastHit isik_temas;
        Ray isik = kamera.ScreenPointToRay(Input.mousePosition); //mouse pozisyonunda isik olusturmak icin 

        if (Physics.Raycast(isik,out isik_temas))
        {

            Vector3 beyaz_top_pozisyon = beyaz_top.position;
            Vector3 mouse_temas_pozisyon = new Vector3(isik_temas.point.x, isik_temas.point.y, isik_temas.point.z);

            cizgi.SetPosition(0, beyaz_top_pozisyon);
            cizgi.SetPosition(1, mouse_temas_pozisyon);

            beyaz_top.LookAt(mouse_temas_pozisyon);

        }
    }

    void fareKontrol()
    {

        if (Input.GetMouseButton(0) && cizgi.gameObject.activeSelf)
        {

            if (cubuk.localPosition.z >= -30.0f)
            {

                cubuk.Translate(0, 0, 2.0f * Time.deltaTime);
                vurus_hizi += 5.0f * Time.deltaTime;

            }

        }

        if (Input.GetMouseButtonUp(0) && cizgi.gameObject.activeSelf)
        {

            cubuk.localPosition = cubugun_baslangic_koordinati;
            Invoke("vur", 0.1f);

        }
    }

    void vur()
    {

        ses_dosyasi.PlayOneShot(carpisma_sesi);
        beyaz_top_guc.velocity = beyaz_top.forward * vurus_hizi;

        cizgi.gameObject.SetActive(false);
        cubuk.gameObject.SetActive(false);

        oyuncu_degistir = !oyuncu_degistir;
    }

    void gorunurluk()
    {

        if (beyaz_top_guc.velocity.magnitude<0.1f && cizgi.gameObject.activeSelf == false)
        {

            cizgi.gameObject.SetActive(true);
            cubuk.gameObject.SetActive(true);

            if (oyuncu_degistir == false)
            {

                oyuncu_txt.text = "1.OYUNCU";

            }
            else
            {
                oyuncu_txt.text = "2.OYUNCU";
            }

        }

    }

    public void skorArttir()
    {


        oyuncu_degistir = !oyuncu_degistir;
        if (oyuncu_degistir)
        {

            oyuncu2_skor++;
            if (oyuncu2_skor == 8)
            {

                oyunuBitir("2.OYUNCU KAZANDI");

            }

        }
        else if (oyuncu_degistir == false)
        {

            oyuncu1_skor++;
            if (oyuncu1_skor == 8)
            {

                oyunuBitir("1.OYUNCU KAZANDI");

            }

        }
        oyuncu_skor_txt.text = "1. Oyuncu : " + oyuncu1_skor + "" + "\n2.Oyuncu : " + oyuncu2_skor;
        

    }

    void oyunuBitir(string deger)
    {

        kazanan_txt.gameObject.transform.parent.gameObject.SetActive(true);
        kazanan_txt.text = deger;
        Invoke("tekrarOyna", 5.0f);

    }

    void tekrarOyna()
    {

        SceneManager.LoadScene("SampleScene");

    }

    public void beyazTopResetle()
    {

        
        beyaz_top_guc.velocity = Vector3.zero;
        beyaz_top.position = beyaz_top_baslangic_koordinati;
        
    }

}
