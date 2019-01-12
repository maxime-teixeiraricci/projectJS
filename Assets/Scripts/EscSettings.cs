using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscSettings : MonoBehaviour {

    public Button continueButton;
    public Button replayButton;
    public Button mainScreenButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void continueGame()
    {
        gameObject.SetActive(false);
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Test");
    }

    public void leaveGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
