using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusesSpawner : MonoBehaviour
{
    public GameObject[] bonuses;

    public Vector3 spawnPos;

    public Vector3 aimPos;

    public float delay;

    void Start(){
        Invoke(nameof(StartSimulation), 12);
    }

    void StartSimulation(){
        StartCoroutine(SpawnBonuses());
    }

    IEnumerator SpawnBonuses(){
        while(true){
            int bonusId = Random.Range(0, bonuses.Length);
            var bonus = Instantiate(bonuses[bonusId], spawnPos + new Vector3(0, Random.Range(-0.3f, 0.55f), 0), bonuses[bonusId].transform.rotation) as GameObject;
            bonus.GetComponent<BonusItem>().aimPos = aimPos + new Vector3(0, Random.Range(-0.7f, -0.25f), 0);
            yield return new WaitForSeconds(delay);
        }
    }
}
