using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameplay : MonoBehaviour
{

    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;
    
    int guess;

    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {

        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();
      
    }

    // Update is called once per frame

    public void OnPressHigher()
    {

        min = guess + 1;
        NextGuess();

    }public void OnPressLower()
    {

        max = guess - 1;
        NextGuess();

    }
    void NextGuess()
    {
        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();

    }
}

