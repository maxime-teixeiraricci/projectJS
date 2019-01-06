using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

    public GameObject nextTuto;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void skipTuto()
    {
        gameObject.SetActive(false);
    }

    public void showNextTuto()
    {
        nextTuto.SetActive(true);

        gameObject.SetActive(false);
    }

    public void playGame()
    {
        gameObject.SetActive(false);
    }
}
