using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KureManager : MonoBehaviour
{

    float donme_hizi;

    // Start is called before the first frame update
    void Start()
    {
        donme_hizi = 35;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, donme_hizi*Time.deltaTime);  
    }
}
