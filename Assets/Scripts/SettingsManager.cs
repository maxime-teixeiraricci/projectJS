using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

    public int index;
    public Slider volume;
    public Slider volumeTheme;
    public Button mute;

    public Sprite sound;
    public Sprite muteSound;
    //AudioSource music;
    public GameObject errorSound;
    public GameObject winScreen;
    public GameObject loseScreen;

    public FMODUnity.StudioEventEmitter mainTheme;
    public GameObject eventSound;

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
            winScreen.GetComponent<AudioSource>().volume = volume.value / 100;
            loseScreen.GetComponent<AudioSource>().volume = volume.value / 100;
        }
        else
        {
            changeSoundsVolumes(volume.value / 100);
        }

        musicMuted();
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

    public void musicMuted()
    {
        if(volume.value == 0)
        {
            mute.GetComponent<Image>().sprite = muteSound;
        }

        else
        {
            mute.GetComponent<Image>().sprite = sound;
        }
    }

    public void changeSoundsVolumes(float volume)
    {
        FMODUnity.StudioEventEmitter[] emitters = GameObject.FindObjectsOfType<FMODUnity.StudioEventEmitter>();

        Citizen[] citizens = GameObject.FindObjectsOfType<Citizen>();
        GameObject[] trees = GameObject.FindGameObjectsWithTag("RessourceTank");

        foreach (Citizen cit in citizens)
        {
            FMODUnity.StudioEventEmitter emitter = cit.GetComponent<FMODUnity.StudioEventEmitter>();
            emitter.EventInstance.setVolume(volume);
        }
        foreach (GameObject tree in trees)
        {
            AudioSource source = tree.GetComponent<AudioSource>();
            source.volume = volume;
        }

        Building[] buildings = GameObject.FindObjectsOfType<Building>();
        foreach (Building building in buildings)
        {
            if(building.tag == "Statue")
            {
                foreach (AudioSource clip in building.GetComponents<AudioSource>())
                {
                    clip.volume = volume;
                }
            }

            else
            {
                AudioSource source = building.GetComponent<AudioSource>();
                source.volume = volume;
            }
            
        }

        errorSound.GetComponent<AudioSource>().volume = volume;
        GameObject.Find("SoundTree").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("ButtonCamp").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("ButtonHouse").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("ButtonStatue").GetComponent<AudioSource>().volume = volume;

        eventSound.GetComponent<AudioSource>().volume = volume;

        GameObject birds = GameObject.Find("BirdsSound");
        FMODUnity.StudioEventEmitter emitBirds = birds.GetComponent<FMODUnity.StudioEventEmitter>();
        emitBirds.EventInstance.setVolume(volume);


        foreach (Transform child in GameObject.Find("WaveSound").transform)
        {
            FMODUnity.StudioEventEmitter emitter = child.GetComponent<FMODUnity.StudioEventEmitter>();
            emitter.EventInstance.setVolume(volume);
        }

        //GameObject.Find("WaveN").GetComponent<FMODUnity.StudioEventEmitter>();

        foreach (FMODUnity.StudioEventEmitter emitter in emitters)
        {
            //FMOD.Studio.PLAYBACK_STATE state;
            //emitter.EventInstance.getPlaybackState(out state);
            //float vol;
            //float finalvol;
            //emitter.EventInstance.getVolume(out vol, out finalvol);
            if(emitter.tag.Equals("MainCamera") && volumeTheme.value <= 0){
                emitter.Stop();
            }
            else if (!emitter.tag.Equals("MainCamera") && volume <= 0)
            {
                //emitter.EventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                //emitter.EventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                emitter.Stop();
            }
            else if(!(emitter.IsPlaying()))
            {
               
                emitter.Play();
            }
        }

    }

}
