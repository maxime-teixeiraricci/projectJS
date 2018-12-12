using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockDisplay : MonoBehaviour {

    public DayNightController timeControler;
    public Text hourText;
    public Text dayText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        hourText.text = timeControler.timeString;
        dayText.text = "Jour  " + timeControler.numberDay.ToString();

	}
}
