using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{

    [SerializeField]
    private Transform takip_edilen_kup;


    void LateUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, takip_edilen_kup.position, Time.deltaTime * 2.0f); 

    }
}
