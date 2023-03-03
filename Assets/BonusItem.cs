using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BonusItem : MonoBehaviour
{
    public string tag;

    [HideInInspector()]
    public Vector3 aimPos;

    public float speed=1f;
    
    public abstract void Use(PlayerBonusItems player, GameObject label);

    public abstract void StopUse();

    void Update(){
        transform.position = Vector3.MoveTowards(transform.position, aimPos, Time.timeScale*speed/35.0f);
    }
}
