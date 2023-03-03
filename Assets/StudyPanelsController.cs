using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyPanelsController : MonoBehaviour
{
    public GameObject[] panels;

    private int currentPanel = 0;

    public PlayerDeathController player;

    void Start(){
        hideAlll();

        currentPanel=PlayerPrefs.GetInt("currentStudyPanel", 0);
        if(PlayerPrefs.GetInt("studied", 0) == 0){
            StartCoroutine(ShowStudy());
        }
    }

    private void hideAlll(){
        foreach(var panel in panels)panel.SetActive(false);
    }

    public void StartStudy(){
        currentPanel=0;
        StartCoroutine(ShowStudy());
    }

    IEnumerator ShowStudy(){
        while(currentPanel<panels.Length){
            hideAlll();

            if(player.alive){
                if(currentPanel<panels.Length){
                    panels[currentPanel].SetActive(true);
                }
                else {
                    hideAlll();
                    PlayerPrefs.SetInt("studied", 1);
                }

                if(currentPanel>=panels.Length-3){
                    PlayerPrefs.SetInt("studied", 1);
                }

                currentPanel++;
                PlayerPrefs.SetInt("currentStudyPanel", currentPanel>0?currentPanel-1:currentPanel);
            }

            yield return new WaitForSeconds(4);
        }

        hideAlll();
    }
}
