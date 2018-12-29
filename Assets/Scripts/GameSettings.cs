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
            Time.timeScale = 0;
            endScreenWin.SetActive(true);
            GetComponent<AudioSource>().enabled = false;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().enabled = false;
        }

        if(slideTrees.value == 0 ||int.Parse(days.text) >= maxDays)
        {
            Time.timeScale = 0;
            endScreenLose.SetActive(true);
            GetComponent<AudioSource>().enabled = false;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().enabled = false;
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
