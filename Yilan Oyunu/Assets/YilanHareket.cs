using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YilanHareket : MonoBehaviour
{
    public GameObject kuyruk;

    List<GameObject> yilanKuyruk;
    Vector3 eskiPozisyon;
    GameObject cikarilanKuyruk;

    public TextMeshProUGUI skorTxt;
    int skor = 0;
    float hiz = 20.0f;

    // Start is called before the first frame update
    void Start()
    {

        yilanKuyruk = new List<GameObject>();

        for (int i = 0; i <= 5; i++)
        {

            GameObject yeniKuyruk = Instantiate(kuyruk, eskiPozisyon, Quaternion.identity);
            yilanKuyruk.Add(yeniKuyruk);

        }
        InvokeRepeating("hareketEt", 0, 0.1f);
    }

    void hareketEt()
    {

        eskiPozisyon = transform.position;
        transform.Translate(0, 0, hiz * Time.deltaTime);

        if (yilanKuyruk.Count > 0)
        {

            yilanKuyruk[0].transform.position = eskiPozisyon;

            cikarilanKuyruk = yilanKuyruk[0];
            yilanKuyruk.RemoveAt(0);
            yilanKuyruk.Add(cikarilanKuyruk);

        }


    }

    private void OnTriggerEnter(Collider nesne)
    {

        if (nesne.gameObject.tag == "duvar" /*|| nesne.gameObject.tag == "kuyruk"*/) //kuyruga degmeyi aktif edince oyun direk resetleniyor.
        {

            Destroy(this.gameObject);
            SceneManager.LoadScene("SampleScene");

        }

        if (nesne.gameObject.tag == "yem")
        {

            skor += 100;
            skorTxt.text = "score :" + skor;
            GameObject yeniKuyruk = Instantiate(kuyruk, eskiPozisyon, Quaternion.identity);
            yilanKuyruk.Add(yeniKuyruk);

        }

        if (nesne.gameObject.tag == "steak")
        {

           skor += 200;
            skorTxt.text = "score :" + skor;
            GameObject yeniKuyruk = Instantiate(kuyruk, eskiPozisyon, Quaternion.identity);
            yilanKuyruk.Add(yeniKuyruk);

        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {

            transform.Rotate(0, 90, 0);

        }
        if (Input.GetKeyDown(KeyCode.A))
        {

            transform.Rotate(0, -90, 0);

        }

    }
}
