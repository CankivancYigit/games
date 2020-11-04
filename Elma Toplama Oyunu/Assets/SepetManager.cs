using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SepetManager : MonoBehaviour
{
    public float speed;
    int score = 0;
    public TextMeshProUGUI scoreTxt;
    public ParticleSystem efekt;

    public AudioSource sesEfekti;
    public AudioClip sepetSesi;


    private void start() {

        efekt.Stop();

    }

    void OnCollisionEnter(Collision col) {

        if (col.gameObject.tag=="elma")
        {

            sesEfekti.PlayOneShot(sepetSesi);
            efekt.Play();
            score += 10;
            scoreTxt.text = score.ToString();
            Destroy(col.gameObject);

        }
    
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
    }
}
