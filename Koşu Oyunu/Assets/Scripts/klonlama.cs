using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class klonlama : MonoBehaviour
{

    public GameObject tas, kutuk, jeep, altin, magnet;
    public Transform oyuncu;

    float silinme_zamani = 5.0f;

    float koordinat_x1 = -1.3f;
    float koordinat_x2 = 0.7f;
    float koordinat_x3 = 2.7f;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("nesne_klonla",0 , 0.5f);
        
    }

    void nesne_klonla()
    {

        int rastgele_deger = Random.Range(0, 100);

        if (rastgele_deger>0 && rastgele_deger<80)
        {

            klonla(altin, 0.8f);

        }

        if (rastgele_deger > 80 && rastgele_deger < 85)
        {

            klonla(kutuk, 0.1f);

        }

        if (rastgele_deger > 85 && rastgele_deger < 90)
        {

            klonla(tas, 0f);

        }

        if (rastgele_deger > 90 && rastgele_deger < 95)
        {

            klonla(jeep, 0.7f);

        }

        if (rastgele_deger > 95 && rastgele_deger < 100)
        {
            if (oyuncu.gameObject.GetComponent<oyuncu>().magnet_alindi == false)
            {

                klonla(magnet, 1.0f);

            }
            

        }
    } 
    

    void klonla(GameObject nesne,float yukseklik)
    {

        GameObject yeni_nesne = Instantiate(nesne);

        int rastsayi = Random.Range(0, 100);

        if (rastsayi>0 && rastsayi<33)
        {

            yeni_nesne.transform.position = new Vector3(koordinat_x1, yukseklik, oyuncu.position.z + 20.0f);

        }

        if (rastsayi > 33 && rastsayi < 67)
        {

            yeni_nesne.transform.position = new Vector3(koordinat_x2, yukseklik, oyuncu.position.z + 20.0f);

        }

        if (rastsayi > 67 && rastsayi < 100)
        {

            yeni_nesne.transform.position = new Vector3(koordinat_x3, yukseklik, oyuncu.position.z + 20.0f);

        }


        Destroy(yeni_nesne, silinme_zamani);
    }
}
