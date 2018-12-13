using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour {

    public GameObject endScreenWin;
    public GameObject endScreenLose;

    public Text currentObjectif;
    public Text finalObjectif;

    public Slider slideTrees;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(int.Parse(currentObjectif.text) == int.Parse(finalObjectif.text))
        {
            endScreenWin.SetActive(true);
        }

        if(slideTrees.value == 0)
        {
            endScreenLose.SetActive(true);
        }
	}

    public void goToMainScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
