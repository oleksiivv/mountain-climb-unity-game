using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketItem : BonusItem
{
    private GameObject label;

    private float timeOfUse;

    void Start(){
        this.timeOfUse = 2;
        this.tag = "rocket";
    }

    public override void Use(PlayerBonusItems player, GameObject label){
        player.StartRocket();

        this.label = label;
        this.label.gameObject.SetActive(true);

        if(IsInvoking(nameof(StopUse))){
            CancelInvoke(nameof(StopUse));
        }
        Invoke(nameof(StopUse), timeOfUse > 1 ? timeOfUse : 2);
    }

    public override void StopUse(){
        this.label.gameObject.SetActive(false);
    }
}

