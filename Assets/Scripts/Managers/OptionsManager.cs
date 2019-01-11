using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

    public Slider volumeSlider;
    public Text volumeValue;

    private Text citizenValue;
    private Slider citizenSlider;

	// Use this for initialization
	void Start () {
        
        if(GameObject.Find("CitizenValue") != null){
            citizenValue = GameObject.Find("CitizenValue").GetComponent<Text>();
        }

        if (GameObject.Find("CitizenSlider") != null)
        {
            citizenValue = GameObject.Find("CitizenSlider").GetComponent<Text>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<AudioSource>().volume = volumeSlider.value / 100;
        GameObject.Find("Button").GetComponent<AudioSource>().volume = volumeSlider.value / 100;

        if (volumeValue != null)
        {
            volumeValue.text = "" + volumeSlider.value;
        }
        
        if(citizenValue != null)
        {
            citizenValue.text = "" + citizenSlider.value;
        }
        
        //WorldManager.citizenNumber = (int)citizenSlider.value;
	}
}
