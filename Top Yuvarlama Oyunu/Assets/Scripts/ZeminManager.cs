using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeminManager : MonoBehaviour
{
    float hiz = 35.0f;
    float yatay_hareket, dikey_hareket;


    // Update is called once per frame
    void Update()
    {

        yatay_hareket = Input.GetAxis("Mouse X") * Time.deltaTime * -hiz;
        dikey_hareket = Input.GetAxis("Mouse Y") * Time.deltaTime * hiz;

        transform.eulerAngles += new Vector3(dikey_hareket, 0 , yatay_hareket);

    }
}
