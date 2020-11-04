using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopManager : MonoBehaviour
{

    float kücülme_hizi = 0.05f ;
    public GameObject panel;

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "delik" )
        {
            Destroy(GetComponent<Rigidbody>());
            transform.position = other.gameObject.transform.position;
            InvokeRepeating("topDusmesi", 0, 0.04f);

        }

        if (other.gameObject.name == "BitisNoktasi")
        {

            panel.SetActive(true);
            Time.timeScale = 0.0f;

        }
    
    
    }

    private void topDusmesi() {

        transform.localScale -= new Vector3(kücülme_hizi, kücülme_hizi, kücülme_hizi);
        if (transform.localScale.x <= 0.0f)
        {
            SceneManager.LoadScene("SampleScene");
        }


    }

}
