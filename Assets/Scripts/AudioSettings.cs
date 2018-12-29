using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour {
    public Slider volume;
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
        windSound.volume = camera.transform.position.y * (volume.value / 100) * 0.6f / 100;
        //Debug.Log("volume = " + windSound.volume);
    }
}
