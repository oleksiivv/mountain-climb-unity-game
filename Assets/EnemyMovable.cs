using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovable : MonoBehaviour
{
    public Rigidbody rigidbody;

    public static float speed=1;

    protected bool canMove;

    protected float localSpeed;

    public ParticleSystem deathEffect;

    public float speedCoef = 1;

    protected void Start(){
        if(rigidbody==null){
            rigidbody=gameObject.GetComponent<Rigidbody>();
        }

        if(deathEffect==null){
            deathEffect=gameObject.transform.GetChild(0).transform.gameObject.GetComponent<ParticleSystem>();
        }

        canMove = false;

        localSpeed=Random.Range(1.1f, 2f);
    }

    void Update(){
        if(canMove){
            rigidbody.velocity = Vector3.left*speed*Time.timeScale*localSpeed*speedCoef;
            rigidbody.AddForce(Vector3.down*2, ForceMode.Impulse);
        }

        if(transform.position.y < -1.27f){
            Destroy(gameObject);
        }
    }

    protected void OnCollisionEnter(Collision other){
        if(other.gameObject.tag.Equals("Ground")){
            canMove=true;
            rigidbody.freezeRotation = true;
        }
        else if(other.gameObject.tag.ToLower().Contains("enemy") && !other.gameObject.tag.ToLower().Contains("fly")){
            canMove=true;
            deathEffect.gameObject.transform.parent=null;
            deathEffect.Play();
            Destroy(gameObject);
        }
    }
}
