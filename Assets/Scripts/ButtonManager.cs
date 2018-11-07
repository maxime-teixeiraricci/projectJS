using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    public Button currentButton;
    public GameObject arrow;


	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

	}

    public void mouseOnButton()
    {
        arrow.SetActive(true);
        //Debug.Log("Im on it");
    }

    public void mouseOutsideButton()
    {
        arrow.SetActive(false);
        //Debug.Log("Im leavin it");
    }
}
