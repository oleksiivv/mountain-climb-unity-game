using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusesController : MonoBehaviour
{
    public List<BonusItem> bonuses;

    public List<GameObject> labels;

    public PlayerBonusItems player;

    public void UseByTag(string tag){
        BonusItem choosenBonus = null;

        foreach(var bonus in bonuses){
            if(bonus.tag == tag){
                choosenBonus = bonus;
                break;
            }
        }

        choosenBonus.Use(player, labels[bonuses.IndexOf(choosenBonus)]);
    }
}
