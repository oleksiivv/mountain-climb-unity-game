using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyable : EnemyMovable
{
    public float minPosY, maxPosY;

    void Start()
    {
        base.Start();

        transform.position = new Vector3(transform.position.x, Random.Range(minPosY, maxPosY), transform.position.z);
    }

    void Update()
    {
        //rigidbody.AddForce(Vector3.down*speed, ForceMode.Impulse);
        rigidbody.AddForce(Vector3.left*localSpeed*15*speed, ForceMode.Impulse);
        //transform.eulerAngles = new Vector3(0, 0, 23);
        rigidbody.velocity = Vector3.down*speed/2*Time.timeScale*localSpeed*speedCoef;
    }
}
