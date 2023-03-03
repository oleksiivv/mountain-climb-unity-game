using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public Vector3 startTransformPosition, startTransformRotation;

    public Vector3 resetPosition;

    public float speed = 1f;

    public static int sspeed = 1;


    void Start(){
        sspeed = 1;
    }

    void Update(){
        if(Time.timeScale == 1){
            transform.Translate(Vector3.right*-speed/60f*sspeed);
        }

        if(Mathf.Abs(resetPosition.y - transform.position.y) < 0.05f){
            resetTransform();
        }
    }

    void resetTransform(){
        Debug.Log("Reseted ground transform");
        gameObject.transform.position = startTransformPosition;
        gameObject.transform.eulerAngles = startTransformRotation;
    }
}
