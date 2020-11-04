using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YemCarpismaKontrol : MonoBehaviour
{

    Yem yem;
    // Start is called before the first frame update
    void Start()
     {
         yem = GameObject.Find("YemOlustur").GetComponent<Yem>();
        
    } 

    private void OnTriggerEnter(Collider nesne)
    {
        
        if (nesne.gameObject.tag == "Player")
        {
      
            Destroy(this.gameObject);
            yem.CancelInvoke();
            yem.InvokeRepeating("yemOlustur", 0, 5.0f);
            //yem 5 saniyeden önce yenirse yem scriptindeki invoke metodunu iptal edip tekrar cagirarak o anda baska bir yemin olusmasini saglariz.
        }
        if (nesne.gameObject.tag == "kuyruk")
        {

            Destroy(this.gameObject);
            yem.CancelInvoke();
            yem.InvokeRepeating("yemOlustur", 0, 5.0f);
            //eğer yeni oluşan yem yilanin kuyrugunun uzerinde olusursa o yemi destroy edip yem scriptindeki invoke metodunu iptal edip tekrar cagirarak o anda baska bir yemin olusmasini saglariz.

        }

    }

}
