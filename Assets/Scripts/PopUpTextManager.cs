using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpTextManager : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void OnMouseOver()
    {
        target.SetActive(true);
    }

    public void OnMouseExit()
    {
        target.SetActive(false);
    }
}
