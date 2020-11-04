using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{

    GameObject hayali_nesne;
    // Start is called before the first frame update
    void Start()
    {

        hayali_nesne = new GameObject();
        hayali_nesne.transform.position = GameObject.Find("BeyazTop").transform.position;
        transform.parent = hayali_nesne.transform;

    }

    // Update is called once per frame
    void Update()
    {

        hayali_nesne.transform.position = GameObject.Find("BeyazTop").transform.position;
        float yatay_ok_tuslari = Input.GetAxis("Horizontal");
        hayali_nesne.transform.eulerAngles = new Vector3(hayali_nesne.transform.eulerAngles.x, hayali_nesne.transform.eulerAngles.y+yatay_ok_tuslari, hayali_nesne.transform.eulerAngles.z);


    }
}
