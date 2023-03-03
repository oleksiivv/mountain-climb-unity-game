using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public GameObject buttonMutedSound, buttonNormalSound;

    public AudioController audio;
    void Start()
    {
        updateSound();
    }

    public void muteSound(){
        PlayerPrefs.SetInt("!sound",1);
        updateSound();

        //GetComponent<AudioSource>().enabled=false;
    }

    public void unmuteSound(){
        PlayerPrefs.SetInt("!sound",0);
        updateSound();

        //GetComponent<AudioSource>().enabled=true;
    }

    void updateSound(){
        if(PlayerPrefs.GetInt("!sound")==0){

            buttonMutedSound.SetActive(false);
            buttonNormalSound.SetActive(true);

        }
        else{
            buttonMutedSound.SetActive(true);
            buttonNormalSound.SetActive(false);
        }
        audio.updateSound();
    }

    
    public GameObject loadingScenePanel;
    public Slider loadingSlider;

    public void openScene(int id){
        Time.timeScale=1;
        //loadingPanel.SetActive(true);
        //Application.LoadLevelAsync(id);
        
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
