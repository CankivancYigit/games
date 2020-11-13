using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [Header("Ball")]
    public GameObject top;

    [Header("Player1")]
    public GameObject player1Hareket;
    public GameObject player1Goal;
    
    [Header("Player2")]
    public GameObject player2Hareket;
    public GameObject player2Goal;

    [Header("Score UI")]
    public TextMeshProUGUI player1Text; 
    public TextMeshProUGUI player2Text;

    private int player1Score, player2Score;

    public void Player1Scored()
    {

        player1Score++;
        player1Text.text = player1Score.ToString();
        ResetPozisyon();

    } 
    
    public void Player2Scored()
    {

        player2Score++;
        player2Text.text = player2Score.ToString();
        ResetPozisyon();

    }
    
    private void ResetPozisyon()
    {

        top.GetComponent<TopHareket>().Reset();
        player1Hareket.GetComponent<OyuncuKontrol>().Reset();
        player2Hareket.GetComponent<OyuncuKontrol>().Reset();

    }

}
