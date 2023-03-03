using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDistance : MonoBehaviour
{
    public float frameDelay = 0.5f;

    public int distanceM = 0;

    private float distanceToShow = 0, hiDistanceToShow = 0;
    
    public Text distanceText, hiDistance;

    public NewHighScorePanelController newHighScorePanelController;

    private int firstGame = 1;

    void Start()
    {
        firstGame = PlayerPrefs.GetInt("firstGame", 1);

        PlayerPrefs.SetInt("firstGame", 0);

        hiDistance.text = "High score: "+PlayerPrefs.GetInt("hi").ToString()+"m";

        StartCoroutine(distanceIncrease());
    }

    IEnumerator distanceIncrease(){
        while(true){
            if(Time.timeScale == 1 && GroundMove.sspeed == 1){
                distanceM++;
            }

            if(distanceM>1000){
                distanceToShow = distanceM / 1000f;

                distanceToShow = (float)Mathf.Round(distanceToShow * 10f) / 10f;

                distanceText.text = "Distance: "+distanceToShow.ToString()+"km";
            }
            else{
                distanceText.text = "Distance: "+distanceM.ToString()+"m";
            }

            if(distanceM>PlayerPrefs.GetInt("hi")){

                PlayerPrefs.SetInt("hi", distanceM);

                if(PlayerPrefs.GetInt("hi")>1000){
                    hiDistanceToShow = PlayerPrefs.GetInt("hi")/1000f;

                    hiDistanceToShow = (float)Mathf.Round(hiDistanceToShow * 10f) / 10f;

                    hiDistance.text = "High score: "+hiDistanceToShow.ToString()+"m";
                }
                else{
                    hiDistance.text = "High score: "+PlayerPrefs.GetInt("hi").ToString()+"m";
                }

                if(firstGame == 0)newHighScorePanelController.showNewHi();
            }

            yield return new WaitForSeconds(frameDelay);
        }
    }
}
