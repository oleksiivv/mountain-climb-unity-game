using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemiesEasy;

    public GameObject[] enemiesMedium;

    public GameObject[] enemiesHard;

    public Vector3 spawnPosition;

    public float delay = 2.75f;

    public static int level=1;

    public int numberOfCreatedEnemies = 0;

    void Start(){
        if(delay == 2.75f){
            delay *= Random.Range(0.5f, 1.1f);
        }

        numberOfCreatedEnemies = 0;
        level=1;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn(){
        while(true){
            numberOfCreatedEnemies++;

            if(numberOfCreatedEnemies>=10){
                level=2;
            }
            else if(numberOfCreatedEnemies>=30){
                level=3;
            }

            GameObject newEnemy;

            int randomEnemiId=0;

            //Debug.Log("Enemies: "+numberOfCreatedEnemies);

            switch(level){
                case 1:
                    randomEnemiId = Random.Range(0, enemiesEasy.Length);
                    newEnemy = Instantiate(enemiesEasy[randomEnemiId], spawnPosition, enemiesEasy[randomEnemiId].transform.rotation);
                break;
                case 2:
                    randomEnemiId = Random.Range(0, enemiesMedium.Length);
                    newEnemy = Instantiate(enemiesMedium[randomEnemiId], spawnPosition, enemiesMedium[randomEnemiId].transform.rotation);
                break;
                default:
                    randomEnemiId = Random.Range(0, enemiesHard.Length);
                    newEnemy = Instantiate(enemiesHard[randomEnemiId], spawnPosition, enemiesHard[randomEnemiId].transform.rotation);
                break;
            }

            newEnemy.transform.localScale*=Random.Range(0.9f, 1.2f);

            yield return new WaitForSeconds(delay);
        }
    }
}
