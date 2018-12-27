using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour {

    public Camera camera;
    public AudioSource windSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        windStrength();
	}

    void windStrength()
    {
        windSound.volume = camera.transform.position.y * 2f / 100;
        Debug.Log("volume = " + windSound.volume);
    }
}
