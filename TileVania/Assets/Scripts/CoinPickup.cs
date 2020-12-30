using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinTakeSFX;
    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource.PlayClipAtPoint(coinTakeSFX, Camera.main.transform.position);
        Destroy(gameObject);    
    }
}
