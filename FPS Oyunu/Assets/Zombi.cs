using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombi : MonoBehaviour
{

    NavMeshAgent zom;
    Animator anim;

    int can = 100;
    bool saldir = false;

    // Start is called before the first frame update
    void Start()
    {
        zom = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position);

        if (distance > 1.5f)
        {

            anim.SetTrigger("yuru");
            zom.destination = (GameObject.FindWithTag("Player").transform.position);
            saldir = false;
            CancelInvoke("canini_al");

        }
        else
        {

            anim.SetTrigger("saldir");

            if (saldir == false)
            {

                InvokeRepeating("canini_al", 0.0f, 2.0f);
                saldir = true;

            }

        }

    }

    public void zombi_can_azalt(int deger) {

        can -= deger;

        if (can <= 0)
        {

            anim.SetTrigger("ol");
            GetComponent<BoxCollider>().enabled = false;
            Destroy(zom);
            Destroy(this);

        }
    
    }

    void canini_al() {

        GameObject.FindWithTag("Player").GetComponent<Oyuncu>().oyuncu_can_azalt();
    
    }

}
