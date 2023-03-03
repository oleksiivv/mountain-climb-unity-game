using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHighScorePanelController : MonoBehaviour
{
    public GameObject newHiPanel;

    public float delay = 3f;

    private bool newHiPanelShowed = false;

    public void showNewHi(){

        if(newHiPanelShowed == true) return;

        newHiPanelShowed = true;

        newHiPanel.gameObject.SetActive(true);

        Invoke(nameof(hideNewHi), delay);
    }

    void hideNewHi(){
        newHiPanel.gameObject.SetActive(false);
    }
}
