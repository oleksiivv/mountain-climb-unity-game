using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsController : MonoBehaviour
{
    public GameObject[] skinRedDragon, skinGhost;

    public GameObject emma, astronaut;

    void Start(){
        foreach(var part in skinGhost) part.SetActive(PlayerPrefs.GetInt("currentSkin", 0) == 1);

        foreach(var part in skinRedDragon) part.SetActive(PlayerPrefs.GetInt("currentSkin", 0) == 2);

        if (PlayerPrefs.GetInt("currentSkin", 0) == 3){
            astronaut.SetActive(true);
            emma.SetActive(false);
        } else {
            astronaut.SetActive(false);
            emma.SetActive(true);
        }
    }
}
