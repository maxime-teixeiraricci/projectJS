using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

    public GameObject nextTuto;
    public GameObject previousTuto;
    public Slider gatherers;
    public Slider crafters;
    public Slider carriers;
    public Slider builders;

    public Slider speedTime;

    public Button camp;
    public Button house;
    public Button statue;

    // Use this for initialization
    void Start () {
        Time.timeScale = 0;
        speedTime.value = 0;
    }
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = 0;
        speedTime.value = 0;
        if (gameObject.activeSelf)
        {
            gatherers.interactable = false;
            crafters.interactable = false;
            carriers.interactable = false;
            builders.interactable = false;
            camp.interactable = false;
            house.interactable = false;
            statue.interactable = false;
            speedTime.interactable = false;
        }
	}

    public void skipTuto()
    {
        activatingInteractables();
        gameObject.SetActive(false);
        
    }

    public void showNextTuto()
    {
        nextTuto.SetActive(true);

        gameObject.SetActive(false);
    }

    public void showPreviousTuto()
    {
        previousTuto.SetActive(true);
        gameObject.SetActive(false);
    }

    public void playGame()
    {
        activatingInteractables();
        gameObject.SetActive(false);
    }

    public void activatingInteractables()
    {
        gatherers.interactable = true;
        crafters.interactable = true;
        carriers.interactable = true;
        builders.interactable = true;
        camp.interactable = true;
        house.interactable = true;
        statue.interactable = true;
        speedTime.interactable = true;
        Time.timeScale = 1;
        speedTime.value = 1;
    }
}
