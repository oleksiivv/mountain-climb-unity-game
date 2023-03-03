using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [HideInInspector()]
    public Vector3 aimPos;

    public float speed=1f;

    void Start(){
        //aimPos = new Vector3(-1.8f, 0, 0.3f);
        //aimPos = aimPos + new Vector3(0, Random.Range(-0.8f, -0.25f), 0);
    }

    void Update(){
        transform.position = Vector3.MoveTowards(transform.position, aimPos, Time.timeScale*speed/30.0f);
    }
}
