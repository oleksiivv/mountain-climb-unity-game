using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    public PlayerDeathController playerDeathController;

    public CoinsSavedController coinsSavedController;

    public PlayerAudioEffects audioEffects;

    public BonusesController bonusesController;

    public ParticleSystem schieldEffect;

    void Start(){
        if(playerDeathController == null){
            playerDeathController = gameObject.GetComponent<PlayerDeathController>();
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag.ToLower().Contains("enemy") && ! PlayerBonusItems.hasSchield){
            playerDeathController.deathBehaviour();
        }
        else if(other.gameObject.tag.ToLower().Contains("enemy") && PlayerBonusItems.hasSchield){
            schieldEffect.gameObject.transform.position = other.gameObject.transform.position;
            schieldEffect.Play();
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag.ToLower().Contains("coin")){
            ParticleSystem coinGetEffect = other.gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
            coinGetEffect.gameObject.transform.parent = null;

            coinGetEffect.Play();
            audioEffects.PlayPickCoinEffect();

            coinsSavedController.addCoinsAmount(10);

            Destroy(other.gameObject);
        }
        if(other.gameObject.name.ToLower().Contains("bonus")){
            ParticleSystem bonusGetEffect = other.gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
            bonusGetEffect.gameObject.transform.parent = null;

            bonusGetEffect.Play();
            audioEffects.PlayPickBonusEffect();

            bonusesController.UseByTag(other.gameObject.tag);

            Destroy(other.gameObject);
        }
    }
}
