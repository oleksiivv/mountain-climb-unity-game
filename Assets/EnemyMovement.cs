using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    protected float speed = 1;

    [SerializeField]
    private Rigidbody rigidbody;

    void Start(){
        rigidbody = gameObject.GetComponent<Rigidbody>();

        if(speed == 1){
            speed*=Random.Range(0.75f, 1.5f);
        }
    }

    void Update(){
        rigidbody.AddForce(Vector3.down*10*speed, ForceMode.Impulse);
    }
}
