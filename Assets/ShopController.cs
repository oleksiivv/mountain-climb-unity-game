using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public Color32 availableItem, currentItem, nonAvailableItem;

    public Image[] items;

    public GameObject[] buyPanels;

    public GameObject[] choosePanels;

    public int[] prices;

    public Text[] priceLabels;

    public Text coinsLabel;

    public AudioSource audioSource;

    public AudioClip buyEffect, pickEffect;

    void Start(){
        coinsLabel.text = PlayerPrefs.GetInt("coins", 0).ToString();
        for(int i=0; i<priceLabels.Length; i++){
            priceLabels[i].text = prices[i].ToString();
        }

        ShowCurrentState();
    }

    public void Choose(int id){
        if(id == 0 || PlayerPrefs.GetInt("item#"+id.ToString(), 0) == 1){
            PlayerPrefs.SetInt("currentSkin", id);

            ShowCurrentState();

            audioSource.clip = pickEffect;
            audioSource.Play();
        }
    }

    public void Buy(int id){
        if(PlayerPrefs.GetInt("coins") >= prices[id]){
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - prices[id]);

            PlayerPrefs.SetInt("item#"+id.ToString(), 1);
            PlayerPrefs.SetInt("currentSkin", id);

            ShowCurrentState();

            audioSource.clip = buyEffect;
            audioSource.Play();
        }
    }


    void ShowCurrentState(){
        coinsLabel.text = PlayerPrefs.GetInt("coins", 0).ToString();

        for(int i=0; i<items.Length; i++){
            if(PlayerPrefs.GetInt("currentSkin", 0) == i){
                choosePanels[i].SetActive(false);
                buyPanels[i].SetActive(false);

                items[i].GetComponent<Image>().color = currentItem;
            } else {
                if(i == 0 || PlayerPrefs.GetInt("item#"+i.ToString(), 0) == 1){
                    buyPanels[i].SetActive(false);
                    choosePanels[i].SetActive(true);
                    items[i].GetComponent<Image>().color = availableItem;
                } else {
                    buyPanels[i].SetActive(true);
                    choosePanels[i].SetActive(false);
                    items[i].GetComponent<Image>().color = nonAvailableItem;
                } 
            }
        }
    }





    public GameObject loadingScenePanel;

    public Slider loadingSlider;

    public void openScene(int id){
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
