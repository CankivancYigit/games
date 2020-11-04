using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class oyuncu : MonoBehaviour
{
     
    public Animator cocuk_anim;
    public GameObject toz_efekti, altin_efekti;

    public TextMeshProUGUI puan_txt, toplanan_altin_txt;

    public Transform yol1, yol2;

    public Rigidbody rigi;

    bool sag = true;

    int puan = 0;
    int toplanan_altin = 0;

    public bool magnet_alindi = false;

    public AudioSource kosma_sesi, ses_dosyasi;
    public AudioClip altin_temas_sesi;

    public GameObject bitti_pnl;

    float koordinat_x1 = -1.3f;
    float koordinat_x2 = 0.7f;
    float koordinat_x3 = 2.7f;


    // Update is called once per frame
    void Update()
    {

        hareket();

    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "duvar_1")
        {

            yol2.position = new Vector3(yol1.position.x, yol1.position.y, yol1.position.z + 39.6f);

        }

        if (other.gameObject.name == "duvar_2")
        {

            yol1.position = new Vector3(yol2.position.x, yol2.position.y, yol2.position.z + 39.6f);

        }

        if (other.gameObject.tag == "engel")
        {

            bitti_pnl.SetActive(true);
            Time.timeScale = 0.0f;
            Destroy(this);
            Destroy(kosma_sesi);
        }

        if (other.gameObject.tag == "altin")
        {

            ses_dosyasi.PlayOneShot(altin_temas_sesi);
            GameObject yeni_altin_efekti = Instantiate(altin_efekti, other.gameObject.transform.position, Quaternion.identity);
            Destroy(yeni_altin_efekti, 0.5f);

            Destroy(other.gameObject);

            toplanan_altin++;
            puan += 5;

            puan_txt.text = puan.ToString("000");
            toplanan_altin_txt.text = toplanan_altin.ToString();

        }

        if (other.gameObject.tag == "magnet")
        {

            GameObject[] tum_magnetler = GameObject.FindGameObjectsWithTag("magnet");

            foreach (var magnet in tum_magnetler)
            {

                Destroy(magnet);

            }

            magnet_alindi = true;
            Invoke("magnet_resetle", 10.0f);

        }

    }

    void magnet_resetle()
    {

        magnet_alindi = false;

    }


    void OnCollisionStay(Collision collision)
    {

        toz_efekti.SetActive(true);
        kosma_sesi.enabled = true;

    }

    void OnCollisionExit(Collision collision)
    {

        toz_efekti.SetActive(false);
        kosma_sesi.enabled = false;

    }

    void hareket()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {

            cocuk_anim.SetBool("zipla", true);
            rigi.velocity = Vector3.up * 650.0f * Time.deltaTime;
            Invoke("ziplama_iptal", 0.5f);

        }

        if (Input.GetKeyDown(KeyCode.D))
        {

            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), 3.0f);

            if (transform.position.x > koordinat_x3)
            {

                transform.position = Vector3.Lerp(transform.position, new Vector3(koordinat_x3, transform.position.y, transform.position.z), 3.0f);

            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {

            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - 2, transform.position.y, transform.position.z), 3.0f);

            if (transform.position.x < koordinat_x1)
            {

                transform.position = Vector3.Lerp(transform.position, new Vector3(koordinat_x1, transform.position.y, transform.position.z), 3.0f);

            }

        }


        transform.Translate(0, 0, 5 * Time.deltaTime);

    }

    void ziplama_iptal()
    {

        cocuk_anim.SetBool("ziplama", false);
        rigi.velocity = Vector3.down * 800.0f * Time.deltaTime;

    }

}
