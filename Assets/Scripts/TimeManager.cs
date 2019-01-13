using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public Slider time;
    public Text timeValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = time.value;
        timeValue.text = time.value.ToString("0.0");

        Citizen[] listCitizen = GameObject.FindObjectsOfType<Citizen>();

        foreach(Citizen cit in listCitizen)
        {
            cit.GetComponent<AudioSource>().pitch = time.value;
        }

       /* GameObject camera = GameObject.Find("Main Camera");

        if(timeValue.text == "1.0")
        {
            camera.GetComponent<AudioSource>().pitch = 1;
        }

        else
        {
            camera.GetComponent<AudioSource>().pitch = (time.value / 5) + 0.7f;
        }
        */
        
    }
}
