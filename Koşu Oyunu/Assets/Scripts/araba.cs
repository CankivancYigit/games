using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class araba : MonoBehaviour
{
    float hiz = 5.0f;

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, 0, hiz * Time.deltaTime);

    }
}
