using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

    public Slider volumeSlider;
    private Text volumeValue;

    private Text citizenValue;
    private Slider citizenSlider;

	// Use this for initialization
	void Start () {
        volumeValue = GameObject.Find("VolumeValue").GetComponent<Text>();

        citizenValue = GameObject.Find("CitizenValue").GetComponent<Text>();
        citizenSlider = GameObject.Find("CitizenSlider").GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<AudioSource>().volume = volumeSlider.value / 100;
        volumeValue.text = "" + volumeSlider.value;
        citizenValue.text = "" + citizenSlider.value;
        WorldManager.citizenNumber = (int)citizenSlider.value;
	}
}
