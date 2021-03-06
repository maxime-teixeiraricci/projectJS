﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CitizenNumber : MonoBehaviour {

    private Slider slider;
    private Text text;

    public Slider s1;
    public Slider s2;
    public Slider s3;

    public Text maxValue;

    // Use this for initialization
    void Start ()
    {
        slider = gameObject.GetComponentInChildren<Slider>();
        text = gameObject.GetComponentInChildren<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        s1.maxValue = int.Parse(maxValue.text) - slider.value - s2.value - s3.value;
        s2.maxValue = int.Parse(maxValue.text) - slider.value -s1.value - s3.value;
        s3.maxValue = int.Parse(maxValue.text) - slider.value - s1.value - s2.value;
        text.text = "" + slider.value;

        WorldManager.citizenNumber = int.Parse(maxValue.text);
        //Debug.Log("value max =  " + WorldManager.citizenNumber);
        WorldManager.workers = (int)(slider.value + s1.value + s2.value + s3.value);

        WorldManager.gatherers = (int)GameObject.Find("GathererSlider").GetComponent<Slider>().value;
        WorldManager.producers = (int)GameObject.Find("ProducerSlider").GetComponent<Slider>().value;
        WorldManager.constructors = (int)GameObject.Find("ConstructorSlider").GetComponent<Slider>().value;
        WorldManager.transporters = (int)GameObject.Find("TransporterSlider").GetComponent<Slider>().value;
    }
}
