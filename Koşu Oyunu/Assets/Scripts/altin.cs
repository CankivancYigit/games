using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altin : MonoBehaviour
{
    oyuncu cocuk;
    Transform temas_kupu;

    float mesafe;

    // Start is called before the first frame update
    void Start()
    {

        cocuk = GameObject.Find("cocuk").GetComponent<oyuncu>();
        temas_kupu = GameObject.Find("temas_kupu").transform;

    }

    // Update is called once per frame
    void Update()
    {

        if (cocuk.magnet_alindi == true)
        {

            mesafe = Vector3.Distance(transform.position, temas_kupu.position);

            if (mesafe <= 10.0f)
            {

                transform.position = Vector3.MoveTowards(transform.position, temas_kupu.position, Time.deltaTime * 10.0f);

            }

        }

    }
}
