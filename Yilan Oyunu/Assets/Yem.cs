using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yem : MonoBehaviour
{

    public GameObject tavuk, domates, steak, peynir;
    float zaman = 5.0f ;
    // Start is called before the first frame update
   
    void Start()
    {

        InvokeRepeating("yemOlustur", 0, 5.0f); //5 saniyede bir yem olusturmak icin kullanılan metod


    }

    public void yemOlustur()
    {

        int rand = Random.Range(0, 100);
        float x = Random.Range(-3.2f, 3.7f);
        float z = Random.Range(-6.4f, -3f);

        Vector3 koordinat = new Vector3(x, 0.2f , z);

        if (rand<30)
        {
            GameObject yem = Instantiate(domates,koordinat,Quaternion.identity);    
            Destroy(yem, 5.0f);
        }if (30<=rand && rand<60)
        {
            GameObject yem = Instantiate(peynir,koordinat,Quaternion.identity);
            Destroy(yem, 5.0f);
        }
        if (60 <= rand && rand < 90)
        {
            GameObject yem = Instantiate(tavuk,koordinat,Quaternion.identity);
            Destroy(yem, 5.0f);
        }
        if (90 <= rand && rand <= 100)
        {
            GameObject yem = Instantiate(steak,koordinat,Quaternion.identity);
            Destroy(yem, 5.0f);
        }


    }
    
}
