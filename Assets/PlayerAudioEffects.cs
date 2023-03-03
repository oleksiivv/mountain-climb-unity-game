using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioEffects : MonoBehaviour
{
    public AudioSource source;

    public AudioClip coinPickEffect, bonusPickEffect;

    private bool canPlay = true;

    void Start(){
        source.enabled=PlayerPrefs.GetInt("!sound",0)==0;
        canPlay=true;
    }

    public void PlayPickCoinEffect(){
        if(canPlay){
            source.clip = coinPickEffect;
            source.Play();

            canPlay=false;
            if(!IsInvoking(nameof(ResetCanPlay))){
                Invoke(nameof(ResetCanPlay), 0.5f);
            }
        }
    }

    public void PlayPickBonusEffect(){
        if(canPlay){
            source.clip = bonusPickEffect;
            source.Play();

            if(!IsInvoking(nameof(ResetCanPlay))){
                Invoke(nameof(ResetCanPlay), 0.5f);
            }
        }
    }

    void ResetCanPlay(){
        canPlay=true;
    }
}
