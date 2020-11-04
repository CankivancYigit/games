using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncuManager : MonoBehaviour
{
    public Rigidbody oyuncuRigi;
    float hiz=10.0f;
    float yon_tusu;
  

    // Update is called once per frame
    void FixedUpdate()
    {

        yon_tusu = Input.GetAxis("Horizontal");
        oyuncuRigi.velocity = (Vector3.right * hiz) * yon_tusu;

    }
}
