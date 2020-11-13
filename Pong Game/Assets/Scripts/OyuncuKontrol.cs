using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuKontrol : MonoBehaviour
{

    public bool isPlayer1;
    public float hiz;
    public Rigidbody2D rb;
    public Vector3 baslangicPozisyon;

    private float hareket;

    void Start()
    {

        baslangicPozisyon = transform.position;

    }


    // Update is called once per frame
    void Update()
    {

        if (isPlayer1)
        {

           hareket = Input.GetAxisRaw("Vertical");

        }
        else
        {

           hareket = Input.GetAxisRaw("Vertical2");

        }

        rb.velocity = new Vector2(0, hareket * hiz);

    }

    public void Reset()
    {

        rb.velocity = Vector2.zero;
        transform.position = baslangicPozisyon;

    }
}
