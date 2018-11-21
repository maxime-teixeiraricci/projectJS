using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

    public Ressource appleRessource;
    public Ressource woodRessource;

    public Image appleImage;
    public Image woodImage;

    public GameObject citizenPanel;

    bool citizenPanelDisplayed = false;

    // Use this for initialization
    void Start () {

        appleImage.sprite = appleRessource.image;
        woodImage.sprite = woodRessource.image;

        //citizenPanel = GameObject.Find("ManageCitizenPanel");
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void displayCitizenPanel()
    {
        if (!citizenPanelDisplayed)
        {
            citizenPanel.SetActive(true);
        }
        else
        {
            citizenPanel.SetActive(false);
        }

        citizenPanelDisplayed = !citizenPanelDisplayed;
    }
}
