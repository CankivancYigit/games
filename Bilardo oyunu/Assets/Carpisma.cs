using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpisma : MonoBehaviour
{

    public AudioSource ses_dosyasi;
    public AudioClip carpisma_sesi, sayi_sesi;

    GameManager yonetici;
    // Start is called before the first frame update
    void Start()
    {
        yonetici = GameObject.Find("Yonetici").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision nesne)
    {

        if (nesne.gameObject.tag == "delik" && gameObject.tag == "top")
        {

            yonetici.skorArttir();
            ses_dosyasi.PlayOneShot(sayi_sesi);
            Destroy(gameObject);

        }
        else if (nesne.gameObject.tag == "delik" && gameObject.tag == "Player")
        {

            ses_dosyasi.PlayOneShot(sayi_sesi);
            yonetici.beyazTopResetle();

        }

        if (nesne.gameObject.tag == "top")
        {

            ses_dosyasi.PlayOneShot(carpisma_sesi);

        }

    }
}
