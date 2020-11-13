using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopHareket : MonoBehaviour
{

    public float hiz;
    public Rigidbody2D rb;
    public Vector3 baslangicPozisyon;

    // Start is called before the first frame update
    void Start()
    {

        Launch();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Launch()
    {

        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector2(hiz * x, hiz * y);
    }

    public void Reset()
    {

        rb.velocity = Vector2.zero;
        transform.position = baslangicPozisyon;
        Launch();

    }
}
