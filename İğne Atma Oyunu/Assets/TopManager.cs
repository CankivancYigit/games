using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopManager : MonoBehaviour
{

    public bool hareket_et = false;

    public LineRenderer cizgi;

    Transform kure;

    float hiz = 20.0f;

    public TMPro.TextMeshProUGUI sayi_txt;

    GameManager game_manager;

    public CircleCollider2D carpisma_denetleyici;

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "top")
        {
            game_manager.kaybetmek = true;
        }
    
    }

    // Start is called before the first frame update
    void Start()
    {

        kure = GameObject.Find("Kure").transform;
        game_manager = GameObject.Find("GameManager").GetComponent<GameManager>();
           

    }

    // Update is called once per frame
    void Update()
    {

        if (hareket_et == true)
        {

            transform.Translate(0, hiz * Time.deltaTime, 0);
            carpisma_denetleyici.enabled = true;

        }

        float mesafe = Vector3.Distance(transform.position, kure.position);
        
        if (mesafe <= 2.0f)
        {

            hareket_et = false;

            cizgi.SetPosition(0, new Vector3(0, 2, 0));

            transform.parent = kure.transform;

        }

    }
}
