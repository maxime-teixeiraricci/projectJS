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

    public GameObject evenementManager;

    public Text days;

    int maxDays = 45;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(int.Parse(currentObjectif.text) == int.Parse(finalObjectif.text))
        {
            endScreenWin.SetActive(true);
            Time.timeScale = 0;
        }

        if(slideTrees.value == 0 ||int.Parse(days.text) >= maxDays)
        {
            endScreenLose.SetActive(true);
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            evenementManager.SetActive(true);
        }
	}

    public void goToMainScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
