using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchieldItem : BonusItem
{
    private float timeOfUse;

    private PlayerBonusItems player;

    private GameObject icon;

    void Start(){
        this.timeOfUse = 6;
        this.tag = "schield";
    }

    public override void Use(PlayerBonusItems player, GameObject label){
        this.player = player;
        this.icon = label;

        this.icon.gameObject.SetActive(true);

        this.player.StartSchield();

        if(IsInvoking(nameof(StopUse))){
            CancelInvoke(nameof(StopUse));
        }
        Invoke(nameof(StopUse), timeOfUse > 1 ? timeOfUse : 6);
    }

    public override void StopUse(){
        this.player.StopSchield();
        this.icon.gameObject.SetActive(false);
    }
}

