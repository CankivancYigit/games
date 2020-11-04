using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Oyuncu : MonoBehaviour
{
    // Start is called before the first frame update
    int su_anki_can = 100;
    public TextMeshProUGUI can_txt;

    public void oyuncu_can_azalt() 
    {
        su_anki_can -= 2;
        can_txt.text = "%" + su_anki_can.ToString();

        if (su_anki_can <= 0)
        {

            Debug.Log("Oyunu Kaybettiniz");

        }
    
    }
}
