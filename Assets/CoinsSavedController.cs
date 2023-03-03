using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsSavedController : MonoBehaviour
{
    public Text coinsLabel;

    void Start(){
        showCoins();
    }

    public void addCoinsAmount(int amount){
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + amount);

        showCoins();
    }

    public void showCoins(){
        coinsLabel.text = PlayerPrefs.GetInt("coins").ToString();
    }
}
