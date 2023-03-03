using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagnetItem : BonusItem
{
    private float timeOfUse;

    private PlayerBonusItems player;

    private GameObject icon;

    void Start(){
        this.timeOfUse = 8;
        this.tag = "magnet";
    }

    public override void Use(PlayerBonusItems player, GameObject label){
        this.player = player;
        this.icon = label;

        Debug.Log("Start use of magnet");

        this.icon.gameObject.SetActive(true);
        this.player.StartMagnet();

        if(IsInvoking(nameof(StopUse))){
            CancelInvoke(nameof(StopUse));
        }
        Invoke(nameof(StopUse), timeOfUse > 1 ? timeOfUse : 8);
    }

    public override void StopUse(){
        this.icon.gameObject.SetActive(false);
        this.player.StopMagnet();

        Debug.Log("Stop use of magnet");
    }
}
