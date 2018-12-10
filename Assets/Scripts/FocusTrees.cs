using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusTrees : MonoBehaviour {

    List<Citizen> citizen;


    // Use this for initialization
    void Start ()
    {
        citizen = GameObject.Find("Dispatcher").GetComponent<DispatcherManager>().collectCitizens;
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void OnMouseDown()
    {
        foreach(Citizen cit in citizen)
        {
            cit.GetComponent<FSMControler>().manualTarget = gameObject;
        }
    }
}
