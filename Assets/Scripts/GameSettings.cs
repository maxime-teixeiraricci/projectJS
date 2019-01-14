using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour {

    public GameObject endScreenWin;
    public GameObject endScreenLose;
    public GameObject optionsScreen;
    public GameObject errorScreen;

    public Text currentObjectif;
    public Text finalObjectif;

    public Slider slideTrees;

    public FMODUnity.StudioEventEmitter mainTheme;

    public GameObject evenementManager;

    public Text days;

    int maxDays = 45;

    public GameObject nextTuto;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        //FMODUnity.StudioEventEmitter emitter = mainTheme.GetComponent<FMODUnity.StudioEventEmitter>();

        if (Input.GetKeyDown(KeyCode.L))
        {
            currentObjectif.text = "-1";
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            currentObjectif.text = "5";
        }

        if (int.Parse(currentObjectif.text) == -1)
        {
            defeat();
        }

        if (int.Parse(currentObjectif.text) == 5)
        {
            win();
        }

        if (int.Parse(currentObjectif.text) == int.Parse(finalObjectif.text))
        {
            win();
        }

        if(slideTrees.value == 0 ||int.Parse(days.text) >= maxDays)
        {
            defeat();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            evenementManager.SetActive(true);
            evenementManager.GetComponent<AudioSource>().Play();
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            GameObject.Find("TimePanel").GetComponentInChildren<Slider>().value = 0;
            optionsScreen.SetActive(true);
        }
    }

    public void goToMainScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void replayGame()
    {
        SceneManager.LoadScene("Test");
    }

    public void hideWindow()
    {
        errorScreen.SetActive(false);
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

    public void defeat()
    {
        FMODUnity.StudioEventEmitter emitter = mainTheme.GetComponent<FMODUnity.StudioEventEmitter>();
        Time.timeScale = 0;
        GameObject.Find("TimePanel").GetComponentInChildren<Slider>().value = 0;
        endScreenLose.SetActive(true);
        GetComponent<AudioSource>().enabled = false;
        mainTheme.GetComponent<FMODUnity.StudioEventEmitter>().Stop();
        GameObject.Find("Sounds").GetComponentInChildren<Slider>().value = 0;
    }

    public void win()
    {
        Time.timeScale = 0;
        GameObject.Find("TimePanel").GetComponentInChildren<Slider>().value = 0;
        endScreenWin.SetActive(true);
        GetComponent<AudioSource>().enabled = false;
        mainTheme.GetComponent<FMODUnity.StudioEventEmitter>().Stop();
    }

}
