using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoin : MonoBehaviour
{
    int coin = 0;
    [SerializeField] AudioSource GetCoins;
    [SerializeField] Text CoinTxt;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            coin++;
        }
    CoinTxt.text = "Coins: "+  coin;
    GetCoins.Play();
    }
}
