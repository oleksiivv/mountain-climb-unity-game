using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    public GameObject[] coins;

    public Vector3 spawnPos;

    public Vector3 aimPos;

    public float delay;

    void Start(){
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins(){
        while(true){
            int coindId = Random.Range(0, coins.Length);
            var coin = Instantiate(coins[coindId], spawnPos + new Vector3(0, Random.Range(-0.3f, 0.55f), 0), coins[coindId].transform.rotation) as GameObject;
            coin.GetComponent<Coin>().aimPos = aimPos + new Vector3(0, Random.Range(-0.7f, -0.25f), 0);
            yield return new WaitForSeconds(2);
        }
    }
}
