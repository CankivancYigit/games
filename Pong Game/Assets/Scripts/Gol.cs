using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gol : MonoBehaviour
{

    public bool isPlayer1Goal;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Ball")
        {

            if (isPlayer1Goal)
            {

                Debug.Log("Player2 Gol Atti");
                GameObject.Find("GameManager").GetComponent<GameManager>().Player2Scored();

            }
            else
            {

                Debug.Log("Player1 Gol Atti");
                GameObject.Find("GameManager").GetComponent<GameManager>().Player1Scored();

            }

        }

    }
}
