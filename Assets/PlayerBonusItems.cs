using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonusItems : MonoBehaviour
{
    public CapsuleCollider magnetCollider;

    public static bool hasSchield = false;

    public PlayerDistance distance;

    void Start(){
        hasSchield = false;
    }

    void Update(){
        //Debug.Log("Magnet: "+magnetCollider.enabled.ToString());
    }

    public void StartMagnet(){
        magnetCollider.enabled = true;
    }

    public void StopMagnet(){
        magnetCollider.enabled = false;
    }

    public void StartSchield(){
        hasSchield = true;
    }

    public void StopSchield(){
        hasSchield = false;
    }

    public void StartRocket(){
        distance.distanceM+=2000;
    }
}
