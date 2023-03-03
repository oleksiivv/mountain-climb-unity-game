using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPanelAnimation : MonoBehaviour
{
    public GameObject[] panelParts;

    public float delay = 2f;

    void Start(){
        hideParts();
        
        Invoke(nameof(showParts), delay);
    }

    void hideParts(){
        foreach(var panel in panelParts){
            panel.SetActive(false);
        }
    }

    void showParts(){
        foreach(var panel in panelParts){
            panel.SetActive(true);
        }
    }
}
