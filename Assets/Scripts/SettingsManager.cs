﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

    public int index;
    public Slider volume;
    public Button mute;

    public Sprite sound;
    public Sprite muteSound;
    //AudioSource music;

    public FMODUnity.StudioEventEmitter mainTheme;

    float oldValue;

	// Use this for initialization
	void Start () {
        //music = GameObject.Find("Main Camera").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //music.volume = volume.value / 100;
        if(index == 1)
        {
            mainTheme.EventInstance.setVolume(volume.value / 100);
        }
        else
        {
            changeSoundsVolumes(volume.value / 100);
        }
        //mainTheme.EventInstance.setVolume(volume.value / 100);

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

    public void changeSoundsVolumes(float volume)
    {
        Citizen[] citizens = GameObject.FindObjectsOfType<Citizen>();
        NaturalRessource[] trees = GameObject.FindObjectsOfType<NaturalRessource>();

        foreach(Citizen cit in citizens)
        {
            FMODUnity.StudioEventEmitter emitter = cit.GetComponent<FMODUnity.StudioEventEmitter>();
            emitter.EventInstance.setVolume(volume);
        }
        foreach (NaturalRessource tree in trees)
        {
            FMODUnity.StudioEventEmitter emitter = tree.GetComponent<FMODUnity.StudioEventEmitter>();
            emitter.EventInstance.setVolume(volume);
            AudioSource source = tree.GetComponent<AudioSource>();
            source.volume = volume;
        }

        Building[] buildings = GameObject.FindObjectsOfType<Building>();
        foreach (Building building in buildings)
        {
            AudioSource source = building.GetComponent<AudioSource>();
            source.volume = volume;
        }

        GameObject.Find("ButtonCamp").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("ButtonHouse").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("ButtonStatue").GetComponent<AudioSource>().volume = volume;

    }

}
