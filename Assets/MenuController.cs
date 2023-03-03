using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject startGameDarkPanel;

    public GameObject loadingScenePanel;

    public Slider loadingSlider;

    public Text hiLabel;

    void Start(){
        if(PlayerPrefs.GetInt("firstOpen", 0) == 0){
            PlayerPrefs.SetInt("coins", 50);
            PlayerPrefs.SetInt("firstOpen", 1);
        }
        hiLabel.text = "High score: "+PlayerPrefs.GetInt("hi").ToString()+"m";
    }

    public void StartGame(int sceneId){
        startGameDarkPanel.SetActive(true);

        Invoke(nameof(openScene1), 1.5f);
    }

    void openScene1(){
        //loadingScenePanel.SetActive(true);
        //Application.LoadLevelAsync(id);
        //Application.LoadLevel(1);

        StartCoroutine(loadAsync(1));
    }

    public void openScene(int id){
        //loadingScenePanel.SetActive(true);
        //Application.LoadLevelAsync(id);
        //Application.LoadLevel(id);

        StartCoroutine(loadAsync(id));
    }

    IEnumerator loadAsync(int id)
    {
        AsyncOperation operation = Application.LoadLevelAsync(id);
        loadingScenePanel.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingSlider.value = progress;
            yield return null;

        }
    }
}
