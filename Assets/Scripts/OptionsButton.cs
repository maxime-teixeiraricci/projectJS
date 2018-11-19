using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsButton : MonoBehaviour {

    public GameObject optionsMenu;
    bool checking = false;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void displayOptions()
    {
        
        if (!checking)
        {
            optionsMenu.SetActive(true);
            checking = true;
        }

        else
        {
            optionsMenu.SetActive(false);
            checking = false;
        }
        
    }
}
