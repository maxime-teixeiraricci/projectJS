using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{

    public GameObject window;
    public GameObject volume;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showMessage()
    {
        window.SetActive(true);
        volume.SetActive(false);
    }

    public void hideMessage()
    {
        window.SetActive(false);
        volume.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
