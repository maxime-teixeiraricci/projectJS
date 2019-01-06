using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

    public GameObject nextTuto;
    public Slider gatherers;
    public Slider crafters;
    public Slider carriers;
    public Slider builders;

    public Button camp;
    public Button house;
    public Button statue;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.activeSelf)
        {
            gatherers.interactable = false;
            crafters.interactable = false;
            carriers.interactable = false;
            builders.interactable = false;
            camp.interactable = false;
            house.interactable = false;
            statue.interactable = false;
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
    }
}
