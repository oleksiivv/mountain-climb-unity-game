using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUiController : MonoBehaviour
{
    public GameObject pausePanel;

    public GameObject newHiPanel;

    public GameObject deathPanel;

    public GameObject newHiDeathPanel;

    public void pause(){
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void resume(){
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    public void restart(){
        openScene(Application.loadedLevel);
    }

    public GameObject loadingScenePanel;
    public Slider loadingSlider;

    public void openScene(int id){
        Time.timeScale=1;
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
