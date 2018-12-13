using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

    public Slider volume;
    public Button mute;

    public Sprite sound;
    public Sprite muteSound;
    AudioSource music;

    float oldValue;

	// Use this for initialization
	void Start () {
        music = GameObject.Find("Main Camera").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        music.volume = volume.value / 100;
	}

    public void changeMusic()
    {
        if(mute.GetComponent<Image>().sprite == sound)
        {
            oldValue = volume.value;
            volume.value = 0;
            mute.GetComponent<Image>().sprite = muteSound;
        }

        else
        {
            volume.value = oldValue;
            mute.GetComponent<Image>().sprite = sound;
        }
        
    }

}
